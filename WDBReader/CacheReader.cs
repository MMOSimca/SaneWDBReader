using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WDBReader
{
    class CacheReader<T> where T : class
    {
        public string Magic { get; private set; }
        public int Build { get; private set; }
        public string Locale { get; private set; }
        public int RecordSize { get; private set; }
        public int RecordVersion { get; private set; }
        public int CacheVersion { get; private set; }
        public SortedDictionary<int, T> Records { get; private set; }

        // A few different constructors with simple arguments
        public CacheReader(string filename)
        {
            using (var file = File.OpenRead(filename))
            using (var reader = new BinaryReader(file))
            {
                ParseWDB(reader);
            }
        }
        public CacheReader(Stream input)
        {
            using (var reader = new BinaryReader(input))
            {
                ParseWDB(reader);
            }
        }
        public CacheReader(BinaryReader rd)
        {
            ParseWDB(rd);
        }

        // Main function to parse the beginning parts of the WDB and then to pass off the rows to the individual cache class constructors
        private void ParseWDB(BinaryReader rd)
        {
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            var magicBuf = rd.ReadBytes(4);
            Array.Reverse(magicBuf);
            Magic = Encoding.ASCII.GetString(magicBuf);
            Build = rd.ReadInt32();
            var localeBuf = rd.ReadBytes(4);
            Array.Reverse(localeBuf);
            Locale = Encoding.ASCII.GetString(localeBuf);
            RecordSize = rd.ReadInt32();
            RecordVersion = rd.ReadInt32();
            CacheVersion = rd.ReadInt32();

            if (Locale != "enUS")
            {
                Console.WriteLine("WARNING: Non-english WDB detected. Locale detected is \'" + Locale + "\'.");
            }

            Records = new SortedDictionary<int, T>();
            while (rd.BaseStream.Position < rd.BaseStream.Length)
            {
                var id = rd.ReadInt32();
                var length = rd.ReadInt32();
                if (length == 0)
                    break;

                var buf = rd.ReadBytes(length);
                var record = Activator.CreateInstance(typeof(T), new object[] { new DataStore(new BinaryReader(new MemoryStream(buf))), id }) as T;
                Records.Add(id, record);
            }
        }

        // Output as CSV using CSVHelper
        public void OutputCSV(string directoryName)
        {
            Type baseType = this.GetType().GetGenericArguments()[0];
            string outputFilename = Path.Combine(directoryName, $"{baseType.Name}_Build_{Build}.csv");

            using (FileStream fs = File.Open(outputFilename, FileMode.Create, FileAccess.Write))
            using (TextWriter sw = new StreamWriter(fs))
            using (CsvWriter csv = new CsvWriter(sw, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture) { Delimiter = "," }))
            {
                csv.WriteHeader(baseType);
                csv.WriteRecords(Records.Values);
            }
        }
    }

    // Class designed to hold multiple different types of cache readers simultaneously
    class MultiCacheReader
    {
        public CacheReader<CreatureCache> CreatureCacheReader { get; private set; }
        public CacheReader<GameObjectCache> GameObjectCacheReader { get; private set; }
        public CacheReader<QuestCache> QuestCacheReader { get; private set; }

        public MultiCacheReader()
        {
            CreatureCacheReader = null;
            GameObjectCacheReader = null;
            QuestCacheReader = null;
        }
        public void ReadCache(string filename)
        {
            using (var file = File.OpenRead(filename))
            using (var reader = new BinaryReader(file))
            {
                ReadCache(reader);
            }
        }
        public void ReadCache(Stream input)
        {
            using (var reader = new BinaryReader(input))
            {
                ReadCache(reader);
            }
        }
        public void ReadCache(BinaryReader rd)
        {
            // Determine cache type
            rd.BaseStream.Seek(0, SeekOrigin.Begin);
            var magicBuf = rd.ReadBytes(4);
            Array.Reverse(magicBuf);
            string magic = Encoding.ASCII.GetString(magicBuf);

            // Populate cache of proper type
            switch (magic)
            {
                case "WMOB":
                    CreatureCacheReader = new CacheReader<CreatureCache>(rd);
                    break;
                case "WQST":
                    GameObjectCacheReader = new CacheReader<GameObjectCache>(rd);
                    break;
                case "WGOB":
                    QuestCacheReader = new CacheReader<QuestCache>(rd);
                    break;
                default:
                    return;
            }
        }
    }
}

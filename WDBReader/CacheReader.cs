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
                var record = Activator.CreateInstance(typeof(T), new object[] { new DataStore(new BinaryReader(new MemoryStream(buf))) }) as T;
                Records.Add(id, record);
            }
        }
    }
}

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
        public int unk0 { get; private set; }
        public int unk1 { get; private set; }
        public uint unk2 { get; private set; }
        public SortedDictionary<int, T> Records { get; private set; }

        public CacheReader(string _magic, BinaryReader rd)
        {
            Magic = _magic;
            Build = rd.ReadInt32();
            var localeBuf = rd.ReadBytes(4);
            Array.Reverse(localeBuf);
            Locale = Encoding.ASCII.GetString(localeBuf);
            unk0 = rd.ReadInt32();
            unk1 = rd.ReadInt32();
            unk2 = rd.ReadUInt32();

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
                // Originally was just: var record = new GameObjectCache(new DataStore(new BinaryReader(new MemoryStream(buf))));
                // Changed it so that template variables could be used
                Records.Add(id, record);
            }
        }
    }
}

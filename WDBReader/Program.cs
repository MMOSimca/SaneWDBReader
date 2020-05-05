using System;
using System.IO;
using System.Text;

namespace WDBReader
{
    // This Program class mainly exists to quickly convert WDB files into CSV files via the command line.
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage error: WDBReader.exe PathToWDBFile1 [PathToWDBFile2] [PathToWDBFile3] (etc)");
            }

            // Read caches (create MultiCacheReader, read cache, output all potential CacheReaders as CSVs)
            for (int i = 0; i < args.Length; ++i)
            {
                var mcr = new MultiCacheReader();
                mcr.ReadCache(args[i]);
                mcr.CreatureCacheReader?.OutputCSV(Path.GetDirectoryName(args[i]));
                mcr.GameObjectCacheReader?.OutputCSV(Path.GetDirectoryName(args[i]));
                mcr.CreatureCacheReader?.OutputCSV(Path.GetDirectoryName(args[i]));
            }
        }
    }
}

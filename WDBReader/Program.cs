using System;
using System.IO;
using System.Text;

namespace WDBReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START");

            // Load file and initialize binary reader
            using (var file = File.OpenRead("C:\\World of Warcraft\\Cache\\WDB\\enUS\\QuestCache.wdb"))
            using (var reader = new BinaryReader(file))
            {
                // Determine signature
                var magicBuf = reader.ReadBytes(4);
                Array.Reverse(magicBuf);
                string magic = Encoding.ASCII.GetString(magicBuf);

                // Read cache as appropriate
                if (magic == "WMOB") // CreatureCache.wdb
                {
                    var cache = new CacheReader<CreatureCache>(magic, reader);
                    // Convert records to SQL and stuff here
                }
                else if (magic == "WGOB") // GameObjectCache.wdb
                {
                    var cache = new CacheReader<GameObjectCache>(magic, reader);
                    // Convert records to SQL and stuff here
                }
                else if (magic == "WQST") // QuestCache.wdb
                {
                    var cache = new CacheReader<QuestCache>(magic, reader);
                    StreamWriter outputFile = new StreamWriter("C:\\Users\\Simca\\Desktop\\WDBReader_QuestCache_Output.csv");
                    outputFile.WriteLine("QuestID" + "," + "ItemDropID[0]" + "," + "ItemDropID[1]" + "," + "ItemDropID[2]" + "," + "ItemDropID[3]" + "," + "ItemDropQuantity[0]" + "," + "ItemDropQuantity[1]" + "," + "ItemDropQuantity[2]" + "," + "ItemDropQuantity[3]" + "," + "UNK_1" + "," + "UNK_2" + "," + "RewardHonor" + "," + "RewardKillHonor" + "," + "RewardTitle" + "," + "RewardTalents" + "," + "RewardArenaPoints" + "," + "AreaGroupID" + "," + "TimeAllowed" + "," + "RaceFlags");
                    foreach (var record in cache.Records)
                    {
                        outputFile.WriteLine(record.Value.QuestID.ToString() + "," + record.Value.ItemDropID[0].ToString() + "," + record.Value.ItemDropID[1].ToString() + "," + record.Value.ItemDropID[2].ToString() + "," + record.Value.ItemDropID[3].ToString() + "," + record.Value.ItemDropQuantity[0].ToString() + "," + record.Value.ItemDropQuantity[1].ToString() + "," + record.Value.ItemDropQuantity[2].ToString() + "," + record.Value.ItemDropQuantity[3].ToString() + "," + record.Value.UNK_1.ToString() + "," + record.Value.UNK_2.ToString() + "," + record.Value.RewardHonor.ToString() + "," + record.Value.RewardKillHonor.ToString() + "," + record.Value.RewardTitle.ToString() + "," + record.Value.RewardTalents.ToString() + "," + record.Value.RewardArenaPoints.ToString() + "," + record.Value.AreaGroupID.ToString() + "," + record.Value.TimeAllowed.ToString() + "," + record.Value.RaceFlags);
                    }
                    outputFile.Close();
                    // Convert records to SQL and stuff here
                }
                else
                {
                    Console.WriteLine("ERROR: Unknown WDB signature - \'" + magic + "\'!");
                }
            }
        }
    }
}

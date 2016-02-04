﻿using System;
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
                    StreamWriter outputFile = new StreamWriter("C:\\Users\\mmosi\\Desktop\\WDBReader_QuestCache_Output.csv");
                    outputFile.WriteLine("\"QuestID\",\"QuestType\",\"QuestLevel\",\"QuestPackageID\",\"QuestMinLevel\",\"QuestSortID\",\"QuestInfoID\",\"SuggestedGroupNum\",\"RewardNextQuest\",\"RewardXPDifficulty\",\"RewardXPFlags\",\"RewardMoney\",\"RewardMoneyDifficulty\",\"RewardMoneyFlags\",\"RewardBonusMoney\",\"RewardDisplaySpell\",\"RewardSpell\",\"RewardHonor\",\"RewardKillHonor\",\"ProvidedItem\",\"Flags\",\"FlagsEx\",\"RewardFixedItemID[0]\",\"RewardFixedItemQuantity[0]\",\"RewardFixedItemID[1]\",\"RewardFixedItemQuantity[1]\",\"RewardFixedItemID[2]\",\"RewardFixedItemQuantity[2]\",\"RewardFixedItemID[3]\",\"RewardFixedItemQuantity[3]\",\"ItemDropID[0]\",\"ItemDropQuantity[0]\",\"ItemDropID[1]\",\"ItemDropQuantity[1]\",\"ItemDropID[2]\",\"ItemDropQuantity[2]\",\"ItemDropID[3]\",\"ItemDropQuantity[3]\",\"RewardChoiceItemID[0]\",\"RewardChoiceItemQuantity[0]\",\"RewardChoiceItemDisplayID[0]\",\"RewardChoiceItemID[1]\",\"RewardChoiceItemQuantity[1]\",\"RewardChoiceItemDisplayID[1]\",\"RewardChoiceItemID[2]\",\"RewardChoiceItemQuantity[2]\",\"RewardChoiceItemDisplayID[2]\",\"RewardChoiceItemID[3]\",\"RewardChoiceItemQuantity[3]\",\"RewardChoiceItemDisplayID[3]\",\"RewardChoiceItemID[4]\",\"RewardChoiceItemQuantity[4]\",\"RewardChoiceItemDisplayID[4]\",\"RewardChoiceItemID[5]\",\"RewardChoiceItemQuantity[5]\",\"RewardChoiceItemDisplayID[5]\",\"POIContinent\",\"POIx\",\"POIy\",\"POIPriority\",\"RewardTitle\",\"RewardTalents\",\"RewardArenaPoints\",\"RewardSkillLineID\",\"RewardNumSkillUps\",\"PortraitGiverDisplayID\",\"PortraitTurnInDisplayID\",\"RewardFactionID[0]\",\"RewardFactionValue[0]\",\"RewardFactionOverride[0]\",\"RewardFactionID[1]\",\"RewardFactionValue[1]\",\"RewardFactionOverride[1]\",\"RewardFactionID[2]\",\"RewardFactionValue[2]\",\"RewardFactionOverride[2]\",\"RewardFactionID[3]\",\"RewardFactionValue[3]\",\"RewardFactionOverride[3]\",\"RewardFactionID[4]\",\"RewardFactionValue[4]\",\"RewardFactionOverride[4]\",\"RewardFactionFlags\",\"RewardCurrencyID[0]\",\"RewardCurrencyQuantity[0]\",\"RewardCurrencyID[1]\",\"RewardCurrencyQuantity[1]\",\"RewardCurrencyID[2]\",\"RewardCurrencyQuantity[2]\",\"RewardCurrencyID[3]\",\"RewardCurrencyQuantity[3]\",\"AcceptedSoundKitID\",\"CompleteSoundKitID\",\"AreaGroupID\",\"TimeAllowed\",\"NumObjectives\",\"RaceFlags\",\"Title\",\"Summary\",\"FullText\",\"TrackerText\",\"PortraitGiverText\",\"PortraitGiverName\",\"PortraitTurnInText\",\"PortraitTurnInName\",\"CompletionBlurb\"");
                    foreach (var record in cache.Records)
                    {
                        outputFile.WriteLine("\"" + record.Value.QuestID.ToString() + "\",\"" + record.Value.QuestType.ToString() + "\",\"" + record.Value.QuestLevel.ToString() + "\",\"" + record.Value.QuestPackageID.ToString() + "\",\"" + record.Value.QuestMinLevel.ToString() + "\",\"" + record.Value.QuestSortID.ToString() + "\",\"" + record.Value.QuestInfoID.ToString() + "\",\"" + record.Value.SuggestedGroupNum.ToString() + "\",\"" + record.Value.RewardNextQuest.ToString() + "\",\"" + record.Value.RewardXPDifficulty.ToString() + "\",\"" + record.Value.RewardXPFlags.ToString() + "\",\"" + record.Value.RewardMoney.ToString() + "\",\"" + record.Value.RewardMoneyDifficulty.ToString() + "\",\"" + record.Value.RewardMoneyFlags.ToString() + "\",\"" + record.Value.RewardBonusMoney.ToString() + "\",\"" + record.Value.RewardDisplaySpell.ToString() + "\",\"" + record.Value.RewardSpell.ToString() + "\",\"" + record.Value.RewardHonor.ToString() + "\",\"" + record.Value.RewardKillHonor.ToString() + "\",\"" + record.Value.ProvidedItem.ToString() + "\",\"" + record.Value.Flags.ToString() + "\",\"" + record.Value.FlagsEx.ToString() + "\",\"" + record.Value.RewardFixedItemID[0].ToString() + "\",\"" + record.Value.RewardFixedItemQuantity[0].ToString() + "\",\"" + record.Value.RewardFixedItemID[1].ToString() + "\",\"" + record.Value.RewardFixedItemQuantity[1].ToString() + "\",\"" + record.Value.RewardFixedItemID[2].ToString() + "\",\"" + record.Value.RewardFixedItemQuantity[2].ToString() + "\",\"" + record.Value.RewardFixedItemID[3].ToString() + "\",\"" + record.Value.RewardFixedItemQuantity[3].ToString() + "\",\"" + record.Value.ItemDropID[0].ToString() + "\",\"" + record.Value.ItemDropQuantity[0].ToString() + "\",\"" + record.Value.ItemDropID[1].ToString() + "\",\"" + record.Value.ItemDropQuantity[1].ToString() + "\",\"" + record.Value.ItemDropID[2].ToString() + "\",\"" + record.Value.ItemDropQuantity[2].ToString() + "\",\"" + record.Value.ItemDropID[3].ToString() + "\",\"" + record.Value.ItemDropQuantity[3].ToString() + "\",\"" + record.Value.RewardChoiceItemID[0].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[0].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[0].ToString() + "\",\"" + record.Value.RewardChoiceItemID[1].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[1].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[1].ToString() + "\",\"" + record.Value.RewardChoiceItemID[2].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[2].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[2].ToString() + "\",\"" + record.Value.RewardChoiceItemID[3].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[3].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[3].ToString() + "\",\"" + record.Value.RewardChoiceItemID[4].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[4].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[4].ToString() + "\",\"" + record.Value.RewardChoiceItemID[5].ToString() + "\",\"" + record.Value.RewardChoiceItemQuantity[5].ToString() + "\",\"" + record.Value.RewardChoiceItemDisplayID[5].ToString() + "\",\"" + record.Value.POIContinent.ToString() + "\",\"" + record.Value.POIx.ToString() + "\",\"" + record.Value.POIy.ToString() + "\",\"" + record.Value.POIPriority.ToString() + "\",\"" + record.Value.RewardTitle.ToString() + "\",\"" + record.Value.RewardTalents.ToString() + "\",\"" + record.Value.RewardArenaPoints.ToString() + "\",\"" + record.Value.RewardSkillLineID.ToString() + "\",\"" + record.Value.RewardNumSkillUps.ToString() + "\",\"" + record.Value.PortraitGiverDisplayID.ToString() + "\",\"" + record.Value.PortraitTurnInDisplayID.ToString() + "\",\"" + record.Value.RewardFactionID[0].ToString() + "\",\"" + record.Value.RewardFactionValue[0].ToString() + "\",\"" + record.Value.RewardFactionOverride[0].ToString() + "\",\"" + record.Value.RewardFactionID[1].ToString() + "\",\"" + record.Value.RewardFactionValue[1].ToString() + "\",\"" + record.Value.RewardFactionOverride[1].ToString() + "\",\"" + record.Value.RewardFactionID[2].ToString() + "\",\"" + record.Value.RewardFactionValue[2].ToString() + "\",\"" + record.Value.RewardFactionOverride[2].ToString() + "\",\"" + record.Value.RewardFactionID[3].ToString() + "\",\"" + record.Value.RewardFactionValue[3].ToString() + "\",\"" + record.Value.RewardFactionOverride[3].ToString() + "\",\"" + record.Value.RewardFactionID[4].ToString() + "\",\"" + record.Value.RewardFactionValue[4].ToString() + "\",\"" + record.Value.RewardFactionOverride[4].ToString() + "\",\"" + record.Value.RewardFactionFlags.ToString() + "\",\"" + record.Value.RewardCurrencyID[0].ToString() + "\",\"" + record.Value.RewardCurrencyQuantity[0].ToString() + "\",\"" + record.Value.RewardCurrencyID[1].ToString() + "\",\"" + record.Value.RewardCurrencyQuantity[1].ToString() + "\",\"" + record.Value.RewardCurrencyID[2].ToString() + "\",\"" + record.Value.RewardCurrencyQuantity[2].ToString() + "\",\"" + record.Value.RewardCurrencyID[3].ToString() + "\",\"" + record.Value.RewardCurrencyQuantity[3].ToString() + "\",\"" + record.Value.AcceptedSoundKitID.ToString() + "\",\"" + record.Value.CompleteSoundKitID.ToString() + "\",\"" + record.Value.AreaGroupID.ToString() + "\",\"" + record.Value.TimeAllowed.ToString() + "\",\"" + record.Value.NumObjectives.ToString() + "\",\"" + record.Value.RaceFlags.ToString() + "\",\"" + record.Value.Title.ToString() + "\",\"" + record.Value.Summary.ToString() + "\",\"" + record.Value.FullText.ToString() + "\",\"" + record.Value.TrackerText.ToString() + "\",\"" + record.Value.PortraitGiverText.ToString() + "\",\"" + record.Value.PortraitGiverName.ToString() + "\",\"" + record.Value.PortraitTurnInText.ToString() + "\",\"" + record.Value.PortraitTurnInName.ToString() + "\",\"" + record.Value.CompletionBlurb.ToString() + "\"");
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

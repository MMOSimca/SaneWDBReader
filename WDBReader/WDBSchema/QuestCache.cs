﻿using System.Collections.Generic;

namespace WDBReader
{
    class QuestCache
    {
        public int QuestID { get; set; }
        public int QuestType { get; set; }
        public int QuestLevel { get; set; }
        public int B27075_Int1 { get; set; } // Unknown, seems to frequently mirror SuggestedGroupNum (but is more expansive), possibly "maximum party size for LFG tool to delist"
        public int QuestMaxScalingLevel { get; set; }
        public int QuestPackageID { get; set; }
        public int QuestMinLevel { get; set; }
        public int QuestSortID { get; set; }
        public int QuestInfoID { get; set; }
        public int SuggestedGroupNum { get; set; }
        public int RewardNextQuest { get; set; }
        public int RewardXPDifficulty { get; set; }
        public float RewardXPMultiplier { get; set; }
        public int RewardMoney { get; set; }
        public int RewardMoneyDifficulty { get; set; }
        public float RewardMoneyMultiplier { get; set; }
        public int RewardBonusMoney { get; set; }
        public int[] RewardDisplaySpell { get; set; }
        public int RewardSpell { get; set; }
        public int RewardHonorAddition { get; set; } // Gives X Honor - Unused for many years (do any still exist ingame?)
        public float RewardHonorMultiplier { get; set; } // Gives X amount of Honorable kills (Honor gain scales with level this way) - Unused for many years (do any still exist ingame?)
        public int RewardArtifactXPDifficulty { get; set; }
        public float RewardArtifactXPMultiplier { get; set; }
        public int RewardArtifactCategoryID { get; set; }
        public int ProvidedItem { get; set; }
        public uint Flags { get; set; }
        public uint Flags2 { get; set; }
        public uint Flags3 { get; set; }

        // The player gets all of these rewards
        public int[] RewardFixedItemID { get; set; } // size 4
        public int[] RewardFixedItemQuantity { get; set; } // size 4

        // When the quantity of an item listed here goes below the specified amount, the quest is automatically abandoned
        public int[] ItemDropID { get; set; } // size 4
        public int[] ItemDropQuantity { get; set; } // size 4

        // The player must pick only one of these rewards
        public int[] RewardChoiceItemID { get; set; } // size 6
        public int[] RewardChoiceItemQuantity { get; set; } // size 6
        public int[] RewardChoiceItemDisplayID { get; set; } // size 6

        public int POIContinent { get; set; }
        public float POIx { get; set; }
        public float POIy { get; set; }
        public int POIPriority { get; set; }
        public int RewardTitle { get; set; } // Old method of obtaining titles - used only once
        public int RewardTalents { get; set; } // Used literally once (QuestID 1) - doubtful it even works right now
        public int RewardArenaPoints { get; set; } // Unused for many years (do any still exist ingame?)
        public int RewardSkillLineID { get; set; }
        public int RewardNumSkillUps { get; set; }
        public int PortraitGiverDisplayID { get; set; }
        public int BFA_UnkDisplayID { get; set; }
        public int PortraitTurnInDisplayID { get; set; }

        // The specified FactionID gains X rep (where X is either the override amount or the 'value' multiplied by some unknown factor)
        public int[] RewardFactionID { get; set; } // size 5
        public int[] RewardFactionValue { get; set; } // size 5; values used here are small integers that are keys into the columns of QuestFactionReward.db2
        public int[] RewardFactionOverride { get; set; } // size 5; if a value is provided here, it overrides the value provided in the 'Value' field and is used as-is
        public int[] RewardFactionGainMaxRank { get; set; } // size 5; new in Legion build 22053; states the max reputation rank where you can gain reputation from this quest

        public uint RewardFactionFlags { get; set; }

        // The player gets all of the following currency rewards
        public int[] RewardCurrencyID { get; set; } // size 4
        public int[] RewardCurrencyQuantity { get; set; } // size 4

        public int AcceptedSoundKitID { get; set; }
        public int CompleteSoundKitID { get; set; }
        public int AreaGroupID { get; set; }
        public int TimeAllowed { get; set; }
        public int NumObjectives { get; set; }
        public ulong RaceFlags { get; set; }
        /*
        0000 0001: Human
        0000 0002: Orc
        0000 0004: Dwarf
        0000 0008: Night Elf
        0000 0010: Undead
        0000 0020: Tauren
        0000 0040: Troll
        0000 0080: Gnome
        0000 0100: Goblin
        0000 0200: Blood Elf
        0000 0400: Draenei
        0020 0000: Worgen
        0080 0000: ??? (Only entry is an unused test quest)
        0100 0000: Horde Pandaren
        0200 0000: Alliance Pandaren
        */
        public uint QuestRewardID { get; set; }
        public int ExpansionID { get; set; }
        public int ManagedWorldStateID { get; set; }
        public int B31984_Int1 { get; set; }

        public List<QuestObjective> Objectives { get; set; } // size NumObjectives

        public string Title { get; set; }
        public string Summary { get; set; }
        public string FullText { get; set; }
        public string TrackerText { get; set; }
        public string PortraitGiverText { get; set; }
        public string PortraitGiverName { get; set; }
        public string PortraitTurnInText { get; set; }
        public string PortraitTurnInName { get; set; }
        public string CompletionBlurb { get; set; }

        // We store Quest Objective information in a custom structure due to the varying number of entries and large size
        public struct QuestObjective
        {
            public int ID { get; set; }
            public byte Type { get; set; }
            public sbyte StorageIndex { get; set; }
            public int AssetID { get; set; }
            public int Amount { get; set; }
            public uint Flags { get; set; }
            public uint Flags2 { get; set; }
            public float PercentAmount { get; set; }
            public int NumVisualEffects { get; set; } // Technically, it's fine to not store this
            public List<int> VisualEffects { get; set; } // size NumVisualEffects
            //public byte DescriptionLength;
            public string Description { get; set; } // size DescriptionLength
        };

        public QuestCache(DataStore ds, int id)
        {
            QuestID = ds.GetInt();
            QuestType = ds.GetInt();
            QuestLevel = ds.GetInt();
            B27075_Int1 = ds.GetInt();
            QuestMaxScalingLevel = ds.GetInt();
            QuestPackageID = ds.GetInt();
            QuestMinLevel = ds.GetInt();
            QuestSortID = ds.GetInt();
            QuestInfoID = ds.GetInt();
            SuggestedGroupNum = ds.GetInt();
            RewardNextQuest = ds.GetInt();
            RewardXPDifficulty = ds.GetInt();
            RewardXPMultiplier = ds.GetFloat();
            RewardMoney = ds.GetInt();
            RewardMoneyDifficulty = ds.GetInt();
            RewardMoneyMultiplier = ds.GetFloat();
            RewardBonusMoney = ds.GetInt();
            RewardDisplaySpell = new int[3];
            RewardDisplaySpell[0] = ds.GetInt();
            RewardDisplaySpell[1] = ds.GetInt();
            RewardDisplaySpell[2] = ds.GetInt();
            RewardSpell = ds.GetInt();
            RewardHonorAddition = ds.GetInt();
            RewardHonorMultiplier = ds.GetFloat();
            RewardArtifactXPDifficulty = ds.GetInt();
            RewardArtifactXPMultiplier = ds.GetFloat();
            RewardArtifactCategoryID = ds.GetInt();
            ProvidedItem = ds.GetInt();
            Flags = new uint[3];
            Flags = ds.GetUInt();
            Flags2 = ds.GetUInt();
            Flags3 = ds.GetUInt();

            RewardFixedItemID = new int[4];
            RewardFixedItemQuantity = new int[4];
            RewardFixedItemID[0] = ds.GetInt();
            RewardFixedItemQuantity[0] = ds.GetInt();
            RewardFixedItemID[1] = ds.GetInt();
            RewardFixedItemQuantity[1] = ds.GetInt();
            RewardFixedItemID[2] = ds.GetInt();
            RewardFixedItemQuantity[2] = ds.GetInt();
            RewardFixedItemID[3] = ds.GetInt();
            RewardFixedItemQuantity[3] = ds.GetInt();
            
            ItemDropID = new int[4];
            ItemDropQuantity = new int[4];
            ItemDropID[0] = ds.GetInt();
            ItemDropQuantity[0] = ds.GetInt();
            ItemDropID[1] = ds.GetInt();
            ItemDropQuantity[1] = ds.GetInt();
            ItemDropID[2] = ds.GetInt();
            ItemDropQuantity[2] = ds.GetInt();
            ItemDropID[3] = ds.GetInt();
            ItemDropQuantity[3] = ds.GetInt();

            RewardChoiceItemID = new int[6];
            RewardChoiceItemQuantity = new int[6];
            RewardChoiceItemDisplayID = new int[6];
            RewardChoiceItemID[0] = ds.GetInt();
            RewardChoiceItemQuantity[0] = ds.GetInt();
            RewardChoiceItemDisplayID[0] = ds.GetInt();
            RewardChoiceItemID[1] = ds.GetInt();
            RewardChoiceItemQuantity[1] = ds.GetInt();
            RewardChoiceItemDisplayID[1] = ds.GetInt();
            RewardChoiceItemID[2] = ds.GetInt();
            RewardChoiceItemQuantity[2] = ds.GetInt();
            RewardChoiceItemDisplayID[2] = ds.GetInt();
            RewardChoiceItemID[3] = ds.GetInt();
            RewardChoiceItemQuantity[3] = ds.GetInt();
            RewardChoiceItemDisplayID[3] = ds.GetInt();
            RewardChoiceItemID[4] = ds.GetInt();
            RewardChoiceItemQuantity[4] = ds.GetInt();
            RewardChoiceItemDisplayID[4] = ds.GetInt();
            RewardChoiceItemID[5] = ds.GetInt();
            RewardChoiceItemQuantity[5] = ds.GetInt();
            RewardChoiceItemDisplayID[5] = ds.GetInt();

            POIContinent = ds.GetInt();
            POIx = ds.GetFloat();
            POIy = ds.GetFloat();
            POIPriority = ds.GetInt();
            RewardTitle = ds.GetInt();
            //RewardTalents = ds.GetInt();
            RewardTalents = -1;
            RewardArenaPoints = ds.GetInt();
            RewardSkillLineID = ds.GetInt();
            RewardNumSkillUps = ds.GetInt();
            PortraitGiverDisplayID = ds.GetInt();
            BFA_UnkDisplayID = ds.GetInt();
            PortraitTurnInDisplayID = ds.GetInt();

            RewardFactionID = new int[5];
            RewardFactionValue = new int[5];
            RewardFactionOverride = new int[5];
            RewardFactionGainMaxRank = new int[5];
            RewardFactionID[0] = ds.GetInt();
            RewardFactionValue[0] = ds.GetInt();
            RewardFactionOverride[0] = ds.GetInt();
            RewardFactionGainMaxRank[0] = ds.GetInt();
            RewardFactionID[1] = ds.GetInt();
            RewardFactionValue[1] = ds.GetInt();
            RewardFactionOverride[1] = ds.GetInt();
            RewardFactionGainMaxRank[1] = ds.GetInt();
            RewardFactionID[2] = ds.GetInt();
            RewardFactionValue[2] = ds.GetInt();
            RewardFactionOverride[2] = ds.GetInt();
            RewardFactionGainMaxRank[2] = ds.GetInt();
            RewardFactionID[3] = ds.GetInt();
            RewardFactionValue[3] = ds.GetInt();
            RewardFactionOverride[3] = ds.GetInt();
            RewardFactionGainMaxRank[3] = ds.GetInt();
            RewardFactionID[4] = ds.GetInt();
            RewardFactionValue[4] = ds.GetInt();
            RewardFactionOverride[4] = ds.GetInt();
            RewardFactionGainMaxRank[4] = ds.GetInt();

            RewardFactionFlags = ds.GetUInt();

            RewardCurrencyID = new int[4];
            RewardCurrencyQuantity = new int[4];
            RewardCurrencyID[0] = ds.GetInt();
            RewardCurrencyQuantity[0] = ds.GetInt();
            RewardCurrencyID[1] = ds.GetInt();
            RewardCurrencyQuantity[1] = ds.GetInt();
            RewardCurrencyID[2] = ds.GetInt();
            RewardCurrencyQuantity[2] = ds.GetInt();
            RewardCurrencyID[3] = ds.GetInt();
            RewardCurrencyQuantity[3] = ds.GetInt();

            AcceptedSoundKitID = ds.GetInt();
            CompleteSoundKitID = ds.GetInt();
            AreaGroupID = ds.GetInt();
            TimeAllowed = ds.GetInt();
            NumObjectives = ds.GetInt();
            RaceFlags = ds.GetUInt64();
            QuestRewardID = ds.GetUInt();
            ExpansionID = ds.GetInt();
            ManagedWorldStateID = ds.GetInt();
            B31984_Int1 = ds.GetInt();

            // String sizes
            var titleLength = ds.GetIntByBits(9);
            var summaryLength = ds.GetIntByBits(12);
            var textLength = ds.GetIntByBits(12);
            var trackerTextLength = ds.GetIntByBits(9);
            var portraitGiverTextLength = ds.GetIntByBits(10);
            var portraitGiverNameLength = ds.GetIntByBits(8);
            var portraitTurnInTextLength = ds.GetIntByBits(10);
            var portraitTurnInNameLength = ds.GetIntByBits(8);
            var completionBlurbLength = ds.GetIntByBits(11);
            ds.Flush(); // Reset bit position and advance stream position to next byte

            // Populate quest objectives
            Objectives = new List<QuestObjective>();
            for (var i = 0; i < NumObjectives; ++i)
            {
                QuestObjective obj = new QuestObjective();
                obj.ID = ds.GetInt();
                obj.Type = ds.GetByte();
                obj.StorageIndex = (sbyte)ds.GetByte();
                obj.AssetID = ds.GetInt();
                obj.Amount = ds.GetInt();
                obj.Flags = ds.GetUInt();
                obj.Flags2 = ds.GetUInt();
                obj.PercentAmount = ds.GetFloat();

                // You may not want to use this visual effects data, since lists aren't very SQL-compatible and we use this information for literally nothing at the moment.
                obj.NumVisualEffects = ds.GetInt();
                obj.VisualEffects = new List<int>();
                for (var j = 0; j < obj.NumVisualEffects; ++j)
                    obj.VisualEffects.Add(ds.GetInt());

                byte DescriptionLength = ds.GetByte();
                obj.Description = ds.GetString(DescriptionLength);
                Objectives.Add(obj);
            }

            // Strings
            Title = ds.GetString(titleLength);
            Summary = ds.GetString(summaryLength);
            FullText = ds.GetString(textLength);
            TrackerText = ds.GetString(trackerTextLength);
            PortraitGiverText = ds.GetString(portraitGiverTextLength);
            PortraitGiverName = ds.GetString(portraitGiverNameLength);
            PortraitTurnInText = ds.GetString(portraitTurnInTextLength);
            PortraitTurnInName = ds.GetString(portraitTurnInNameLength);
            CompletionBlurb = ds.GetString(completionBlurbLength);
        }
    }
}

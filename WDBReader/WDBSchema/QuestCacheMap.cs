using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class QuestCacheMap : ClassMap<QuestCache>
    {
        public QuestCacheMap()
        {
            Map(m => m.QuestID);
            Map(m => m.QuestType);
            Map(m => m.B27075_Int1);
            Map(m => m.QuestPackageID);
            Map(m => m.QuestSortID);
            Map(m => m.QuestInfoID);
            Map(m => m.SuggestedGroupNum);
            Map(m => m.RewardNextQuest);
            Map(m => m.RewardXPDifficulty);
            Map(m => m.RewardXPMultiplier);
            Map(m => m.RewardMoney);
            Map(m => m.RewardMoneyDifficulty);
            Map(m => m.RewardMoneyMultiplier);
            Map(m => m.RewardBonusMoney);
            Map(m => m.RewardDisplaySpell).Index(14, 16);
            Map(m => m.RewardSpell);
            Map(m => m.RewardHonorAddition);
            Map(m => m.RewardHonorMultiplier);
            Map(m => m.RewardArtifactXPDifficulty);
            Map(m => m.RewardArtifactXPMultiplier);
            Map(m => m.RewardArtifactCategoryID);
            Map(m => m.ProvidedItem);
            Map(m => m.Flags).Index(24, 26);
            Map(m => m.RewardFixedItemID).Index(27, 30);
            Map(m => m.RewardFixedItemQuantity).Index(31, 34);
            Map(m => m.ItemDropID).Index(35, 38);
            Map(m => m.ItemDropQuantity).Index(39, 42);
            Map(m => m.RewardChoiceItemID).Index(43, 48);
            Map(m => m.RewardChoiceItemQuantity).Index(49, 54);
            Map(m => m.RewardChoiceItemDisplayID).Index(55, 60);
            Map(m => m.POIContinent);
            Map(m => m.POIx);
            Map(m => m.POIy);
            Map(m => m.POIPriority);
            Map(m => m.RewardTitle);
            Map(m => m.RewardArenaPoints);
            Map(m => m.RewardSkillLineID);
            Map(m => m.RewardNumSkillUps);
            Map(m => m.PortraitGiverDisplayID);
            Map(m => m.BFA_UnkDisplayID);
            Map(m => m.PortraitTurnInDisplayID);
            Map(m => m.RewardFactionID).Index(72, 76);
            Map(m => m.RewardFactionValue).Index(77, 81);
            Map(m => m.RewardFactionOverride).Index(82, 86);
            Map(m => m.RewardFactionGainMaxRank).Index(87, 91);
            Map(m => m.RewardFactionFlags);
            Map(m => m.RewardCurrencyID).Index(93, 96);
            Map(m => m.RewardCurrencyQuantity).Index(97, 100);
            Map(m => m.AcceptedSoundKitID);
            Map(m => m.CompleteSoundKitID);
            Map(m => m.AreaGroupID);
            Map(m => m.TimeAllowed);
            Map(m => m.NumObjectives);
            Map(m => m.RaceFlags);
            Map(m => m.QuestRewardID);
            Map(m => m.ExpansionID);
            Map(m => m.ManagedWorldStateID);
            Map(m => m.B31984_Int1);
            Map(m => m.NumObjectives);
            //List<QuestObjective>
            Map(m => m.Title);
            Map(m => m.Summary);
            Map(m => m.FullText);
            Map(m => m.TrackerText);
            Map(m => m.PortraitGiverText);
            Map(m => m.PortraitGiverName);
            Map(m => m.PortraitTurnInText);
            Map(m => m.PortraitTurnInName);
            Map(m => m.CompletionBlurb);
        }
    }
}

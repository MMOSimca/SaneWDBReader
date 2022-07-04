using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class QuestCacheMap : ClassMap<QuestCache>
    {
        public QuestCacheMap()
        {
            Map(m => m.QuestID);
            Map(m => m.QuestType);
            Map(m => m.QuestLevel);
            Map(m => m.B27075_Int1);
            Map(m => m.QuestMaxScalingLevel);
            Map(m => m.QuestPackageID);
            Map(m => m.QuestMinLevel);
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
            Map(m => m.RewardDisplaySpell).Index(17, 19);
            Map(m => m.RewardSpell);
            Map(m => m.RewardHonorAddition);
            Map(m => m.RewardHonorMultiplier);
            Map(m => m.RewardArtifactXPDifficulty);
            Map(m => m.RewardArtifactXPMultiplier);
            Map(m => m.RewardArtifactCategoryID);
            Map(m => m.ProvidedItem);
            Map(m => m.Flags).Index(27, 29);
            Map(m => m.RewardFixedItemID).Index(30, 33);
            Map(m => m.RewardFixedItemQuantity).Index(34, 37);
            Map(m => m.ItemDropID).Index(38, 41);
            Map(m => m.ItemDropQuantity).Index(42, 45);
            Map(m => m.RewardChoiceItemID).Index(46, 51);
            Map(m => m.RewardChoiceItemQuantity).Index(52, 57);
            Map(m => m.RewardChoiceItemDisplayID).Index(58, 63);
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
            Map(m => m.RewardFactionID).Index(75, 79);
            Map(m => m.RewardFactionValue).Index(80, 84);
            Map(m => m.RewardFactionOverride).Index(85, 89);
            Map(m => m.RewardFactionGainMaxRank).Index(90, 94);
            Map(m => m.RewardFactionFlags);
            Map(m => m.RewardCurrencyID).Index(96, 99);
            Map(m => m.RewardCurrencyQuantity).Index(100, 103);
            Map(m => m.AcceptedSoundKitID);
            Map(m => m.CompleteSoundKitID);
            Map(m => m.AreaGroupID);
            Map(m => m.TimeAllowed);
            Map(m => m.NumObjectives);
            Map(m => m.RaceFlags);
            Map(m => m.QuestRewardID);
            Map(m => m.ExpansionID);
            Map(m => m.NumObjectives);
            //List<QuestObjective> - see QuestObjectiveMap for further info
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

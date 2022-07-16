using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class QuestCacheMap : ClassMap<QuestCache>
    {
        public QuestCacheMap()
        {
            Map(m => m.QuestID);
            Map(m => m.QuestType);
            Map(m => m.QuestPackageID);
            Map(m => m.ContentTuningID);
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
            Map(m => m.NumRewardDisplaySpells);
            Map(m => m.RewardSpell);
            Map(m => m.RewardHonorAddition);
            Map(m => m.RewardHonorMultiplier);
            Map(m => m.RewardArtifactXPDifficulty);
            Map(m => m.RewardArtifactXPMultiplier);
            Map(m => m.RewardArtifactCategoryID);
            Map(m => m.ProvidedItem);
            Map(m => m.Flags).Index(22, 24);
            Map(m => m.RewardFixedItemID).Index(25, 28);
            Map(m => m.RewardFixedItemQuantity).Index(29, 32);
            Map(m => m.ItemDropID).Index(33, 36);
            Map(m => m.ItemDropQuantity).Index(37, 40);
            Map(m => m.RewardChoiceItemID).Index(41, 46);
            Map(m => m.RewardChoiceItemQuantity).Index(47, 52);
            Map(m => m.RewardChoiceItemDisplayID).Index(53, 58);
            Map(m => m.POIContinent);
            Map(m => m.POIx);
            Map(m => m.POIy);
            Map(m => m.POIPriority);
            Map(m => m.RewardTitle);
            Map(m => m.RewardArenaPoints);
            Map(m => m.RewardSkillLineID);
            Map(m => m.RewardNumSkillUps);
            Map(m => m.PortraitGiverDisplayID);
            Map(m => m.PortraitGiverMountDisplayID);
            Map(m => m.PortraitTurnInDisplayID);
            Map(m => m.PortraitModelSceneID);
            Map(m => m.RewardFactionID).Index(70, 74);
            Map(m => m.RewardFactionValue).Index(75, 79);
            Map(m => m.RewardFactionOverride).Index(80, 84);
            Map(m => m.RewardFactionGainMaxRank).Index(85, 89);
            Map(m => m.RewardFactionFlags);
            Map(m => m.RewardCurrencyID).Index(91, 94);
            Map(m => m.RewardCurrencyQuantity).Index(95, 98);
            Map(m => m.AcceptedSoundKitID);
            Map(m => m.CompleteSoundKitID);
            Map(m => m.AreaGroupID);
            Map(m => m.TimeAllowed);
            Map(m => m.NumObjectives);
            Map(m => m.RaceFlags);
            Map(m => m.QuestRewardID);
            Map(m => m.ExpansionID);
            Map(m => m.ManagedWorldStateID);
            Map(m => m.QuestSessionBonus);
			//List<RewardDisplaySpell>
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

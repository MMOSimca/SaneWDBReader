using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class QuestObjectiveMap : ClassMap<QuestObjective>
    {
        public QuestObjectiveMap()
        {
            Map(m => m.QuestID);
            Map(m => m.ID);
            Map(m => m.Type);
            Map(m => m.StorageIndex);
            Map(m => m.AssetID);
            Map(m => m.Amount);
            Map(m => m.Flags).Index(6, 7);
            Map(m => m.PercentAmount);
            Map(m => m.NumVisualEffects);
            Map(m => m.CombinedVisualEffects);
            Map(m => m.Description);
        }
    }
}

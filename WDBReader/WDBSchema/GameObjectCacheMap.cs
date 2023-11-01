using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class GameObjectCacheMap : ClassMap<GameObjectCache>
    {
        public GameObjectCacheMap()
        {
            Map(m => m.ID);
            Map(m => m.Type);
            Map(m => m.GameObjectDisplayInfoID);
            Map(m => m.Name).Index(3, 6);
            Map(m => m.Icon);
            Map(m => m.Action);
            Map(m => m.Condition);
            Map(m => m.GameData).Index(10, 44);
            Map(m => m.Scale);
            Map(m => m.NumQuestItems);
            //List<int> QuestItems
            Map(m => m.ContentTuningID);
        }
    }
}

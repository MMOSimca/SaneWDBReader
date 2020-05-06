using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class CreatureCacheMap : ClassMap<CreatureCache>
    {
        public CreatureCacheMap()
        {
            Map(m => m.ID);
            Map(m => m.Leader);
            Map(m => m.Name).Index(2, 5);
            Map(m => m.NameAlt).Index(6, 9);
            Map(m => m.Flags).Index(10, 11);
            Map(m => m.CreatureType);
            Map(m => m.CreatureFamily);
            Map(m => m.Classification);
            Map(m => m.ProxyCreatureID).Index(15, 16);
            Map(m => m.NumCreatureDisplays);
            Map(m => m.BFA_Float1);
            Map(m => m.HPMulti);
            Map(m => m.EnergyMulti);
            Map(m => m.NumQuestItems);
            Map(m => m.CreatureMovementInfoID);
            Map(m => m.RequiredExpansion);
            Map(m => m.TrackingQuestID);
            Map(m => m.VignetteID);
            Map(m => m.CreatureClassMask);
            Map(m => m.UIWidgetParentSetID);
            Map(m => m.UnkConditionID);
            Map(m => m.Title);
            Map(m => m.TitleAlt);
            Map(m => m.CursorName);
        }
    }
}

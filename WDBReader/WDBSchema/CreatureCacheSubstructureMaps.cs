using CsvHelper.Configuration;

namespace WDBReader.WDBSchema
{
    sealed class CreatureDisplayMap : ClassMap<CreatureDisplay>
    {
        public CreatureDisplayMap()
        {
            Map(m => m.CreatureID);
            Map(m => m.Index);
            Map(m => m.CreatureDisplayInfoID);
            Map(m => m.Scale);
            Map(m => m.Probability);
        }
    }
}

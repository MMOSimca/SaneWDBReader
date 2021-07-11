using System.Collections.Generic;

namespace WDBReader
{
    class CreatureCache
    {
        public int ID { get; private set; }
        public bool Leader { get; set; }
        public string[] Name { get; set; }
        public string[] NameAlt { get; set; }
        public uint[] Flags { get; set; }
        public int CreatureType { get; private set; }
        public int CreatureFamily { get; private set; }
        public int Classification { get; private set; }
        // Used mainly to tie many different mobs to a single CreatureID kill credit.
        // Often, the proxy's CreatureCache data won't even be sent by the server, meaning some CreatureIDs will only exist in this field.
        public int[] ProxyCreatureID { get; set; }
        public int NumCreatureDisplays { get; set; }
        public float TotalProbability { get; set; }
        public List<CreatureDisplay> CreatureDisplays { get; set; }
        public float HPMultiplier { get; private set; }
        public float EnergyMultiplier { get; private set; }
        public int NumQuestItems { get; set; }
        public List<int> QuestItems { get; set; }
        public int CreatureMovementInfoID { get; set; }
        public int RequiredExpansion { get; set; }
        // Now only used if VignetteID is 0, since if VignetteID is present, they can just lookup Vignette::TrackingQuestID
        public int TrackingQuestID { get; set; }
        public int VignetteID { get; set; }
        // Some type of 'creature class type' expressed as a bitfield (2^ID); 1 = Warrior, 2 = Rogue, 8 = Caster or something like that
        public int CreatureClassMask { get; set; }
        // Added in Patch 9.1.0, exact build unknown
        public int CreatureDifficultyID { get; set; }
        // Added in Build 28202?
        // Some kind of FK ID field only relevant to 'bodyguard-like' creatures that have friendship reputations
        public int UIWidgetParentSetID { get; set; }
        // Added in Patch 9.0.1, exact build unknown
        // Only used once, for the Nazjatar bodyguard-like' creatures; that value is 4171 - possibly CombatConditionID
        public int UIWidgetSetUnitConditionID { get; set; }
        public string Title { get; private set; }
        public string TitleAlt { get; private set; }
        public string CursorName { get; private set; }

        public struct CreatureDisplay
        {
            public int CreatureDisplayInfoID { get; set; }
            public float Scale { get; set; }
            public float Probability { get; set; }
        }

        public CreatureCache(DataStore ds, int id)
        {
            ID = id;

            var titleLength = ds.GetIntByBits(11);
            var titleAltLength = ds.GetIntByBits(11);
            var cursorNameLength = ds.GetIntByBits(6);
            Leader = ds.GetBool();
            var name0Length = ds.GetIntByBits(11);
            var nameAlt0Length = ds.GetIntByBits(11);
            var name1Length = ds.GetIntByBits(11);
            var nameAlt1Length = ds.GetIntByBits(11);
            var name2Length = ds.GetIntByBits(11);
            var nameAlt2Length = ds.GetIntByBits(11);
            var name3Length = ds.GetIntByBits(11);
            var nameAlt3Length = ds.GetIntByBits(11);
            ds.Flush();

            Name = new string[4];
            NameAlt = new string[4];
            Name[0] = ds.GetString(name0Length);
            NameAlt[0] = ds.GetString(nameAlt0Length);
            Name[1] = ds.GetString(name1Length);
            NameAlt[1] = ds.GetString(nameAlt1Length);
            Name[2] = ds.GetString(name2Length);
            NameAlt[2] = ds.GetString(nameAlt2Length);
            Name[3] = ds.GetString(name3Length);
            NameAlt[3] = ds.GetString(nameAlt3Length);
            Flags = new uint[2]
            {
                ds.GetUInt(),
                ds.GetUInt(),
            };
            CreatureType = ds.GetInt();
            CreatureFamily = ds.GetInt();
            Classification = ds.GetInt();
            ProxyCreatureID = new int[2]
            {
                ds.GetInt(),
                ds.GetInt(),
            };

            NumCreatureDisplays = ds.GetInt();
            TotalProbability = ds.GetFloat();
            CreatureDisplays = new List<CreatureDisplay>();
            for (var i = 0; i < NumCreatureDisplays; ++i)
            {
                CreatureDisplay cd = new CreatureDisplay();
                cd.CreatureDisplayInfoID = ds.GetInt();
                cd.Scale = ds.GetFloat();
                cd.Probability = ds.GetFloat();
                CreatureDisplays.Add(cd);
            }

            HPMultiplier = ds.GetFloat();
            EnergyMultiplier = ds.GetFloat();
            NumQuestItems = ds.GetInt();
            CreatureMovementInfoID = ds.GetInt();
            RequiredExpansion = ds.GetInt();
            TrackingQuestID = ds.GetInt();
            VignetteID = ds.GetInt();
            CreatureClassMask = ds.GetInt();
            CreatureDifficultyID = ds.GetInt();
            UIWidgetParentSetID = ds.GetInt();
            UIWidgetSetUnitConditionID = ds.GetInt();

            Title = ds.GetString(titleLength);
            TitleAlt = ds.GetString(titleAltLength);
            if (cursorNameLength != 1)
                CursorName = ds.GetString(cursorNameLength);
            else
                CursorName = "";

            QuestItems = new List<int>();
            for (var i = 0; i < NumQuestItems; i++)
            {
                QuestItems.Add(ds.GetInt());
            }
        }
    }
}

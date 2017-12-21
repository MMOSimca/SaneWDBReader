using System.Collections.Generic;

namespace WDBReader
{
    class CreatureCache
    {
        public string Title { get; private set; }
        public string TitleAlt { get; private set; }
        public string CursorName { get; private set; }
        public int CreatureType { get; private set; }
        public int CreatureFamily { get; private set; }
        public int Classification { get; private set; }
        public float HPMulti { get; private set; }
        public float EnergyMulti { get; private set; }
        public bool Leader { get; set; }
        public List<int> QuestItems { get; set; }
        public int CreatureMovementInfoID { get; set; }
        public int UNK_ExpansionID { get; set; }
        public int RequiredExpansion { get; set; }
        public int VignetteID { get; set; }
        public uint[] Flags { get; set; }
        public int[] ProxyCreatureID { get; set; }
        public int[] CreatureDisplayID { get; set; }
        public string[] Name { get; set; }
        public string[] NameAlt { get; set; }

        public CreatureCache(DataStore ds)
        {
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
            CreatureDisplayID = new int[4]
            {
                ds.GetInt(),
                ds.GetInt(),
                ds.GetInt(),
                ds.GetInt(),
            };
            HPMulti = ds.GetFloat();
            EnergyMulti = ds.GetFloat();
            var numQuestItems = ds.GetInt();
            CreatureMovementInfoID = ds.GetInt();
            UNK_ExpansionID = ds.GetInt();
            RequiredExpansion = ds.GetInt();
            VignetteID = ds.GetInt();

            Title = ds.GetString(titleLength);
            TitleAlt = ds.GetString(titleAltLength);
            if (cursorNameLength != 1)
                CursorName = ds.GetString(cursorNameLength);
            else
                CursorName = "";

            QuestItems = new List<int>();
            for (var i = 0; i < numQuestItems; i++)
            {
                QuestItems.Add(ds.GetInt());
            }
        }
    }
}

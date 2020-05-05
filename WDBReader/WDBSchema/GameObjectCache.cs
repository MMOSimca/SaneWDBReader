using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace WDBReader
{
    class GameObjectCache
    {
        public int ID { get; private set; }
        public int Type { get; private set; }
        public int GameObjectDisplayInfoID { get; private set; }
        public string[] Name { get; private set; }
        public string Icon { get; private set; }
        public string Action { get; private set; }
        public string Condition { get; private set; }
        public int[] GameData { get; private set; }
        public float Scale { get; private set; }
        public byte NumQuestItems { get; private set; }
        [Ignore]
        public List<int> QuestItems { get; private set; }
        public int ContentTuningID { get; private set; }

        public GameObjectCache(DataStore ds, int id)
        {
            ID = id;

            Type = ds.GetInt();
            GameObjectDisplayInfoID = ds.GetInt();

            Name = new string[4];
            Name[0] = ds.GetCString();
            Name[1] = ds.GetCString();
            Name[2] = ds.GetCString();
            Name[3] = ds.GetCString();
            Icon = ds.GetCString();
            Action = ds.GetCString();
            Condition = ds.GetCString();

            GameData = new int[34];
            for (int i = 0; i < GameData.Length; ++i)
            {
                GameData[i] = ds.GetInt();
            }

            Scale = ds.GetFloat();
            NumQuestItems = ds.GetByte();

            QuestItems = new List<int>();
            for (int i = 0; i < NumQuestItems; ++i)
            {
                QuestItems.Add(ds.GetInt());
            }

            ContentTuningID = ds.GetInt();
        }
    }
}

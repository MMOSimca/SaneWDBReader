namespace WDBReader
{
    class GameObjectCache
    {
        public int Category { get; private set; }
        public int Model { get; private set; }
        public string[] Name { get; private set; }
        public string Icon { get; private set; }
        public string Action { get; private set; }
        public string Unk { get; private set; }

        public GameObjectCache(DataStore ds)
        {
            Category = ds.GetInt();
            Model = ds.GetInt();
            Name = new string[4];
            Name[0] = ds.GetCString();
            Name[1] = ds.GetCString();
            Name[2] = ds.GetCString();
            Name[3] = ds.GetCString();
            Icon = ds.GetCString();
            Action = ds.GetCString();
            Unk = ds.GetCString();
        }
    }
}

using System.Collections.Generic;

// We store Quest Objective information in a custom structure due to the varying number of entries and large size
// This is a structure only used inside QuestCache
public struct QuestObjective
{
    public int QuestID { get; set; } // This doesn't exist in the original structure, we're just setting it for convenience
    public int ID { get; set; }
    public byte Type { get; set; }
    public sbyte StorageIndex { get; set; }
    public int AssetID { get; set; }
    public int Amount { get; set; }
    public uint[] Flags { get; set; }
    public float PercentAmount { get; set; }
    public int NumVisualEffects { get; set; } // Technically, it's fine to not store this
    public List<int> VisualEffects { get; set; } // size NumVisualEffects
                                                 //public byte DescriptionLength;
    public string Description { get; set; } // size DescriptionLength
    
    public string CombinedVisualEffects
    {
        get { return string.Join(";", VisualEffects); }
    }
};

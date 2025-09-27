using System.Collections.Generic;

namespace WDBReader
{
    // We store Creature Display information in a custom structure due to the varying number of entries
    // This is a structure only used inside CreatureCache
    public struct CreatureDisplay
    {
        public int CreatureID { get; set; } // This doesn't exist in the original structure, we're just setting it for convenience
        public int Index { get; set; } // 1-based; this doesn't exist in the original structure, we're just setting it for convenience
        public int CreatureDisplayInfoID { get; set; }
        public float Scale { get; set; }
        public float Probability { get; set; }
    }
}

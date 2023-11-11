namespace JsonLib.Classes.InventoryRelated
{
    public class InventoryContainer
    {
        public Stash Stash;
        public Lookup Lookup;
    }

    public class Lookup
    {
        public Dictionary<string, int> Forward;
        public Dictionary<int, string> Reverse;
    }

    public class Stash
    {
        public string SlotId;
        public Map Container;
    }

    public class Map
    {
        public int Width;
        public int Height;
        public List<string> ContainerMap;
        public Dictionary<string, FlatMapLookup> FlatMap;
    }

    public class FlatMapLookup
    {
        public int Width;
        public int Height;
        public int StartX;
        public int EndX;
        public List<int> Coordinates;
    }
}

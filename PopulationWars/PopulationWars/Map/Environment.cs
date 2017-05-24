namespace PopulationWars.Map
{
    public class Environment
    {
        public Tile[][] Map { get; }
        public int Size { get; }

        public Environment(Tile[][] worldMapSlice, int size)
        {
            Map = worldMapSlice;
            Size = size;
        }
    }
}

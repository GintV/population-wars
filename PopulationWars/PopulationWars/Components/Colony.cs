using PopulationWars.Map;

namespace PopulationWars.Components
{
    public class Colony
    {
        public Nation Nation { get; set; }
        public Tile Tile { get; set; }
        public int Population { get; set; }

        public Colony(Nation nation, Tile tile, int population)
        {
            Nation = nation;
            Tile = tile;
            Population = population;
        }
    }
}
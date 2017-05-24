using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PopulationWars.Components;
using PopulationWars.Map;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Mechanics
{
    public class Player
    {
        public string Name { get; set; }
        public bool IsAgent { get; set; }
        public Nation Nation { get; set; }
        public List<Colony> Colonies { get; set; }
        public Color Color { get; set; }

        public Player(string name, bool isAgent, Nation nation, Color color)
        {
            Name = name;
            IsAgent = isAgent;
            Nation = nation;
            Colonies = new List<Colony>();
            Color = color;
        }

        public void CreateColony(Tile tile, int population)
        {
            var colony = new Colony(Nation, tile, population);
            tile.OwnedBy = colony;
            Colonies.Add(colony);
        }

        public void DestroyColony(Tile tile)
        {
            Colonies.Remove(Colonies.Where(colony => colony.Tile == tile).First());
            tile.OwnedBy = null;
        }

        public void MoveToColony(Tile tile, int population)
        {
            var colony = Colonies.Where(c => c.Tile == tile).First();
            colony.Population += population;
            if (colony.Population > MaximumPopulationInColony)
                colony.Population = MaximumPopulationInColony;
        }

        public override string ToString() =>
            $"{Name} ({(IsAgent ? Agent : Human)}), {Nation}";
    }
}

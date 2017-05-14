using System.Collections.Generic;
using System.Drawing;
using PopulationWars.Components;

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

        public override string ToString() =>
            $"{Name} ({(IsAgent ? Agent : Human)}), {Nation}"; 
    }
}

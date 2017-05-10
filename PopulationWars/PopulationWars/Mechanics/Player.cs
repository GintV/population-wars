using PopulationWars.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Mechanics
{
    class Player
    {
        public string Name { get; set; }
        public Nation Nation { get; set; }
        public List<Colony> Colonies { get; set; }

        public Color Color { get; set; }

        public Player(string name, Nation nation = null, string nationName = null)
        {
            Name = name;
            Nation = nation ?? new Nation(nationName);
            Colonies = new List<Colony>();
        }
    }
}

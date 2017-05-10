using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    public class Colony
    {
        public Nation Nation { get; set; }
        public int Population { get; set; }

        public Colony(Nation nation, int population)
        {
            Nation = nation;
            Population = population;
        }
    }
}
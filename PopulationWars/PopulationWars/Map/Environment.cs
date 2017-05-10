using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Map
{
    class Environment
    {
        private Tile[][] Map;

        public Environment(Tile[][] worldMapSlice)
        {
            Map = worldMapSlice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    public class Nation
    {
        public string Name { get; set; }
        public Government Government { get; set; }

        public Nation(string name, Government government = null)
        {
            Name = name;
            Government = government ?? new Government();
        }
    }
}
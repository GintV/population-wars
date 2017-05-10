using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PopulationWars.Components.Direction;

namespace PopulationWars.Components
{
    public class Desicion
    {
        public bool IsLeaving { get; }
        public Direction Direction { get; }
        public double? PopulationToMove { get; }

        public Desicion(bool isLeaving, Direction direction = None,
            double? populationToMove = null)
        {
            IsLeaving = isLeaving;
            Direction = direction;
            PopulationToMove = populationToMove;
        }
    }
}

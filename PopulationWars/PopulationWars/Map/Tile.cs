using PopulationWars.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Map
{
    public class Tile
    {
        public readonly Tuple<int, int> Position;
        public Colony OwnedBy { get; set; }

        public bool IsEmpty { get { return OwnedBy == null; } }
        public bool IsColonized { get { return !IsEmpty; } }
        public readonly bool IsWall;

        public Tile(Tuple<int, int> position, bool isWall)
        {
            IsWall = isWall;
            OwnedBy = null;
            Position = position;
        }
    }
}

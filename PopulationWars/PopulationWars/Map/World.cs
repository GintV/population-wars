using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopulationWars.Utilities;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Map
{
    class World
    {
        public readonly Tile[][] Map;

        public World()
        {
            var scope = Settings.GameSettings.ColonyScope;

            Map = Enumerable.Range(0, DefaultWorldHeight + 2 * scope).
                Select(y => Enumerable.Range(0, DefaultWorldWidth + 2 * scope).
                Select(x => (x - scope >= 0 && x - scope < DefaultWorldWidth &&
                y - scope >= 0 && y - scope < DefaultWorldHeight) ?
                new Tile(Tuple.Create(x, y), false) : new Tile(null, true)).ToArray()).ToArray();
        }

        public Environment GetEnvironment(Tile tile)
        {
            var x = tile.Position.Item1;
            var y = tile.Position.Item2;
            var scope = Settings.GameSettings.ColonyScope;

            var slice = Map.Skip(y - scope).Take(2 * scope + 1).
                Select(s => s.Skip(x - scope).Take(2 * scope + 1).ToArray()).ToArray();

            return new Environment(slice);
        }
    }
}

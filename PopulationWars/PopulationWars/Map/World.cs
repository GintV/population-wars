using System;
using System.Linq;
using PopulationWars.Utilities;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Map
{
    public class World
    {
        private int m_colonyScope;

        public readonly Tile[][] Map;

        public World(Settings settings)
        {
            m_colonyScope = settings.ColonyScope;

            Map = Enumerable.Range(0, DefaultWorldHeight + 2 * m_colonyScope).
                Select(y => Enumerable.Range(0, DefaultWorldWidth + 2 * m_colonyScope).
                Select(x => (x - m_colonyScope >= 0 && x - m_colonyScope < DefaultWorldWidth &&
                y - m_colonyScope >= 0 && y - m_colonyScope < DefaultWorldHeight) ?
                new Tile(Tuple.Create(x, y), false) : new Tile(null, true)).ToArray()).ToArray();
        }

        public Environment GetEnvironment(Tile tile)
        {
            var x = tile.Position.Item1;
            var y = tile.Position.Item2;

            var slice = Map.Skip(y - m_colonyScope).Take(2 * m_colonyScope + 1).
                Select(s => s.Skip(x - m_colonyScope).Take(2 * m_colonyScope + 1).
                ToArray()).ToArray();

            return new Environment(slice);
        }
    }
}

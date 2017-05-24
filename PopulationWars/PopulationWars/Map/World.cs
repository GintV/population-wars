using System;
using System.Linq;
using PopulationWars.Components;
using PopulationWars.Utilities;

using static PopulationWars.Components.Direction;
using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Map
{
    public class World
    {
        private int m_colonyScope;
        private int m_worldHeight;
        private int m_worldWidth;

        public readonly Tile[][] Map;

        public World(Settings settings)
        {
            m_colonyScope = settings.ColonyScope;
            m_worldHeight = settings.WorldSize.Item2;
            m_worldWidth = settings.WorldSize.Item1;
            Map = CreateMap();
        }

        public Environment GetEnvironment(Tile tile)
        {
            var n = tile.Position.Item2;
            var m = tile.Position.Item1;

            var slice = Map.Skip(n).Take(2 * m_colonyScope + 1).
                Select(s => s.Skip(m).Take(2 * m_colonyScope + 1).ToArray()).ToArray();

            return new Environment(slice, m_colonyScope);
        }

        public Tile GetNeighbourTile(Tile tile, Direction direction)
        {
            var n = tile.Position.Item2 + m_colonyScope;
            var m = tile.Position.Item1 + m_colonyScope;

            switch (direction)
            {
                case Up:
                    return Map[n - 1][m];
                case UpRight:
                    return Map[n - 1][m + 1];
                case Right:
                    return Map[n][m + 1];
                case DownRight:
                    return Map[n + 1][m + 1];
                case Down:
                    return Map[n + 1][m];
                case DownLeft:
                    return Map[n + 1][m - 1];
                case Left:
                    return Map[n][m - 1];
                case UpLeft:
                    return Map[n - 1][m - 1];
                default:
                    return Map[n][m];
            }
        }

        public Tile GetRandomEmptyTile()
        {
            var random = new Random();
            var n = m_worldHeight + 2 * m_colonyScope;
            var m = m_worldWidth + 2 * m_colonyScope;

            var tile = Map.ElementAt(random.Next(n)).ElementAt(random.Next(m));
            while(tile.IsWall || tile.IsColonized)
                tile = Map.ElementAt(random.Next(n)).ElementAt(random.Next(m));

            return tile;
        }

        public void ResetMap() =>
            Map.ToList().ForEach(row => row.ToList().ForEach(element => element.OwnedBy = null));

        private Tile[][] CreateMap() =>
            Enumerable.Range(-m_colonyScope, m_worldHeight + 2 * m_colonyScope).
                Select(y => Enumerable.Range(-m_colonyScope, m_worldWidth + 2 * m_colonyScope).
                Select(x => (x >= 0 && x < m_worldWidth && y >= 0 && y < m_worldHeight) ?
                new Tile(Tuple.Create(x, y), false) : new Tile(null, true)).ToArray()).ToArray();
    }
}

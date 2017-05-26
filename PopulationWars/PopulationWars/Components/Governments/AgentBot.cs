using System;
using PopulationWars.Map;
using PopulationWars.Mechanics;
using static PopulationWars.Components.Direction;


namespace PopulationWars.Components.Governments
{
    [Serializable]
    public class AgentBot : IGovernment
    {
        private Tile[][] m_map;
        private int m_colonyScope;
        private int m_xc;
        private int m_yc;

        public Decision MakeDecision(Situation situation)
        {
            if (situation.ColonyPopulation < 10)
                return new Decision();

            var env = m_map = situation.Environment.Map;
            var size = m_colonyScope = situation.Environment.Size;
            var me = env[size][size];

            m_xc = me.Position.Item2 - size;
            m_yc = me.Position.Item1 - size;

            for (var i = 0; i < 3; ++i)
            {
                if (GetNeighbourTile(me, UpRight, i).IsEmpty && !GetNeighbourTile(me, UpRight, i).IsWall)
                    return new Decision(true, UpRight, 0.5);

                if (GetNeighbourTile(me, UpLeft, i).IsEmpty && !GetNeighbourTile(me, UpLeft, i).IsWall)
                    return new Decision(true, UpLeft, 0.5);

                if (GetNeighbourTile(me, DownRight, i).IsEmpty && !GetNeighbourTile(me, DownRight, i).IsWall)
                    return new Decision(true, DownRight, 0.5);

                if (GetNeighbourTile(me, DownLeft, i).IsEmpty && !GetNeighbourTile(me, DownLeft, i).IsWall)
                    return new Decision(true, DownLeft, 0.5);

                if (GetNeighbourTile(me, Up, i).IsEmpty && !GetNeighbourTile(me, Up, i).IsWall)
                    return new Decision(true, Up, 0.5);

                if (GetNeighbourTile(me, Right, i).IsEmpty && !GetNeighbourTile(me, Right, i).IsWall)
                    return new Decision(true, Right, 0.5);

                if (GetNeighbourTile(me, Down, i).IsEmpty && !GetNeighbourTile(me, Down, i).IsWall)
                    return new Decision(true, Down, 0.5);

                if (GetNeighbourTile(me, Left, i).IsEmpty && !GetNeighbourTile(me, Left, i).IsWall)
                    return new Decision(true, Left, 0.5);
            }

            Random random = new Random();
            return new Decision(random.NextDouble() > 0.5 ? true : false,
                (Direction)((((int)(random.NextDouble() * 100) % 9)) + 1), random.NextDouble());

        }

        public Tile GetNeighbourTile(Tile tile, Direction direction, int i)
        {
            switch (i)
            {
                case 0:
                    return GetNeighbourTile(tile, direction);
                case 1:
                    return GetNeighbourTile(GetNeighbourTile(tile, direction), direction);
                default:
                    return GetNeighbourTile(GetNeighbourTile(GetNeighbourTile(tile, direction), direction), direction);
            }
        }


        public  Tile GetNeighbourTile(Tile tile, Direction direction)
        {
            if (tile.IsWall)
                return tile;

            var n = tile.Position.Item2 - m_xc;
            var m = tile.Position.Item1 - m_yc;

            switch (direction)
            {
                case Up:
                    return m_map[n - 1][m];
                case UpRight:
                    return m_map[n - 1][m + 1];
                case Right:
                    return m_map[n][m + 1];
                case DownRight:
                    return m_map[n + 1][m + 1];
                case Down:
                    return m_map[n + 1][m];
                case DownLeft:
                    return m_map[n + 1][m - 1];
                case Left:
                    return m_map[n][m - 1];
                case UpLeft:
                    return m_map[n - 1][m - 1];
                default:
                    return m_map[n][m];
            }
        }

        public void Train(TrainSet trainSet)
        {
            // AgentBot no need to train
        }

        public object Clone() => new AgentBot();

        public override string ToString() => "AgentBot";

    }
}

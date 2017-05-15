using static PopulationWars.Components.Direction;

namespace PopulationWars.Components
{
    public class Decision
    {
        public bool IsLeaving { get; }
        public Direction Direction { get; }
        public double? PopulationToMove { get; }

        public Decision(bool isLeaving, Direction direction = None,
            double? populationToMove = null)
        {
            IsLeaving = isLeaving;
            Direction = direction;
            PopulationToMove = populationToMove;
        }
    }
}

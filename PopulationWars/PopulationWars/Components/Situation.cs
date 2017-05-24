using PopulationWars.Map;

namespace PopulationWars.Components
{
    [System.Serializable]
    public class Situation
    {
        public int ColonyPopulation { get; }
        public int NationColoniesCount { get; }
        public Environment Environment { get; }
        public int MinTurns { get; }
        public int MaxTurns { get; }
        public int CurrentTurn { get; }

        public Situation(int colonyPopulation, int nationColoniesCount,
            Environment environment, int minTurns, int maxTurns, int currentTurn)
        {
            ColonyPopulation = colonyPopulation;
            NationColoniesCount = nationColoniesCount;
            Environment = environment;
            MinTurns = minTurns;
            MaxTurns = maxTurns;
            CurrentTurn = currentTurn;
        }
    }
}

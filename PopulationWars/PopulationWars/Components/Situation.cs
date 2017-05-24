using PopulationWars.Map;

namespace PopulationWars.Components
{
    public class Situation
    {
        public int ColonyPopulation { get; }
        public int NationColoniesCount { get; }
        public Environment Environment { get; }
        public double TurnsEvalutation { get; }

        public Situation(int colonyPopulation, int nationColoniesCount,
            Environment environment, double turnsEvalutation)
        {
            ColonyPopulation = colonyPopulation;
            NationColoniesCount = nationColoniesCount;
            Environment = environment;
            TurnsEvalutation = turnsEvalutation;
        }
    }
}

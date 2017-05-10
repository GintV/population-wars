using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    public class Situation
    {
        public int ColonyPopulation { get; }
        public int NationColoniesCount { get; }
        public double EnvironmentEvaluation { get; }

        public Situation(int colonyPopulation, int nationColoniesCount,
            double environmentEvaluation)
        {
            ColonyPopulation = colonyPopulation;
            NationColoniesCount = nationColoniesCount;
            EnvironmentEvaluation = environmentEvaluation;
        }
    }
}

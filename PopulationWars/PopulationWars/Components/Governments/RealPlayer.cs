using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopulationWars.Components;
using PopulationWars.Mechanics;

namespace PopulationWars.Components.Governments
{
    /*
     * Class that allows human players to communication with MovesControllers.
     */
    [Obsolete]
    public class RealPlayer : IGovernment
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public Decision MakeDecision(Situation situation)
        {
            throw new NotImplementedException();
        }

        public void Train(TrainSet trainSet)
        {
            throw new NotImplementedException();
        }
    }
}

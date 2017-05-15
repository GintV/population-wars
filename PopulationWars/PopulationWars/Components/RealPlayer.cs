using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    /*
     * Class that allows human players to communication with MovesControllers.
     */
    public class RealPlayer : IGovernment
    {
        public Decision MakeDecision(Situation situation)
        {
            throw new NotImplementedException();
        }
    }
}

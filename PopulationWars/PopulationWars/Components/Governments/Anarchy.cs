using System;
using PopulationWars.Mechanics;

namespace PopulationWars.Components.Governments
{
    [Serializable]
    public class Anarchy : IGovernment
    {
        public Decision MakeDecision(Situation situation)
        {
            Random random = new Random();
            return new Decision(random.NextDouble() > 0.5 ? true : false,
                (Direction)((((int)(random.NextDouble() * 100) % 9)) + 1), random.NextDouble());
        }

        public void Train(TrainSet trainSet)
        {
            // Random will stay forever random
        }

        public object Clone() => new Anarchy();

        public override string ToString() => "Democracy";

    }
}

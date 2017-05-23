using PopulationWars.Mechanics;
using System;

namespace PopulationWars.Components.Governments
{
    /*
     * Interface for entities that can make moves in games
     */
    public interface IGovernment : ICloneable
    {

        void Train(TrainSet trainSet);
        Decision MakeDecision(Situation situation);
    }
}
using PopulationWars.Components;
using System;
using System.Collections.Generic;

namespace PopulationWars.Mechanics
{
    [Serializable]
    public class TrainSet
    {
        public TrainSet()
        {
            Situation = new List<Situation>();
            Decision = new List<Decision>();
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Situation> Situation { get; set; }
        public List<Decision> Decision { get; set; }

        public override string ToString() => Name + Date;
    }
}

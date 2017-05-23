using PopulationWars.Components;
using System.Collections.Generic;

namespace PopulationWars.Mechanics
{
    public class TrainSet
    {
        public string Name { get; set; }
        public List<Situation> Situation { get; set; }
        public List<Decision> Decision { get; set; }

        public override string ToString() => Name;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    class InputLayer : NeuralLayer
    {
        public InputLayer(int size, Func<double, double> activationFunc, Func<double, double> activationDerivative) : base(size, 1, activationFunc, activationDerivative)
        {
        }

        public override double[] Transform(double[] inputs)
        {
            var results = new List<double>(inputs.Length);
            results.AddRange(Neurons.Select((t, i) => t.Calculate(new[] { inputs[i] })));
            return results.ToArray();
        }
    }
}

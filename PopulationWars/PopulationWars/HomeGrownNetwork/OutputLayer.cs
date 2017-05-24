using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    class OutputLayer : NeuralLayer
    {
        public OutputLayer(int size, int inputCount) : base(size, inputCount, null)
        {
        }

        public override double[] Transform(double[] inputs)
        {
            var results = new List<double>(inputs.Length);
            results.AddRange(Neurons.Select(neuron => neuron.Calculate(inputs)));
            var expSum = results.Sum(x => Math.Exp(x));
            return results.Select(x => Math.Exp(x) / expSum).ToArray();
        }
    }
}

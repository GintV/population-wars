using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    [Serializable]
    class OutputLayer : NeuralLayer
    {
        public OutputLayer(int size, int inputCount) : base(size, inputCount, null, null)
        {
        }

        public override double[] Transform(double[] inputs)
        {
            var results = new List<double>(inputs.Length);
            results.AddRange(Neurons.Select(neuron => neuron.Calculate(inputs)));
            var expSum = results.Sum(x => Math.Exp(x));
            return results.Select(x => Math.Exp(x) / expSum).ToArray();
        }

        public override double[] BackPropagate(double[] reversedOutputs, double[] receivedInputs)
        {
            var results = new double[receivedInputs.Length];
            for (var i = 0; i < receivedInputs.Length; i++)
            {
                for (var k = 0; k < reversedOutputs.Length; k++)
                {
                    results[i] += reversedOutputs[k] * Neurons[k].Weights[i];
                }
            }
            return results;
        }

        public double[] ReverseActivation(double[] givenOutputs, double[] reversedOutputs)
        {
            var results = givenOutputs;
            for (var i = 0; i < Size; i++)
            {
                results[i] -= reversedOutputs[i];
            }
            return results;
        }

    }
}

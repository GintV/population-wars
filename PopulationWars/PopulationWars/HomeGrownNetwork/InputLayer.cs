using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    [Serializable]
    class InputLayer : NeuralLayer
    {
        public InputLayer(int size, Func<double, double> activationFunc, Func<double, double> activationDerivative) : base(size, 1, activationFunc, activationDerivative)
        {
        }

        public override double[] Transform(double[] inputs)
        {
            /*
            var results = new List<double>(inputs.Length);
            results.AddRange(Neurons.Select((t, i) => t.Calculate(new[] { inputs[i] })));
            return results.ToArray();
            */
            return inputs;
        }

        public override double[] BackPropagate(double[] reversedOutputs, double[] receivedInputs)
        {
            /*
            var results = new double[receivedInputs.Length];
            for (var i = 0; i < receivedInputs.Length; i++)
            {
                results[i] = reversedOutputs[i] * Neurons[i].Weights[0] * (1 - ActivationDerivative(receivedInputs[i]));
            }
            return results;*/
            return receivedInputs;
        }
    }
}

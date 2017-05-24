using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    class NeuralLayer
    {
        public int Size { get; }
        protected List<Neuron> Neurons;
        private readonly Func<double, double> m_activationFunc;
        public NeuralLayer(int size, int inputCount, Func<double, double> activationFunc)
        {
            Size = size;
            m_activationFunc = activationFunc;
            Neurons = new List<Neuron>(size);
            for (var i = 0; i < size; i++)
            {
                Neurons.Add(new Neuron(inputCount));
            }
        }

        public virtual double[] Transform(double[] inputs)
        {
            var results = new List<double>(inputs.Length);
            results.AddRange(Neurons.Select(neuron => neuron.Calculate(inputs)).Select(m_activationFunc));
            return results.ToArray();
        }

        public void AlterParameters(double[][] deltaWeights, double[] deltaBiases)
        {
            for (var i = 0; i < Neurons.Count; i++)
            {
                Neurons[i].AlterWeights(deltaWeights[i], deltaBiases[i]);
            }
        }

        public double[] BackPropogate(double[] givenOutputs, double[] reversedOutputs)
        {
            var results = new double[Size];
            for (var i = 0; i < Size; i++)
            {
                for (var k = 0; k < Size; k++)
                {
                    results[i] += reversedOutputs[i] * Neurons[i].Weights[k];
                }
                results[i] *= 1 - Math.Pow(givenOutputs[i], 2);
            }
            return results;
        }
    }
}

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
        private readonly Func<double, double> m_activationDerivative;
        public NeuralLayer(int size, int inputCount, Func<double, double> activationFunc, Func<double, double> activationDerivative)
        {
            Size = size;
            m_activationFunc = activationFunc;
            m_activationDerivative = activationDerivative;
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

        public virtual double[] BackPropagate(double[] givenOutputs, double[] reversedOutputs)
        {
            var results = new double[Size];
            for (var i = 0; i < Size; i++)
            {
                foreach (double w in Neurons[i].Weights)
                {
                    results[i] += reversedOutputs[i] * w;
                }
                results[i] *= 1 - m_activationDerivative(reversedOutputs[i]);
            }
            return results;
        }

        public Tuple<double[][], double[]> CalculateDeltas(double[] givenOutputs, double[] reversedOutputs, double learningRate)
        {
            var dW = new double[Size][];
            var dB = new double[Size];
            for (var i = 0; i < Size; i++)
            {
                var weightCount = Neurons[i].Weights.Length;
                dW[i] = new double[weightCount];
                dB[i] = 0;
                for (var k = 0; k < weightCount; k++)
                {
                    dW[i][k] = givenOutputs[i] * reversedOutputs[k] * -learningRate;
                    dB[i] += reversedOutputs[k];
                }
                dB[i] *= -learningRate;
            }
            return new Tuple<double[][], double[]>(dW, dB);
        }
    }
}

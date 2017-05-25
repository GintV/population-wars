using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    [Serializable]
    class NeuralLayer : ICloneable
    {
        public int Size { get; }
        protected List<Neuron> Neurons;
        private readonly Func<double, double> m_activationFunc;
        protected readonly Func<double, double> ActivationDerivative;

        private NeuralLayer(Func<double, double> activationFunc, Func<double, double> activationDerivative, int size)
        {
            m_activationFunc = activationFunc;
            ActivationDerivative = activationDerivative;
            Size = size;
            Neurons = new List<Neuron>(size);
        }
        public NeuralLayer(int size, int inputCount, Func<double, double> activationFunc, Func<double, double> activationDerivative)
        {
            Size = size;
            m_activationFunc = activationFunc;
            ActivationDerivative = activationDerivative;
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

        public virtual double[] BackPropagate(double[] reversedOutputs, double[] receivedInputs)
        {
            var results = new double[receivedInputs.Length];
            for (var i = 0; i < receivedInputs.Length; i++)
            {
                for (var k = 0; k < reversedOutputs.Length; k++)
                {
                    results[i] += reversedOutputs[k] * Neurons[k].Weights[i];
                }
                results[i] *= 1 - ActivationDerivative(receivedInputs[i]);
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
                    dW[i][k] = givenOutputs[k] * reversedOutputs[i] * -learningRate;
                    dB[i] += reversedOutputs[i];
                }
                dB[i] *= -learningRate;
            }
            return new Tuple<double[][], double[]>(dW, dB);
        }

        public object Clone()
        {
            var clone = new NeuralLayer(m_activationFunc, ActivationDerivative, Size);
            foreach (var neuron in Neurons)
            {
                clone.Neurons.Add((Neuron)neuron.Clone());
            }
            return clone;
        }
    }
}

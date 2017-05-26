using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    [Serializable]
    class NeuralNetwork : ICloneable
    {
        private readonly List<NeuralLayer> m_layers;
        private readonly double m_learningRate;

        private NeuralNetwork(double learningRate)
        {
            m_layers = new List<NeuralLayer>();
            m_learningRate = learningRate;
        }

        public NeuralNetwork(IReadOnlyList<int> layerSizes, double learningRate) : this(layerSizes, learningRate, Math.Tanh, x => 1 - Math.Pow(Math.Tanh(x), 2))
        {
        }

        public NeuralNetwork(IReadOnlyList<int> layerSizes, double learningRate, Func<double, double> activationFunc, Func<double, double> activationDerivative)
        {
            m_learningRate = learningRate;
            m_layers = new List<NeuralLayer>(layerSizes.Count) { new InputLayer(layerSizes[0], activationFunc, activationDerivative) };
            var previousSize = layerSizes[0];
            for (var i = 1; i < layerSizes.Count - 1; i++)
            {
                m_layers.Add(new NeuralLayer(layerSizes[i], previousSize, activationFunc, activationDerivative));
                previousSize = layerSizes[i];
            }
            m_layers.Add(new OutputLayer(layerSizes[layerSizes.Count - 1], previousSize));
        }

        public double[] Predict(double[] inputs)
        {
            if (inputs.Length != m_layers[0].Size)
            {
                throw new Exception("Input vector size does not match input layer size.");
            }
            var results = inputs;
            foreach (var layer in m_layers)
            {
                results = layer.Transform(results);
            }
            return results;
        }

        public void Train(double[][] inputs, double[][] outputs, double testSetPercentage, int maxEpochs, double goalError)
        {
            var iteration = 0;
            var error = double.MaxValue;
            var previousTestError = double.MaxValue;
            var testSetSize = (int)(inputs.Length * testSetPercentage / 100);
            var trainSetSize = inputs.Length - testSetSize;
            while (iteration++ < maxEpochs && error > goalError)
            {
                error = 0;
                for (var i = 0; i < trainSetSize; i++)
                {
                    var outputStack = new Stack<double[]>(trainSetSize);
                    var currentInputs = inputs[i];
                    outputStack.Push(currentInputs);
                    foreach (var layer in m_layers)
                    {
                        currentInputs = layer.Transform(currentInputs);
                        outputStack.Push(currentInputs);
                    }
                    error += CalculateLoss(outputs[i], currentInputs);
                    var reversedOutputs = ((OutputLayer) m_layers[m_layers.Count - 1]).ReverseActivation(outputStack.Pop(), outputs[i]);
                    foreach (var layer in Enumerable.Reverse(m_layers))
                    {
                        var receivedInputs = outputStack.Pop();
                        var parametersDeltas = layer.CalculateDeltas(receivedInputs, reversedOutputs, m_learningRate);
                        reversedOutputs = layer.BackPropagate(reversedOutputs, receivedInputs);
                        layer.AlterParameters(parametersDeltas.Item1, parametersDeltas.Item2);
                    }
                }
                var testError = 0.0;
                for (int i = 0; i < testSetSize; i++)
                {
                    testError += CalculateLoss(outputs[i + trainSetSize], Predict(inputs[i + trainSetSize]));
                }
                if (testError > previousTestError)
                {
                    //break;
                }
                previousTestError = testError;
                error = -1 * error / trainSetSize;
            }
        }

        private static double CalculateLoss(double[] expected, double[] predicted)
        {
            var sum = 0.0;
            for (var i = 0; i < expected.Length; i++)
            {
                sum += expected[i] * Math.Log(predicted[i]);
            }
            return sum;
        }

        public object Clone()
        {
            var clone = new NeuralNetwork(m_learningRate);
            foreach (var layer in m_layers)
            {
                clone.m_layers.Add((NeuralLayer) layer.Clone());
            }
            return clone;
        }
    }
}

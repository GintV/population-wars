using System;
using System.Collections.Generic;

namespace PopulationWars.HomeGrownNetwork
{
    class NeuralNetwork
    {
        private readonly List<NeuralLayer> m_layers;
        private readonly double m_learningRate;

        public NeuralNetwork(IReadOnlyList<int> layerSizes, double learningRate) : this(layerSizes, learningRate, Math.Tanh, x => 1 - Math.Pow(Math.Tanh(x), 2))
        {
        }

        public NeuralNetwork(IReadOnlyList<int> layerSizes, double learningRate, Func<double, double> activationFunc, Func<double, double> activationDerivative)
        {
            m_learningRate = learningRate;
            m_layers = new List<NeuralLayer>(layerSizes.Count) { new InputLayer(layerSizes[0], activationFunc) };
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
                    var reversedOutputs = outputStack.Pop();
                    for (var k = 0; k < reversedOutputs.Length; k++)
                    {
                        reversedOutputs[k] -= outputs[i][k];
                    }
                    for (var k = m_layers.Count - 2; k > 0; k--)
                    {
                        var givenOutputs = outputStack.Pop();
                        var parametersDeltas = CalculateParametersDeltas(givenOutputs, reversedOutputs);
                        if (k != 0)
                            reversedOutputs = m_layers[k].BackPropogate(givenOutputs, reversedOutputs);
                        m_layers[k].AlterParameters(parametersDeltas.Item1, parametersDeltas.Item2);
                    }
                }
                error = -1 * error / trainSetSize;
            }
        }

        private Tuple<double[][], double[]> CalculateParametersDeltas(double[] givenOutputs, double[] reversedOutputs)
        {
            var outputCount = givenOutputs.Length;
            var dW = new double[outputCount][];
            var dB = new double[outputCount];
            for (var i = 0; i < outputCount; i++)
            {
                dW[i] = new double[outputCount];
                dB[i] = 0;
                for (var k = 0; k < outputCount; k++)
                {
                    dW[i][k] = givenOutputs[i] * reversedOutputs[k] * -m_learningRate;
                    dB[i] += reversedOutputs[k];
                }
                dB[i] *= -m_learningRate;
            }
            return new Tuple<double[][], double[]>(dW, dB);
        }

        private static double CalculateLoss(double[] expected, double[] predicted)
        {
            var sum = 0.0;
            for (var i = 0; i < expected.Length; i++)
            {
                sum = expected[i] * Math.Log(predicted[i]);
            }
            return sum;
        }
    }
}

using System;
using System.Linq;
using PopulationWars.HomeGrownNetwork;
using PopulationWars.Mechanics;

namespace PopulationWars.Components.Governments
{
    [Serializable]
    class HomeGrownNetwork : IGovernment
    {
        private const int OutputSize = 9;
        private const double TestSetPercentage = 20.0;
        private const int MaxEpochs = 1500;
        private const double GoalError = 0.00002;
        private const double PopulationToMove = 0.5;
        private const double LearningRate = 0.00001;
        private static readonly int[] HiddenLayerSizes = { 50, 20, 50 };

        private NeuralNetwork m_network;
        private int m_inputSize;

        public HomeGrownNetwork() { }

        public object Clone()
        {
            var clone = new HomeGrownNetwork
            {
                m_network = (NeuralNetwork)m_network?.Clone(),
                m_inputSize = m_inputSize
            };
            return clone;
        }

        public void Train(TrainSet trainSet)
        {
            var dim = trainSet.Situation.First().Environment.Size * 2 + 1;
            var inputSize = dim * dim * 2 + 3;
            if (m_network == null)
            {
                m_inputSize = inputSize;
                var layerSizes = new int[HiddenLayerSizes.Length + 2];
                layerSizes[0] = m_inputSize;
                layerSizes[layerSizes.Length - 1] = OutputSize;
                Array.Copy(HiddenLayerSizes, 0, layerSizes, 1, HiddenLayerSizes.Length);
                m_network = new NeuralNetwork(layerSizes, LearningRate);
            }
            if (inputSize != m_inputSize)
            {
                throw new Exception("Training set input variables doesn't match neural networks input structure.");
            }
            for (var i = 0; i < trainSet.Situation.Count; i++)
            {
                if (trainSet.Decision[i].Direction == Direction.None)
                {
                    trainSet.Decision[i] = null;
                    trainSet.Situation[i] = null;
                }
            }
            trainSet.Decision = trainSet.Decision.Where(d => d != null).ToList();
            trainSet.Situation = trainSet.Situation.Where(s => s != null).ToList();
            var inputs = new double[trainSet.Situation.Count][];
            var outputs = new double[trainSet.Situation.Count][];
            for (var i = 0; i < trainSet.Decision.Count; i++)
            {
                inputs[i] = SituationToInputs(trainSet.Situation[i]);
                outputs[i] = DecisionToOutputs(trainSet.Decision[i]);
            }
            m_network.Train(inputs, outputs, TestSetPercentage, MaxEpochs, GoalError);
        }

        public Decision MakeDecision(Situation situation)
        {
            return OutputsToDecision(m_network.Predict(SituationToInputs(situation)));
        }

        private double[] SituationToInputs(Situation situation)
        {
            var dim = situation.Environment.Size * 2 + 1;
            var inputSize = dim * dim * 2 + 3;
            if (inputSize != m_inputSize)
            {
                throw new Exception("Situation input variables doesn't match neural networks input structure.");
            }
            var inputs = new double[inputSize];
            var nation = situation.Environment.Map[dim / 2][dim / 2].OwnedBy.Nation;
            for (var i = 0; i < dim; i++)
            {
                for (var k = 0; k < dim; k++)
                {
                    var tile = situation.Environment.Map[i][k];
                    if (tile.IsColonized)
                    {
                        inputs[i * dim + k * 2] = tile.OwnedBy.Population;
                        inputs[i * dim + k * 2 + 1] = tile.OwnedBy.Nation == nation ? 1 : 2;
                    }
                    else
                    {
                        inputs[i * dim + k * 2] = 0;
                        inputs[i * dim + k * 2 + 1] = tile.IsWall ? -1 : 0;
                    }
                }
            }
            return inputs;
        }

        private Decision OutputsToDecision(double[] outputs)
        {
            var max = 0.0;
            var direction = Direction.None;
            for (var i = 0; i < OutputSize; i++)
            {
                if (!(outputs[i] > max)) continue;
                max = outputs[i];
                direction = (Direction)i;
            }
            return direction == Direction.None ? new Decision() : new Decision(true, direction, PopulationToMove);
        }

        private static double[] DecisionToOutputs(Decision decision)
        {
            var output = new double[OutputSize];
            output[(int)decision.Direction] = 1;
            return output;
        }
    }
}

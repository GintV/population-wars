using System;
using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    [Serializable]
    class Neuron : ICloneable
    {
        public Neuron(int inputCount)
        {
            Weights = new double[inputCount];
            Random ran = new Random();
            for (var i = 0; i < inputCount; i++)
            {
                Weights[i] = ran.NextDouble();
            }
            m_bias = 0;
        }

        public Neuron(double[] weights, double bias = 0)
        {
            Weights = (double []) weights.Clone();
            m_bias = bias;
        }

        private double m_bias;
        public double[] Weights { get; }
        public double Calculate(double[] inputs) => inputs.Select((t, i) => t * Weights[i]).Sum() + m_bias;

        public void AlterWeights(double[] deltaWeights, double deltaBias)
        {
            m_bias += deltaBias;
            for (var i = 0; i < Weights.Length; i++)
            {
                Weights[i] += deltaWeights[i];
            }
        }

        public object Clone()
        {
            return new Neuron(Weights, m_bias);
        }
    }
}

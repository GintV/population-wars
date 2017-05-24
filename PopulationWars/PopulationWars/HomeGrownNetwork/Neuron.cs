using System.Linq;

namespace PopulationWars.HomeGrownNetwork
{
    class Neuron
    {
        public Neuron(int inputCount)
        {
            Weights = new double[inputCount];
            m_bias = 0;
        }

        private double m_bias;
        public double[] Weights { get; }
        public double Calculate(double[] inputs) => inputs.Select((t, i) => t * Weights[i] + m_bias).Sum();

        public void AlterWeights(double[] deltaWeights, double deltaBias)
        {
            m_bias += deltaBias;
            for (var i = 0; i < Weights.Length; i++)
            {
                Weights[i] += deltaWeights[i];
            }
        }
    }
}

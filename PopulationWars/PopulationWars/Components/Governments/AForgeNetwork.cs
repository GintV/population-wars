using System;
using System.Diagnostics;
using System.Linq;
using AForge.Neuro;
using AForge.Neuro.Learning;
using PopulationWars.Map;
using PopulationWars.Mechanics;


namespace PopulationWars.Components.Governments
{
    [Serializable]
    class AForgeNetwork : IGovernment
    {

        private static readonly int[] m_layers = { 5, 4 }; // Paskutinis yra output
        private static readonly int m_inputsCount = 5;
        private ActivationNetwork m_network1;
        private ActivationNetwork m_network2;
        private ActivationNetwork m_network3;
        private ActivationNetwork m_network4;
        private SigmoidFunction m_activationFunc;

        public AForgeNetwork()
        {
            m_activationFunc = new SigmoidFunction();
            m_network1 = new ActivationNetwork(m_activationFunc, m_inputsCount, m_layers);
            m_network2 = new ActivationNetwork(m_activationFunc, m_inputsCount, m_layers);
            m_network3 = new ActivationNetwork(m_activationFunc, m_inputsCount, m_layers);
            m_network4 = new ActivationNetwork(m_activationFunc, m_inputsCount, new int[] { 4 });
        }

        public object Clone()
        {
            var netw1 = new System.IO.MemoryStream();
            var netw2 = new System.IO.MemoryStream();
            var netw3 = new System.IO.MemoryStream();
            var netw4 = new System.IO.MemoryStream();
            m_network1.Save(netw1);
            m_network2.Save(netw2);
            m_network3.Save(netw3);
            m_network4.Save(netw4);

            var clone = new AForgeNetwork()
            {
                m_activationFunc = (SigmoidFunction)m_activationFunc.Clone(),
                m_network1 = (ActivationNetwork)Network.Load(netw1),
                m_network2 = (ActivationNetwork)Network.Load(netw2),
                m_network3 = (ActivationNetwork)Network.Load(netw3),
                m_network4 = (ActivationNetwork)Network.Load(netw4)
            };
            netw1.Close();
            netw2.Close();
            netw3.Close();
            netw4.Close();

            return clone;
        }

        public Decision MakeDecision(Situation situation)
        {
            double[] sides = SimplifyEnvironment(situation.Environment);
            double[] input = { situation.ColonyPopulation, sides[0], sides[1], sides[2], sides[3] };
            double[][] output = {   m_network1.Compute(input),
                                    m_network2.Compute(input),
                                    /*m_network3.Compute(input),*/
                                    m_network4.Compute(input)};

            if (false) // false - be balsavimo ima pirma tinkla
            {
                bool outIsLeaving = output[0][0] > 0 ? true : false;
                double outPopulationToMove = output[0][1];
                Direction outDirection = DirectionFromVector(output[0][2], output[0][3]);

                outIsLeaving = outDirection == Direction.None ? false : true;

                return new Decision(outIsLeaving, outDirection, outPopulationToMove);
            }
            else
            {
                int isLeavingCount = 0;
                double[] votedOutput = { 0.0, 0.0, 0.0, 0.0 };
                foreach (var item in output)
                {
                    if (item[0] > 0) isLeavingCount++;
                    votedOutput[1] += item[1];
                    votedOutput[2] += item[2];
                    votedOutput[3] += item[3];
                }

                bool outIsLeaving = votedOutput[0] > 0 ? true : false;
                double outPopulationToMove = votedOutput[1]/ votedOutput.Count();
                Direction outDirection = DirectionFromVector(votedOutput[2]/votedOutput.Count(), votedOutput[3]/votedOutput.Count());

                outIsLeaving = outDirection == Direction.None ? false : true;

                return new Decision(outIsLeaving, outDirection, outPopulationToMove);
            }
        }

        public void Train(TrainSet trainSet)
        {
            TrainNetworkS(trainSet, new BackPropagationLearning(m_network1));
            TrainNetworkS(trainSet, new ResilientBackpropagationLearning(m_network2));
            //TrainNetworkE(trainSet, new EvolutionaryLearning(m_network3, 1000));
            TrainNetworkS(trainSet, new DeltaRuleLearning(m_network4));
        }

        private void TrainNetworkS(TrainSet trainSet, ISupervisedLearning teacher)
        {
            double[] sides = new double[4];
            double[] direction = new double[2];
            double[] input = new double[5];
            double[] output = new double[4];

            double error = 10;
            int epoch = 10000;

            while (epoch--> 0)
            {
                for (int s = 0; s < trainSet.Situation.Count; s++)
                {
                    sides = SimplifyEnvironment(trainSet.Situation[s].Environment);
                    direction = VectorFromDirection(trainSet.Decision[s].Direction);

                    // INPUT
                    input[0] = trainSet.Situation[s].ColonyPopulation;
                    input[1] = sides[0]; // UP
                    input[2] = sides[1]; // RIGHT
                    input[3] = sides[2]; // DOWN
                    input[4] = sides[3]; // LEFT

                    // OUTPUT
                    output[0] = trainSet.Decision[s].IsLeaving ? 1 : -1;
                    output[1] = trainSet.Decision[s].PopulationToMove;
                    output[2] = direction[0]; // X
                    output[3] = direction[1]; // Y

                    error = teacher.Run(input, output);
                }
                Debug.Print(error.ToString());
            }
        }

        private void TrainNetworkE(TrainSet trainSet, EvolutionaryLearning teacher)
        {
            double[] sides = new double[4];
            double[] direction = new double[2];
            double[] input = new double[5];
            double[] output = new double[4];

            double error = 10;
            int epoch = 10000;

            while (epoch-- > 0)
            {
                for (int s = 0; s < trainSet.Situation.Count; s++)
                {
                    sides = SimplifyEnvironment(trainSet.Situation[s].Environment);
                    direction = VectorFromDirection(trainSet.Decision[s].Direction);

                    // INPUT
                    input[0] = trainSet.Situation[s].ColonyPopulation;
                    input[1] = sides[0]; // UP
                    input[2] = sides[1]; // RIGHT
                    input[3] = sides[2]; // DOWN
                    input[4] = sides[3]; // LEFT

                    // OUTPUT
                    output[0] = trainSet.Decision[s].IsLeaving ? 1 : -1;
                    output[1] = trainSet.Decision[s].PopulationToMove;
                    output[2] = direction[0]; // X
                    output[3] = direction[1]; // Y

                    error = teacher.RunEpoch(new double[][] { input }, new double[][] { output });
                }

                Debug.Print(error.ToString());
            }
        }

        private double[] SimplifyEnvironment(Map.Environment env)
        {
            int size = env.Size*2 + 1;
            int center = env.Size;
            double[] sides = new double[4];
            Nation nation = env.Map[center][center].OwnedBy.Nation;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // Tikrinam ar apsimoka ziuret i ta langeli (yra colonija ir ne centrinis langelis)
                    if(env.Map[y][x].IsColonized && (x+y != size-1))
                    {
                        // Skaiciavimui virsutines dalies
                        if (y < center && x >= y && x < size - y)
                            sides[0] += GetPopulation(env, nation, x, y);

                        // Skaiciavimui desines dalies
                        if (x > center && y > x - center && y <= x)
                            sides[1] += GetPopulation(env, nation, x, y);

                        // Skaiciavimui apatines dalies
                        if (y > center && x+y >= size-1 && x <= y)
                            sides[2] += GetPopulation(env, nation, x, y);

                        // Skaiciavimui kaires dalies
                        if (x < center && y >= x && y < size - x)
                            sides[3] += GetPopulation(env, nation, x, y);
                    }
                }
            }

            return sides;
        }

        private int GetPopulation(Map.Environment env, Nation nation, int x, int y)
        {
            if (env.Map[y][x].OwnedBy.Nation == nation)
                return env.Map[y][x].OwnedBy.Population;
            return (-1) * env.Map[y][x].OwnedBy.Population;
        }

        private Direction DirectionFromVector(double x, double y)
        {
            int ny = (int)Math.Round(y);
            int nx = (int)Math.Round(x);
            if (ny == -1 && nx ==  0) return Direction.Up;
            if (ny == -1 && nx ==  1) return Direction.UpRight;
            if (ny ==  0 && nx ==  1) return Direction.Right;
            if (ny ==  1 && nx ==  1) return Direction.DownRight;
            if (ny ==  1 && nx ==  0) return Direction.Down;
            if (ny ==  1 && nx == -1) return Direction.DownLeft;
            if (ny ==  0 && nx == -1) return Direction.Left;
            if (ny == -1 && nx == -1) return Direction.UpLeft;
            return Direction.None;
        }

        private double[] VectorFromDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:          return new double[] { 0, -1 };
                case Direction.UpRight:     return new double[] { 1, -1 };
                case Direction.Right:       return new double[] { 1, 0 };
                case Direction.DownRight:   return new double[] { 1, 1 };
                case Direction.Down:        return new double[] { 0, 1 };
                case Direction.DownLeft:    return new double[] { -1, 1 };
                case Direction.Left:        return new double[] { -1, 0 };
                case Direction.UpLeft:      return new double[] { -1, -1 };
                default:
                    return new double[] { 0,  0 };
            }
        }

        public override string ToString() => "AForgeNetwork";
    }
}

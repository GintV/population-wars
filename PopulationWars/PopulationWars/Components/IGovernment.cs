namespace PopulationWars.Components
{
    /*
     * Interface for entities that can make moves in games
     */
    public interface IGovernment
    {
        /*
        public void Train()
        {
            // TODO: implement
        }

        public Decision MakeDesicion(Situation situation)
        {
            // TODO: implement

            Random random = new Random(DateTime.Now.Millisecond);
            return new Desicion(random.NextDouble() > 0.5 ? true : false,
                (Direction)((((int)(random.NextDouble() * 100) % 9)) + 1), random.NextDouble());
        }
        */
        Decision MakeDecision(Situation situation);
    }
}
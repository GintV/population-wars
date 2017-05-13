namespace PopulationWars.Components
{
    public class Colony
    {
        public Nation Nation { get; set; }
        public int Population { get; set; }

        public Colony(Nation nation, int population)
        {
            Nation = nation;
            Population = population;
        }
    }
}
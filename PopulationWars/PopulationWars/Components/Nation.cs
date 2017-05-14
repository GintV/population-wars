namespace PopulationWars.Components
{
    public class Nation
    {
        public string Name { get; set; }
        public Government Government { get; set; }

        public Nation(string name, Government government = null)
        {
            Name = name;
            Government = government ?? new Government();
        }

        public override string ToString() => Name;
    }
}
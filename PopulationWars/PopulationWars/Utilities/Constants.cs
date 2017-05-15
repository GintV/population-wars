namespace PopulationWars.Utilities
{
    public class Constants // TODO: group in smaller groups
    {
        public enum GameAction
        {
            AddPlayer, 
            DeletePlayer, 
            EditPlayer
        }

        internal const int DefaultColonyScope = 3;
        internal const int DefaultMaximumGameDuration = 150;
        internal const int DefaultMinimumGameDuration = 100;
        internal const int DefaultWorldWidth = 30;
        internal const int DefaultWorldHeight = 30;

        internal const double DefaultPopulationGrowthRate = 2.0;

        internal const int MinimumColonyScope = 0;
        internal const int MinimumMaximumGameDuration = 10;
        internal const int MinimumMinimumGameDuration = 10;
        internal const int MinimumWorldWidth = 10;
        internal const int MinimumWorldHeight = 10;

        internal const double MinimumPopulationGrowthRate = 2.0;

        internal const int MaximumColonyScope = 15;
        internal const int MaximumMaximumGameDuration = 250;
        internal const int MaximumMinimumGameDuration = 200;
        internal const int MaximumWorldWidth = 100;
        internal const int MaximumWorldHeight = 100;

        internal const double MaximumPopulationGrowthRate = 5.0;

        internal const string Agent = "Agent";
        internal const string Human = "Human";

        internal const string AgentsDataDirName = "Agents";
        internal const string AgentsNamespace = "PopulationWars.Agents";
    }
}

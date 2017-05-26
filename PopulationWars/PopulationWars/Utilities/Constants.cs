namespace PopulationWars.Utilities
{
    public class Constants
    {
        public enum GameAction
        {
            AddPlayer,
            DeletePlayer,
            EditPlayer,
            TrainNationSelectNation,
            TrainNationSelectTrainSet
        }

        public enum GovernmentType
        {
            Anarchy,
            HomeGrownNetwork,
            AForgeNetwork
        }

        public enum GameType
        {
            Normal,
            GaGame
        }

        public static class GameSettings
        {
            public static class Default
            {
                internal const int ColonyScope = 3;
                internal const int MaximumGameDuration = 30;
                internal const int MinimumGameDuration = 20;
                internal const int WorldWidth = 15;
                internal const int WorldHeight = 15;
                internal const double PopulationGrowthRate = 2.0;
            }

            public static class Maximum
            {
                internal const int ColonyScope = 15;
                internal const int MaximumGameDuration = 250;
                internal const int MinimumGameDuration = 200;
                internal const int WorldWidth = 99;
                internal const int WorldHeight = 99;
                internal const double PopulationGrowthRate = 3.0;
            }

            public static class Minimum
            {
                internal const int ColonyScope = 1;
                internal const int MaximumGameDuration = 10;
                internal const int MinimumGameDuration = 10;
                internal const int WorldWidth = 10;
                internal const int WorldHeight = 10;
                internal const double PopulationGrowthRate = 1.1;
            }
        }

        // TODO: group in smaller groups

        internal const int MaximumPopulationInColony = 500000000;

        internal const string Agent = "Agent";
        internal const string Human = "Human";

        internal const string AgentsDataDirName = "Agents";
        internal const string AgentsNamespace = "PopulationWars.Agents";
    }
}

using System;
using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Utilities
{
    public class Settings
    {
        private static Settings m_lastSettings;

        public int ColonyScope { get; set; }
        public Tuple<int, int> GameDuration { get; set; }
        public double PopulationGrowthRate { get; set; }
        public Tuple<int, int> WorldSize { get; set; }

        public static Settings LastSettings
        {
            get { return m_lastSettings ?? (m_lastSettings = new Settings()); }
            set { m_lastSettings = value; }
        }

        public Settings()
        {
            ColonyScope = DefaultColonyScope;
            GameDuration = new Tuple<int, int>(DefaultMinimumGameDuration,
                DefaultMaximumGameDuration);
            PopulationGrowthRate = DefaultPopulationGrowthRate;
            WorldSize = new Tuple<int, int>(DefaultWorldWidth, DefaultWorldHeight);
        }
    }
}

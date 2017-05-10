using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Utilities
{
    class Settings
    {
        private static Settings m_settings;

        public int ColonyScope { get; set; }
        public Tuple<int, int> GameDuration { get; set; }
        public double PopulationGrowthRate { get; set; }
        public Tuple<int, int> WorldSize { get; set; }

        public static Settings GameSettings { get { return GetGameSettings(); } }

        private Settings()
        {
            ColonyScope = DefaultColonyScope;
            GameDuration = new Tuple<int, int>(DefaultMinimumGameDuration,
                DefaultMaximumGameDuration);
            PopulationGrowthRate = DefaultPopulationGrowthRate;
            WorldSize = new Tuple<int, int>(DefaultWorldWidth, DefaultWorldHeight);
        }

        private static Settings GetGameSettings()
        {
            return m_settings == null ? (m_settings = new Settings()) : m_settings;
        }
    }
}

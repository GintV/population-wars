using System;
using System.Windows.Forms;
using PopulationWars.Utilities;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars
{
    public partial class SettingsWindow : Form
    {
        public Settings Settings { get; set; }

        public SettingsWindow()
        {
            InitializeComponent();
            SetMinMaxValues();
            LoadSettings();
        }

        private void LoadSettings()
        {
            var gameDuration = Settings.LastSettings.GameDuration;
            var worldSize = Settings.LastSettings.WorldSize;

            colonyScopeNumericUpDown.Value = Settings.LastSettings.ColonyScope;
            gameDurationMinNumericUpDown.Value = gameDuration.Item1;
            gameDurationMaxNumericUpDown.Value = gameDuration.Item2;
            growthRateNumericUpDown.Value = (int)Settings.LastSettings.PopulationGrowthRate;
            worldWidthNmericUpDown.Value = worldSize.Item1;
            worldHeightNumericUpDown.Value = worldSize.Item2;
        }

        private void SetMinMaxValues()
        {
            colonyScopeNumericUpDown.Minimum = MinimumColonyScope;
            colonyScopeNumericUpDown.Maximum = MaximumColonyScope;

            gameDurationMinNumericUpDown.Minimum = MinimumMinimumGameDuration;
            gameDurationMinNumericUpDown.Maximum = MaximumMinimumGameDuration;

            gameDurationMaxNumericUpDown.Minimum = MinimumMaximumGameDuration;
            gameDurationMaxNumericUpDown.Maximum = MaximumMaximumGameDuration;

            growthRateNumericUpDown.Minimum = (int)MinimumPopulationGrowthRate;
            growthRateNumericUpDown.Maximum = (int)MaximumPopulationGrowthRate;

            worldWidthNmericUpDown.Minimum = MinimumWorldWidth;
            worldWidthNmericUpDown.Maximum = MaximumWorldWidth;

            worldHeightNumericUpDown.Minimum = MinimumWorldHeight;
            worldHeightNumericUpDown.Maximum = MaximumWorldHeight;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var colonyScope = colonyScopeNumericUpDown.Value;
            var gameDurationMin = gameDurationMinNumericUpDown.Value;
            var gameDurationMax = gameDurationMaxNumericUpDown.Value;
            var growthRate = growthRateNumericUpDown.Value;
            var worldWidth = worldWidthNmericUpDown.Value;
            var worldHeight = worldHeightNumericUpDown.Value;

            if (gameDurationMax < gameDurationMin)
            {
                MessageBox.Show("Maximum game duration cannot be less than minimum game duration.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            Settings.LastSettings = Settings = new Settings()
            {
                ColonyScope = (int)colonyScope,
                GameDuration = Tuple.Create((int)gameDurationMin, (int)gameDurationMax),
                PopulationGrowthRate = (int)growthRate,
                WorldSize = Tuple.Create((int)worldWidth, (int)worldHeight)
            };
        }
    }
}

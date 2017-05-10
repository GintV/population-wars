using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopulationWars.Utilities;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            SetMinMaxValues();
            LoadSettings();
        }

        private void SetMinMaxValues()
        {
            this.colonyScopeNumericUpDown.Minimum = MinimumColonyScope;
            this.colonyScopeNumericUpDown.Maximum = MaximumColonyScope;

            this.gameDurationMinNumericUpDown.Minimum = MinimumMinimumGameDuration;
            this.gameDurationMinNumericUpDown.Maximum = MaximumMinimumGameDuration;

            this.gameDurationMaxNumericUpDown.Minimum = MinimumMaximumGameDuration;
            this.gameDurationMaxNumericUpDown.Maximum = MaximumMaximumGameDuration;

            this.growthRateNumericUpDown.Minimum = (int)MinimumPopulationGrowthRate;
            this.growthRateNumericUpDown.Maximum = (int)MaximumPopulationGrowthRate;

            this.worldWidthNmericUpDown.Minimum = MinimumWorldWidth;
            this.worldWidthNmericUpDown.Maximum = MaximumWorldWidth;

            this.worldHeightNumericUpDown.Minimum = MinimumWorldHeight;
            this.worldHeightNumericUpDown.Maximum = MaximumWorldHeight;
        }

        private void LoadSettings()
        {
            var gameDuration = Settings.GameSettings.GameDuration;
            var worldSize = Settings.GameSettings.WorldSize;

            this.colonyScopeNumericUpDown.Value = Settings.GameSettings.ColonyScope;
            this.gameDurationMinNumericUpDown.Value = gameDuration.Item1;
            this.gameDurationMaxNumericUpDown.Value = gameDuration.Item2;
            this.growthRateNumericUpDown.Value = (int)Settings.GameSettings.PopulationGrowthRate;
            this.worldWidthNmericUpDown.Value = worldSize.Item1;
            this.worldHeightNumericUpDown.Value = worldSize.Item2;
        }

        private void SaveSettings(int colonyScope, int gameDurationMin, int gameDurationMax,
            int growthRate, int worldWidth, int worldHeight)
        {
            Settings.GameSettings.ColonyScope = colonyScope;
            Settings.GameSettings.GameDuration = Tuple.Create(gameDurationMin, gameDurationMax);
            Settings.GameSettings.PopulationGrowthRate = growthRate;
            Settings.GameSettings.WorldSize = Tuple.Create(worldWidth, worldHeight);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var colonyScope = this.colonyScopeNumericUpDown.Value;
            var gameDurationMin = this.gameDurationMinNumericUpDown.Value;
            var gameDurationMax = this.gameDurationMaxNumericUpDown.Value;
            var growthRate = this.growthRateNumericUpDown.Value;
            var worldWidth = this.worldWidthNmericUpDown.Value;
            var worldHeight = this.worldHeightNumericUpDown.Value;

            if (gameDurationMax < gameDurationMin)
            {
                MessageBox.Show("Maximum game duration cannot be less than minimum game duration",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            SaveSettings((int)colonyScope, (int)gameDurationMin, (int)gameDurationMax,
                (int)growthRate, (int)worldWidth, (int)worldHeight);
        }
    }
}

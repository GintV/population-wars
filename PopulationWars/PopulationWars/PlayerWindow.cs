using System;
using System.Windows.Forms;
using PopulationWars.Components;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars
{
    public partial class PlayerWindow : Form
    {
        public Player Player { get; set; }

        public enum PlayerWindowMode
        {
            AddPlayer,
            EditPlayer
        }

        public PlayerWindow(PlayerWindowMode mode, Player player = null)
        {
            InitializeComponent();
            LoadWindowName(mode);

            if (mode == PlayerWindowMode.AddPlayer)
                PreselectTypeListBox();
            else
                LoadPlayer(player);
        }

        private void LoadWindowName(PlayerWindowMode mode) =>
            Text = mode == PlayerWindowMode.AddPlayer ? "Add Player" : "Edit Player";

        private void PreselectTypeListBox() => typeListBox.SelectedIndex = 0;

        private void LoadPlayer(Player player)
        {
            // TODO: while loading player, add dummy nation to nation list to represent current
            // nation
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = colorButton.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var playerName = playerNameTextBox.Text;
            var playerType = typeListBox.SelectedItem.ToString() == Agent ? true : false;
            var color = colorButton.BackColor;
            var nation = existingNationRadioButton.Checked ? null : //TODO: after implementing
                                                                // serialization update null value
                new Nation(nationNameTextBox.Text);

            if (playerName == "")
            {
                MessageBox.Show("Player name cannot be empty string", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            else if (nation?.Name == "") // remove Elvis operator after implemeting serialization
            {
                MessageBox.Show("Nation name cannot be an empty string", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            Player = new Player(playerName, playerType, nation, color);
        }

        private void newNationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nationListBox.Enabled = !nationListBox.Enabled;
            nationNameTextBox.Enabled = !nationNameTextBox.Enabled;
        }
    }
}

using System;
using System.Windows.Forms;
using PopulationWars.Components;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;
using static PopulationWars.Utilities.Constants.GameAction;
using System.Collections.Generic;
using System.Linq;

namespace PopulationWars
{
    public partial class PlayerWindow : Form
    {
        public Player Player { get; set; }
        private GameAction m_action;
        private List<Player> m_players;

        public PlayerWindow(GameAction action, List<Player> players, Player player = null)
        {
            InitializeComponent();
            LoadWindowName(action);

            if (action == EditPlayer)
            {
                Player = player;
                LoadPlayer(player);
            }
            else
                PreselectListBoxes();

            m_action = action;
            m_players = players;
        }

        private void LoadPlayer(Player player)
        {
            playerNameTextBox.Text = player.Name;
            typeListBox.SelectedIndex = player.IsAgent ? 0 : 1;
            colorButton.BackColor = player.Color;
            nationNameTextBox.Text = player.Nation.Name;
            nationListBox.Items.Add(player.Nation);
            nationListBox.SelectedIndex = 1;
        }

        private void LoadWindowName(GameAction action) =>
            Text = action == AddPlayer ? "Add Player" : "Edit Player";

        private void PreselectListBoxes() =>
            typeListBox.SelectedIndex = nationListBox.SelectedIndex = 0;

        private void colorButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog()
            {
                Color = colorButton.BackColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO: check if name does not exist
            var playerName = playerNameTextBox.Text;
            var playerType = typeListBox.SelectedItem.ToString() == Agent ? true : false;
            var color = colorButton.BackColor;
            var nationName = nationNameTextBox.Text;
            var nation = nationListBox.SelectedIndex == 0 ?
                new Nation(nationName) :
                (m_action == EditPlayer && nationListBox.SelectedIndex == 1) ?
                Player.Nation : null;
            // TODO: after implementing
            // serialization update null value

            var playerNameExists = m_players.Where(p => p.Name == playerName).Any();
            if (playerName == "")
            {
                MessageBox.Show("Player name cannot be empty string.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            else if (m_action == AddPlayer && playerNameExists || m_action == EditPlayer &&
                Player.Name != playerName && playerNameExists)
            {
                MessageBox.Show("Player name already exists.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            else if (nation?.Name == "") // remove Elvis operator after implemeting serialization
            {
                MessageBox.Show("Nation name cannot be an empty string.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (m_action == EditPlayer)
            {
                Player.Name = playerName;
                Player.IsAgent = playerType;
                Player.Color = color;
                Player.Nation.Name = nationName;
                Player.Nation = nation;
            }
            else
                Player = new Player(playerName, playerType, nation, color);
        }
    }
}

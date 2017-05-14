using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars
{
    public partial class PlayerListWindow : Form
    {
        private List<Player> m_players;
        private GameAction m_action;

        public PlayerListWindow(List<Player> players, GameAction action)
        {
            InitializeComponent();
            LoadButtonAndWindowName(action);
            LoadPlayerList(players);
            m_players = players;
            m_action = action;
        }

        private void DeletePlayer(Player player)
        {
            var result = MessageBox.Show($"Are you sure you want to delete: {player}?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                DialogResult = DialogResult.None;
                return;
            }

            m_players.Remove(player);
        }

        private void EditPlayer(Player player) =>
            new PlayerWindow(GameAction.EditPlayer, m_players, player).ShowDialog();

        private void LoadButtonAndWindowName(GameAction action)
        {
            if (action == GameAction.EditPlayer)
            {
                editDeletebutton.Text = "Edit";
                Text = "Select Player To Edit";
            }
            else
            {
                editDeletebutton.Text = "Delete";
                Text = "Select Player To Delete";
            }
        }

        private void LoadPlayerList(List<Player> players) =>
            playerListBox.Items.AddRange(players.ToArray());

        private void editDeletebutton_Click(object sender, EventArgs e)
        {
            if (playerListBox.SelectedItem == null)
            {
                MessageBox.Show("No item selected.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            var player = m_players.
                Where(p => p.ToString() == playerListBox.SelectedItem.ToString()).First();

            if (m_action == GameAction.EditPlayer)
                EditPlayer(player);
            else
                DeletePlayer(player);
        }
    }
}

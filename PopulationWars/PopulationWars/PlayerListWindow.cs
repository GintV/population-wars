using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;
using PopulationWars.Components;

namespace PopulationWars
{
    public partial class PlayerListWindow : Form
    {
        private List<Player> m_players;
        private List<Nation> m_nations;
        private Nation m_nation;
        private List<TrainSet> m_trainSets;
        private GameAction m_action;

        public PlayerListWindow(List<Player> players, List<Nation> nations, Nation nation,
            List<TrainSet> trainSets, GameAction action)
        {
            InitializeComponent();
            m_players = players;
            m_nations = nations;
            m_nation = nation;
            m_trainSets = trainSets;
            m_action = action;

            LoadButtonAndWindowName();
            LoadList();
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
            new PlayerWindow(GameAction.EditPlayer, m_players, m_nations, player).ShowDialog();

        private void LoadButtonAndWindowName()
        {
            if (m_action == GameAction.EditPlayer)
            {
                editDeletebutton.Text = "Edit";
                Text = "Select Player To Edit";
            }
            else if (m_action == GameAction.DeletePlayer)
            {
                editDeletebutton.Text = "Delete";
                Text = "Select Player To Delete";
            }
            else if (m_action == GameAction.TrainNationSelectNation)
            {
                editDeletebutton.Text = "Select";
                Text = "Select Nation To Train";
            }
            else
            {
                editDeletebutton.Text = "Train";
                Text = "Select Train Set To Train";
            }
        }

        private void LoadList()
        {
            if (m_action == GameAction.EditPlayer || m_action == GameAction.DeletePlayer)
                LoadPlayerList();
            else if (m_action == GameAction.TrainNationSelectNation)
                LoadNationList();
            else
                LoadTrainSetList();
        }

        private void LoadNationList() =>
            playerListBox.Items.AddRange(m_nations.ToArray());

        private void LoadPlayerList() =>
            playerListBox.Items.AddRange(m_players.ToArray());

        private void LoadTrainSetList() =>
            playerListBox.Items.AddRange(m_trainSets.ToArray());


        private void SelectTrainSet(Nation nation)
        {
            using (var form = new PlayerListWindow(null, m_nations, nation, m_trainSets,
                GameAction.TrainNationSelectTrainSet))
            {
                form.ShowDialog();
            }
        }

        private void TrainAndSaveNation(TrainSet trainSet)
        {
            m_nation.Government.Train(trainSet);
            DataParser.Serialize(m_nations);
        }

        private void editDeletebutton_Click(object sender, EventArgs e)
        {
            if (playerListBox.SelectedItem == null)
            {
                MessageBox.Show("No item selected.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            var player = m_players?.
                Where(p => p.ToString() == playerListBox.SelectedItem.ToString()).FirstOrDefault();
            var nation = m_nations?.
                Where(n => n.ToString() == playerListBox.SelectedItem.ToString()).FirstOrDefault();
            var trainSet = m_trainSets?.
                Where(t => t.ToString() == playerListBox.SelectedItem.ToString()).FirstOrDefault();

            if (m_action == GameAction.EditPlayer)
                EditPlayer(player);
            else if (m_action == GameAction.DeletePlayer)
                DeletePlayer(player);
            else if (m_action == GameAction.TrainNationSelectNation)
                SelectTrainSet(nation);
            else
                TrainAndSaveNation(trainSet);
        }
    }
}

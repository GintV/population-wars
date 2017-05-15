using System;
using System.Windows.Forms;
using PopulationWars.Components;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;
using static PopulationWars.Utilities.Constants.GameAction;
using System.Collections.Generic;
using System.IO;
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

            var agentDataDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + AgentsDataDirName;
            Directory.CreateDirectory(agentDataDir);
            foreach (var enumerateDirectory in Directory.EnumerateDirectories(agentDataDir))
            {
                agentsListBox.Items.Add(enumerateDirectory.Substring(enumerateDirectory.LastIndexOf(Path.DirectorySeparatorChar) + 1));
            }

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
            colorButton.BackColor = player.Color;
            nationNameTextBox.Text = player.Nation.Name;
            nationListBox.Items.Add(player.Nation);
            nationListBox.SelectedIndex = 1;
            agentRadioButton.Checked = player.IsAgent;
            humanRadioButton.Checked = !player.IsAgent;
            if (!player.IsAgent) return;
            var name = Player.Nation.Government.GetType().Name;
            foreach (var item in agentsListBox.Items)
            {
                if (name.Equals(item.ToString()))
                {
                    agentsListBox.SelectedItem = item;
                }
            }
        }

        private void LoadWindowName(GameAction action) =>
            Text = action == AddPlayer ? "Add Player" : "Edit Player";

        private void PreselectListBoxes()
        {
            humanRadioButton.Checked = true;
            nationListBox.SelectedIndex = 0;
        }

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
            var playerType = agentRadioButton.Checked;
            var color = colorButton.BackColor;
            var nationName = nationNameTextBox.Text;
            IGovernment gov;
            if (playerType)
            {
                var className = agentsListBox.SelectedItem.ToString();
                var agent = (IAgent)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(AgentsNamespace + "." + className);
                if (agent == null)
                {
                    MessageBox.Show("Agent not found.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                var agentDataPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + AgentsDataDirName + Path.DirectorySeparatorChar + className;
                Directory.CreateDirectory(agentDataPath);
                agent.SetDataPath(agentDataPath);
                agent.LoadData();   // TODO: Load async if GUI lags
                gov = agent;
            }
            else
            {
                gov = new RealPlayer();
            }
            var nation = nationListBox.SelectedIndex == 0 ?
                new Nation(nationName, gov) :
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

        private void humanRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            agentsListBox.Enabled = false;
            addAgentButton.Enabled = false;
        }

        private void agentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            agentsListBox.Enabled = true;
            addAgentButton.Enabled = true;
            if (agentsListBox.SelectedItem == null && agentsListBox.Items.Count > 0)
                agentsListBox.SelectedIndex = 0;
        }

        private void addAgentButton_Click(object sender, EventArgs e)
        {
            Form newAgentForm = new CreateAgentDialog();
            newAgentForm.ShowDialog();
            if (newAgentForm.DialogResult == DialogResult.OK)
            {
                var textBox = newAgentForm.Controls.OfType<TextBox>().FirstOrDefault();
                if (textBox != null)
                {
                    var name = textBox.Text;
                    Boolean exists = false;
                    foreach (var item in agentsListBox.Items)
                    {
                        if (name.Equals(item))
                        {
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        agentsListBox.Items.Add(name);
                        agentsListBox.SelectedItem = name;
                    }
                    else
                    {
                        MessageBox.Show("Agent already defined.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                }
            }
            newAgentForm.Dispose();
        }
    }
}

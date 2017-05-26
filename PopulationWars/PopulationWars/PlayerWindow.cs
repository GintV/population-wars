using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PopulationWars.Components;
using PopulationWars.Components.Governments;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants;
using static PopulationWars.Utilities.Constants.GameAction;


namespace PopulationWars
{
    public partial class PlayerWindow : Form
    {
        public Player Player { get; set; }
        private GameAction m_action;
        private List<Player> m_players;
        private List<Nation> m_nations;

        public PlayerWindow(GameAction action, List<Player> players, List<Nation> nations,
            Player player = null)
        {
            m_action = action; // this needs to be prior to InitializeComponent() due to 
                               // ListBox.SelectedIndexChanged event listener
            InitializeComponent();
            LoadWindowName(action);

            /*var agentDataDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar +
                AgentsDataDirName;
            Directory.CreateDirectory(agentDataDir);
            foreach (var enumerateDirectory in Directory.EnumerateDirectories(agentDataDir))
            {
                typeListBox.Items.Add(enumerateDirectory.
                    Substring(enumerateDirectory.LastIndexOf(Path.DirectorySeparatorChar) + 1));
            }*/

            if (action == EditPlayer)
            {
                Player = player;
                LoadPlayer(player);
            }
            else
                PreselectListBoxes();

            m_nations = nations;
            m_players = players;

            LoadNations(m_nations);
        }

        private void LoadNations(List<Nation> m_nations) =>
            nationListBox.Items.AddRange(m_nations.ToArray());

        private void LoadPlayer(Player player)
        {
            playerNameTextBox.Text = player.Name;
            typeListBox.SelectedIndex = player.IsAgent ? 0 : 1;
            colorButton.BackColor = player.Color;
            nationNameTextBox.Text = player.Nation.Name;
            nationListBox.Items.Add(player.Nation);
            nationListBox.SelectedIndex = 1;

            /*if (!player.IsAgent) return;
            var name = Player.Nation.Government.GetType().Name;
            foreach (var item in typeListBox.Items)
            {
                if (name.Equals(item.ToString()))
                {
                    typeListBox.SelectedItem = item;
                }
            }*/
        }

        private void LoadWindowName(GameAction action) =>
            Text = action == AddPlayer ? "Add Player" : "Edit Player";

        private void PreselectListBoxes() =>
            typeListBox.SelectedIndex = nationListBox.SelectedIndex =
            governmentListBox.SelectedIndex = 0;

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
            var playerName = playerNameTextBox.Text;
            var playerType = typeListBox.SelectedItem.ToString() == Agent ? true : false;
            var color = colorButton.BackColor;
            var nationName = nationNameTextBox.Text;

            /*IGovernment gov;
            if (playerType)
            {
                var className = typeListBox.SelectedItem.ToString();
                var agent = (IAgent)System.Reflection.Assembly.GetExecutingAssembly().
                    CreateInstance(AgentsNamespace + "." + className);
                if (agent == null)
                {
                    MessageBox.Show("Agent not found.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                var agentDataPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar +
                    AgentsDataDirName + Path.DirectorySeparatorChar + className;
                Directory.CreateDirectory(agentDataPath);
                agent.SetDataPath(agentDataPath);
                agent.LoadData();   // TODO: Load async if GUI lags
                gov = agent;
            }
            else
            {
                gov = new RealPlayer();
            }*/

            var selectedGovernment = governmentListBox.SelectedItem.ToString();
            var government = selectedGovernment == GovernmentType.Anarchy.ToString() ?
                 new Anarchy() : selectedGovernment == GovernmentType.HomeGrownNetwork.ToString() ?
                (IGovernment)new Components.Governments.HomeGrownNetwork() : new AForgeNetwork();

            var nation = nationListBox.SelectedIndex == 0 ?
                new Nation(nationName, government) :
                (m_action == EditPlayer && nationListBox.SelectedIndex == 1) ?
                Player.Nation : new Nation(nationName, m_nations.Where(n => n.ToString() ==
                nationListBox.SelectedItem.ToString()).First().Government);

            var playerNameExists = m_players.Where(p => p.Name == playerName).Any();
            var nationNameExists = m_action == AddPlayer ?
                m_nations.Where(n => n.Name == nationName).Any() :
                m_nations.Where(n => n.Name == nationName && Player.Nation.Name != nationName).
                Any();

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
            else if (nation.Name == "")
            {
                MessageBox.Show("Nation name cannot be an empty string.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            else if (nationNameExists)
            {
                MessageBox.Show("Nation name already exists.", "Warning",
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

                if (nationListBox.SelectedIndex != 1)
                    m_nations.Add(nation);
            }
            else
            {
                Player = new Player(playerName, playerType, nation, color);
                m_nations.Add(nation);
            }
        }

        /*private void addAgentButton_Click(object sender, EventArgs e)
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
                    foreach (var item in typeListBox.Items)
                    {
                        if (name.Equals(item))
                        {
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        typeListBox.Items.Add(name);
                        typeListBox.SelectedItem = name;
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
        }*/

        private void nationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nationListBox.SelectedIndex == 0)
            {
                nationNameTextBox.Enabled = true;
                governmentListBox.Enabled = true;
            }
            else /*if (nationListBox.SelectedIndex == 1 && m_action == EditPlayer)*/
            {
                nationNameTextBox.Enabled = true;
                governmentListBox.Enabled = false;
            }
            /*else
            {
                nationNameTextBox.Enabled = false;
                governmentListBox.Enabled = false;
            }*/
        }
    }
}

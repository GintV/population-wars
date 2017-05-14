using System;
using System.Drawing;
using System.Windows.Forms;
using PopulationWars.Mechanics;

using static PopulationWars.Utilities.Constants.GameAction;

namespace PopulationWars
{
    public partial class MainWindow : Form
    {
        private Game m_game;

        private Panel[,] m_environment;
        private WorldMapWindow m_worldMap;

        public MainWindow()
        {
            InitializeComponent();
            GameToolStripEnabled(false);
        }

        private void GameToolStripEnabled(bool enabled) => gameToolStripMenuItem.Enabled = enabled;

        private void ShowWorldMap() => m_worldMap.Show();

        private void Form_Load() //TODO: put panels into one panel before adding to main control
        {
            const int tileSize = 30;
            const int gridSize = 10;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            m_environment = new Panel[gridSize, gridSize];

            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m)
                    };

                    Controls.Add(newPanel);

                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }
        }

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerWindow(AddPlayer))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_game.AddPlayer(form.Player);
                }
            }
        }

        private void editPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerListWindow(m_game.Players, EditPlayer))
            {
                form.ShowDialog();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_game != null)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to start a new game? " +
                    "All data will be lost.", "Warning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    return;

                GameToolStripEnabled(false);
                m_worldMap.Close();
                m_worldMap.Dispose(); // this is needed as we override OnFormClosing()
            }

            //Form_Load();

            using (var form = new SettingsWindow())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_game = new Game(form.Settings);
                    m_worldMap = new WorldMapWindow(form.Settings);
                    ShowWorldMap();
                    GameToolStripEnabled(true);
                }
            }
        }

        private void showWorldMapToolStripMenuItem_Click(object sender, EventArgs e) =>
            ShowWorldMap();
    }
}

﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PopulationWars.Mechanics;

using static System.Drawing.Color;
using static PopulationWars.Utilities.Constants.GameAction;
using System.Linq;
using System.Collections.Generic;
using PopulationWars.Components;
using static PopulationWars.Utilities.Constants;

namespace PopulationWars
{
    public partial class MainWindow : Form
    {
        private Game m_game;
        private List<Nation> m_nations;
        private List<TrainSet> m_trainSets;

        private GameType m_gameType;
        private int m_gaPlayers;
        private int m_gaGenerations;
        private int m_gaCurrentGen;

        private Panel[,] m_environment;
        private WorldMapWindow m_worldMap;

        public MainWindow()
        {
            InitializeComponent();
            GameToolStripEnabled(false);
            LoadData();
        }

        private void ClearAndLoadEnvironment(Tuple<int, int> position = null) =>
            environmentPanel.Invoke((MethodInvoker)delegate
            {
                ClearEnvironmentPanel();
                LoadEnvironment(position);
            });

        private void ClearEnvironmentPanel() => environmentPanel.Controls.Clear();

        private void GameControlGroupBox(bool enabled) =>
            gameControlGroupBox.Invoke((MethodInvoker)delegate
            {
                if (enabled)
                    PreselectDirection();

                gameControlGroupBox.Enabled = enabled;
            });

        private void GameplayControlGroupBoxEnabled(bool enabled) =>
            gameplayControlGroupBox.Enabled = enabled;

        private void GameToolStripEnabled(bool enabled) => gameToolStripMenuItem.Enabled = enabled;

        private void LoadEnvironment(Tuple<int, int> position = null)
        {
            const int panelSize = 450;
            int gridSize = 2 * m_game.Settings.ColonyScope + 1;
            int tileSize = panelSize / (2 * m_game.Settings.ColonyScope + 1);

            m_environment = new Panel[gridSize, gridSize];

            int x = (position?.Item1 ?? m_game.Settings.WorldSize.Item1 / 2)
                - m_game.Settings.ColonyScope + 1;
            int y = (position?.Item2 ?? m_game.Settings.WorldSize.Item2 / 2)
                - m_game.Settings.ColonyScope + 1;
            int sizeX = m_game.Settings.WorldSize.Item1;
            int sizeY = m_game.Settings.WorldSize.Item2;

            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    Panel tile = null;
                    if (x > 0 && x <= sizeX && y > 0 && y <= sizeY)
                    {
                        var originalTile = m_worldMap.GetTile(Tuple.Create(x, y));
                        var originalLabel = originalTile.Controls.OfType<Label>().FirstOrDefault();

                        tile = new Panel { BackColor = originalTile.BackColor };

                        if (originalLabel != null)
                            tile.Controls.Add(new Label
                            {
                                /* centers the label but removes the center tile's border
                                AutoSize = false,
                                Dock = DockStyle.Fill, 
                                */
                                AutoSize = originalLabel.AutoSize,
                                Dock = originalLabel.Dock,
                                ForeColor = originalLabel.ForeColor,
                                Text = originalLabel.Text,
                                TextAlign = originalLabel.TextAlign
                            });

                        if (n == m && m == gridSize / 2)
                        {
                            tile.Paint += centerPanel_Paint;
                        }
                    }
                    else
                        tile = new Panel { BackColor = Black };

                    tile.Size = new Size(tileSize, tileSize);
                    tile.Location = new Point(tileSize * n, tileSize * m);
                    environmentPanel.Controls.Add(tile);
                    ++y;
                }
                y = y - gridSize;
                ++x;
            }
        }

        private void LoadData()
        {
            m_nations = DataParser.Deserialize() ?? new List<Nation>();
            m_trainSets = DataParser.Deserialize(true) ?? new List<TrainSet>();

        }

        private void PlayersAndControlsPanelEnabled(bool enabled) =>
            playersAndControlsPanel.Enabled = enabled;

        private void PlayersAndStartGameToolStripsEnabled(bool enabled) =>
            addPlayerToolStripMenuItem.Enabled = editPlayerToolStripMenuItem.Enabled =
            deletePlayerToolStripMenuItem.Enabled = startGameToolStripMenuItem.Enabled = enabled;

        private void PreselectDirection() => directionGroupBox.Controls.OfType<RadioButton>()
            .First(b => Convert.ToInt32(b.Tag) == 0).Checked = true;
        private void RefreshPlayerListBox()
        {
            playerListBox.Items.Clear();
            playerListBox.Items.AddRange(m_game.Players.ToArray());
        }

        private void ResetGameToolStripEnabled(bool enabled) =>
            resetGameToolStripMenuItem.Enabled = enabled;

        private void ShowGameResult()
        {
            if (m_gameType == GameType.Normal)
            {

                var players = m_game.Players.OrderByDescending(player => player.Colonies.Count);

                m_trainSets.AddRange(m_game.Gameplay.TrainSets);
                DataParser.Serialize(m_trainSets);

                Invoke((MethodInvoker)delegate
                {
                    ResetGameToolStripEnabled(true);
                    GameplayControlGroupBoxEnabled(false);
                });

                MessageBox.Show("Game has finished! Here are the result:\n" +
                    players.Select(player => $"{player}: {player.Colonies.Count}").
                    Aggregate((p1, p2) => p1 + "\n" + p2), "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ClearEnvironmentPanel();
                m_worldMap.Close();
                m_worldMap.Dispose(); // this is needed as we override OnFormClosing()

                var players = m_game.Players;
                players.ForEach(player => player.Colonies.Clear());

                ShowWorldMap();
                GameToolStripEnabled(true);
                PlayersAndStartGameToolStripsEnabled(true);
                ResetGameToolStripEnabled(false);
                LoadEnvironment();

                GaCycle(++m_gaCurrentGen);
            }
        }

        private void ShowWorldMap() => m_worldMap.Show();

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerWindow(AddPlayer, m_game.Players, m_nations))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_game.AddPlayer(form.Player);
                    RefreshPlayerListBox();
                }
            }
        }

        private void deletePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerListWindow(m_game.Players, null, null, null, DeletePlayer))
            {
                form.ShowDialog();
                RefreshPlayerListBox();
            }
        }

        private void editPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerListWindow(m_game.Players, m_nations, null, null,
                EditPlayer))
            {
                form.ShowDialog();
                RefreshPlayerListBox();
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
                ClearEnvironmentPanel();
                m_worldMap.Close();
                m_worldMap.Dispose(); // this is needed as we override OnFormClosing()
            }

            using (var form = new SettingsWindow())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_game = new Game(form.Settings);
                    m_worldMap = new WorldMapWindow(form.Settings);
                    ShowWorldMap();
                    GameToolStripEnabled(true);
                    PlayersAndStartGameToolStripsEnabled(true);
                    ResetGameToolStripEnabled(false);
                    PlayersAndControlsPanelEnabled(true);
                    LoadEnvironment();
                }
            }
        }

        private void showWorldMapToolStripMenuItem_Click(object sender, EventArgs e) =>
            ShowWorldMap();

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_game.Players.Count < 2)
            {
                MessageBox.Show("You have to add at least 2 players to start a game.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show("You are going to start a game. After that, you " +
                "will not be able to change players. Continue?", "Information",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.No)
                return;

            PlayersAndStartGameToolStripsEnabled(false);
            GameplayControlGroupBoxEnabled(true);
            m_game.StartGame(m_worldMap.UpdateTile, ClearAndLoadEnvironment, ShowGameResult,
                GameControlGroupBox, m_gameType = GameType.Normal);
        }

        private void simulationSpeedNumericUpDown_ValueChanged(object sender, EventArgs e) =>
            m_game.Gameplay.Speed = (int)Math.Pow(2, (int)simulationSpeedNumericUpDown.Value - 1);

        private void nextPlayerTurnButton_Click(object sender, EventArgs e) =>
            m_game.Gameplay.SkipPlayerTurn = true;

        private void nextGameTurnButton_Click(object sender, EventArgs e) =>
            m_game.Gameplay.SkipGameTurn = true;

        private void holdOnContinueButton_Click(object sender, EventArgs e)
        {
            m_game.Gameplay.HoldOn = !m_game.Gameplay.HoldOn;
            holdOnContinueButton.Text = holdOnContinueButton.Text == "Hold on" ?
                "Continue" : "Hold on";
        }

        private void resetGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("You are going to reset game state. All players " +
                "will remain. Continue?", "Information", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (dialogResult == DialogResult.No)
                return;

            ClearEnvironmentPanel();
            m_worldMap.Close();
            m_worldMap.Dispose(); // this is needed as we override OnFormClosing()

            using (var form = new SettingsWindow())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var players = m_game.Players;
                    players.ForEach(player => player.Colonies.Clear());

                    m_game = new Game(form.Settings, players);
                    m_worldMap = new WorldMapWindow(form.Settings);
                    ShowWorldMap();
                    GameToolStripEnabled(true);
                    PlayersAndStartGameToolStripsEnabled(true);
                    ResetGameToolStripEnabled(false);
                    LoadEnvironment();
                }
            }
        }

        private void makeMoveButton_Click(object sender, EventArgs e)
        {
            //var direction = (Direction)directionListBox.SelectedIndex;
            var direction = (Direction)Convert.
                ToInt32(directionGroupBox.Controls.OfType<RadioButton>().
                First(b => b.Checked).Tag);
            var populationToMove = (int)populationNumericUpDown.Value;

            m_game.Gameplay.PlayerDecision =
                new Decision(direction != Direction.None, direction, populationToMove / 100.0);
            m_game.Gameplay.SkipHumanPlayerTurn = skipCheckBox.Checked;
            skipCheckBox.Checked = false;
            m_game.Gameplay.HoldOn = false;
        }

        private void trainNationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PlayerListWindow(null, m_nations, null, m_trainSets,
                TrainNationSelectNation))
            {
                form.ShowDialog();
            }
        }

        private void saveNationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("You are going to save all nations to file and " +
                " override any existing save. Continue?", "Information", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (dialogResult == DialogResult.No)
                return;

            DataParser.Serialize(m_nations);
        }

        private void centerPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = 4;
            Pen pen = new Pen(White, width);
            g.DrawRectangle(pen, width / 2, width / 2, e.ClipRectangle.Width - width,
                e.ClipRectangle.Height - width);
            pen.Dispose();
        }

        private void gAGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new GADialog())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_gameType = GameType.GaGame;
                    m_gaPlayers = form.NumberOfPlayers;
                    m_gaGenerations = form.NumberOfGenerations;
                    GaCycle(m_gaCurrentGen = 0);
                }
            }
        }

        private void GaCycle(int currentGeneration)
        {
            var gen = currentGeneration;

            if (currentGeneration == 0) // create new players
            {

                for (var i = 0; i < m_gaPlayers; ++i)
                {
                    //m_game.AddPlayer(new Player(i + gen, true, new Nation(i + gen, /**/);
                }

            }
            else if (currentGeneration < m_gaGenerations) // delete worst players, copy best ones and mutate them
            {

            }
            else
            {
                // save the best
            }

           
            PlayersAndStartGameToolStripsEnabled(false);
            GameplayControlGroupBoxEnabled(true);
            m_game.StartGame(m_worldMap.UpdateTile, ClearAndLoadEnvironment, ShowGameResult,
                 GameControlGroupBox, GameType.GaGame);
        }

    }
}

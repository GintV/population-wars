using System.Drawing;
using System.Windows.Forms;

namespace PopulationWars
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.trainNationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showWorldMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.environmentPanel = new System.Windows.Forms.Panel();
            this.playersAndControlsPanel = new System.Windows.Forms.Panel();
            this.gameControlGroupBox = new System.Windows.Forms.GroupBox();
            this.directionGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.populationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.makeMoveButton = new System.Windows.Forms.Button();
            this.advancedModeRadioButton = new System.Windows.Forms.RadioButton();
            this.normalModeradioButton = new System.Windows.Forms.RadioButton();
            this.playerListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gameplayControlPanel = new System.Windows.Forms.Panel();
            this.gameplayControlGroupBox = new System.Windows.Forms.GroupBox();
            this.holdOnContinueButton = new System.Windows.Forms.Button();
            this.nextPlayerTurnButton = new System.Windows.Forms.Button();
            this.nextGameTurnButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.simulationSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.skipCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.playersAndControlsPanel.SuspendLayout();
            this.gameControlGroupBox.SuspendLayout();
            this.directionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationNumericUpDown)).BeginInit();
            this.gameplayControlPanel.SuspendLayout();
            this.gameplayControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationSpeedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator4,
            this.trainNationToolStripMenuItem,
            this.saveNationsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newGameToolStripMenuItem.Text = "New Game...";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(148, 6);
            // 
            // trainNationToolStripMenuItem
            // 
            this.trainNationToolStripMenuItem.Name = "trainNationToolStripMenuItem";
            this.trainNationToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.trainNationToolStripMenuItem.Text = "Train Nation...";
            this.trainNationToolStripMenuItem.Click += new System.EventHandler(this.trainNationToolStripMenuItem_Click);
            // 
            // saveNationsToolStripMenuItem
            // 
            this.saveNationsToolStripMenuItem.Name = "saveNationsToolStripMenuItem";
            this.saveNationsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveNationsToolStripMenuItem.Text = "Save Nations...";
            this.saveNationsToolStripMenuItem.Click += new System.EventHandler(this.saveNationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem,
            this.resetGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.addPlayerToolStripMenuItem,
            this.editPlayerToolStripMenuItem,
            this.deletePlayerToolStripMenuItem,
            this.toolStripSeparator2,
            this.showWorldMapToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.startGameToolStripMenuItem.Text = "Start game...";
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.startGameToolStripMenuItem_Click);
            // 
            // resetGameToolStripMenuItem
            // 
            this.resetGameToolStripMenuItem.Name = "resetGameToolStripMenuItem";
            this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.resetGameToolStripMenuItem.Text = "Reset game...";
            this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.resetGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // addPlayerToolStripMenuItem
            // 
            this.addPlayerToolStripMenuItem.Name = "addPlayerToolStripMenuItem";
            this.addPlayerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addPlayerToolStripMenuItem.Text = "Add Player...";
            this.addPlayerToolStripMenuItem.Click += new System.EventHandler(this.addPlayerToolStripMenuItem_Click);
            // 
            // editPlayerToolStripMenuItem
            // 
            this.editPlayerToolStripMenuItem.Name = "editPlayerToolStripMenuItem";
            this.editPlayerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.editPlayerToolStripMenuItem.Text = "Edit Player...";
            this.editPlayerToolStripMenuItem.Click += new System.EventHandler(this.editPlayerToolStripMenuItem_Click);
            // 
            // deletePlayerToolStripMenuItem
            // 
            this.deletePlayerToolStripMenuItem.Name = "deletePlayerToolStripMenuItem";
            this.deletePlayerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.deletePlayerToolStripMenuItem.Text = "Delete Player...";
            this.deletePlayerToolStripMenuItem.Click += new System.EventHandler(this.deletePlayerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // showWorldMapToolStripMenuItem
            // 
            this.showWorldMapToolStripMenuItem.Name = "showWorldMapToolStripMenuItem";
            this.showWorldMapToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showWorldMapToolStripMenuItem.Text = "Show World Map...";
            this.showWorldMapToolStripMenuItem.Click += new System.EventHandler(this.showWorldMapToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(854, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.39579F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.60421F));
            this.tableLayoutPanel.Controls.Add(this.environmentPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.playersAndControlsPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.gameplayControlPanel, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.00735F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.99265F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(854, 544);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // environmentPanel
            // 
            this.environmentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.environmentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentPanel.Location = new System.Drawing.Point(3, 3);
            this.environmentPanel.Name = "environmentPanel";
            this.environmentPanel.Size = new System.Drawing.Size(450, 450);
            this.environmentPanel.TabIndex = 0;
            // 
            // playersAndControlsPanel
            // 
            this.playersAndControlsPanel.Controls.Add(this.gameControlGroupBox);
            this.playersAndControlsPanel.Controls.Add(this.playerListBox);
            this.playersAndControlsPanel.Controls.Add(this.label1);
            this.playersAndControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersAndControlsPanel.Enabled = false;
            this.playersAndControlsPanel.Location = new System.Drawing.Point(459, 3);
            this.playersAndControlsPanel.Name = "playersAndControlsPanel";
            this.playersAndControlsPanel.Size = new System.Drawing.Size(392, 450);
            this.playersAndControlsPanel.TabIndex = 1;
            // 
            // gameControlGroupBox
            // 
            this.gameControlGroupBox.Controls.Add(this.skipCheckBox);
            this.gameControlGroupBox.Controls.Add(this.directionGroupBox);
            this.gameControlGroupBox.Controls.Add(this.label4);
            this.gameControlGroupBox.Controls.Add(this.numericUpDown1);
            this.gameControlGroupBox.Controls.Add(this.label3);
            this.gameControlGroupBox.Controls.Add(this.populationNumericUpDown);
            this.gameControlGroupBox.Controls.Add(this.makeMoveButton);
            this.gameControlGroupBox.Controls.Add(this.advancedModeRadioButton);
            this.gameControlGroupBox.Controls.Add(this.normalModeradioButton);
            this.gameControlGroupBox.Enabled = false;
            this.gameControlGroupBox.Location = new System.Drawing.Point(3, 219);
            this.gameControlGroupBox.Name = "gameControlGroupBox";
            this.gameControlGroupBox.Size = new System.Drawing.Size(386, 216);
            this.gameControlGroupBox.TabIndex = 2;
            this.gameControlGroupBox.TabStop = false;
            this.gameControlGroupBox.Text = "Game controls";
            // 
            // directionGroupBox
            // 
            this.directionGroupBox.Controls.Add(this.radioButton9);
            this.directionGroupBox.Controls.Add(this.radioButton8);
            this.directionGroupBox.Controls.Add(this.radioButton7);
            this.directionGroupBox.Controls.Add(this.radioButton6);
            this.directionGroupBox.Controls.Add(this.radioButton5);
            this.directionGroupBox.Controls.Add(this.radioButton4);
            this.directionGroupBox.Controls.Add(this.radioButton3);
            this.directionGroupBox.Controls.Add(this.radioButton2);
            this.directionGroupBox.Controls.Add(this.radioButton1);
            this.directionGroupBox.Location = new System.Drawing.Point(47, 19);
            this.directionGroupBox.Name = "directionGroupBox";
            this.directionGroupBox.Size = new System.Drawing.Size(114, 127);
            this.directionGroupBox.TabIndex = 9;
            this.directionGroupBox.TabStop = false;
            this.directionGroupBox.Text = "Direction";
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.BackgroundImage = global::PopulationWars.Properties.Resources.up;
            this.radioButton1.Location = new System.Drawing.Point(41, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(30, 30);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Colony";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(302, 89);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Population to move (%)";
            // 
            // populationNumericUpDown
            // 
            this.populationNumericUpDown.Location = new System.Drawing.Point(302, 64);
            this.populationNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.populationNumericUpDown.Name = "populationNumericUpDown";
            this.populationNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.populationNumericUpDown.TabIndex = 5;
            this.populationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // makeMoveButton
            // 
            this.makeMoveButton.Location = new System.Drawing.Point(47, 152);
            this.makeMoveButton.Name = "makeMoveButton";
            this.makeMoveButton.Size = new System.Drawing.Size(306, 58);
            this.makeMoveButton.TabIndex = 2;
            this.makeMoveButton.Text = "Make move";
            this.makeMoveButton.UseVisualStyleBackColor = true;
            this.makeMoveButton.Click += new System.EventHandler(this.makeMoveButton_Click);
            // 
            // advancedModeRadioButton
            // 
            this.advancedModeRadioButton.AutoSize = true;
            this.advancedModeRadioButton.Location = new System.Drawing.Point(260, 38);
            this.advancedModeRadioButton.Name = "advancedModeRadioButton";
            this.advancedModeRadioButton.Size = new System.Drawing.Size(103, 17);
            this.advancedModeRadioButton.TabIndex = 1;
            this.advancedModeRadioButton.Text = "Advanced mode";
            this.advancedModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // normalModeradioButton
            // 
            this.normalModeradioButton.AutoSize = true;
            this.normalModeradioButton.Checked = true;
            this.normalModeradioButton.Location = new System.Drawing.Point(167, 38);
            this.normalModeradioButton.Name = "normalModeradioButton";
            this.normalModeradioButton.Size = new System.Drawing.Size(87, 17);
            this.normalModeradioButton.TabIndex = 0;
            this.normalModeradioButton.TabStop = true;
            this.normalModeradioButton.Text = "Normal mode";
            this.normalModeradioButton.UseVisualStyleBackColor = true;
            // 
            // playerListBox
            // 
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.Location = new System.Drawing.Point(40, 58);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.playerListBox.Size = new System.Drawing.Size(316, 134);
            this.playerListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players";
            // 
            // gameplayControlPanel
            // 
            this.gameplayControlPanel.Controls.Add(this.gameplayControlGroupBox);
            this.gameplayControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameplayControlPanel.Location = new System.Drawing.Point(459, 459);
            this.gameplayControlPanel.Name = "gameplayControlPanel";
            this.gameplayControlPanel.Size = new System.Drawing.Size(392, 82);
            this.gameplayControlPanel.TabIndex = 2;
            // 
            // gameplayControlGroupBox
            // 
            this.gameplayControlGroupBox.Controls.Add(this.holdOnContinueButton);
            this.gameplayControlGroupBox.Controls.Add(this.nextPlayerTurnButton);
            this.gameplayControlGroupBox.Controls.Add(this.nextGameTurnButton);
            this.gameplayControlGroupBox.Controls.Add(this.label5);
            this.gameplayControlGroupBox.Controls.Add(this.simulationSpeedNumericUpDown);
            this.gameplayControlGroupBox.Enabled = false;
            this.gameplayControlGroupBox.Location = new System.Drawing.Point(3, 3);
            this.gameplayControlGroupBox.Name = "gameplayControlGroupBox";
            this.gameplayControlGroupBox.Size = new System.Drawing.Size(386, 75);
            this.gameplayControlGroupBox.TabIndex = 3;
            this.gameplayControlGroupBox.TabStop = false;
            this.gameplayControlGroupBox.Text = "Gameplay controls";
            // 
            // holdOnContinueButton
            // 
            this.holdOnContinueButton.Location = new System.Drawing.Point(174, 44);
            this.holdOnContinueButton.Name = "holdOnContinueButton";
            this.holdOnContinueButton.Size = new System.Drawing.Size(100, 25);
            this.holdOnContinueButton.TabIndex = 5;
            this.holdOnContinueButton.Text = "Hold on";
            this.holdOnContinueButton.UseVisualStyleBackColor = true;
            this.holdOnContinueButton.Click += new System.EventHandler(this.holdOnContinueButton_Click);
            // 
            // nextPlayerTurnButton
            // 
            this.nextPlayerTurnButton.Location = new System.Drawing.Point(280, 13);
            this.nextPlayerTurnButton.Name = "nextPlayerTurnButton";
            this.nextPlayerTurnButton.Size = new System.Drawing.Size(100, 25);
            this.nextPlayerTurnButton.TabIndex = 4;
            this.nextPlayerTurnButton.Text = "Next player turn";
            this.nextPlayerTurnButton.UseVisualStyleBackColor = true;
            this.nextPlayerTurnButton.Click += new System.EventHandler(this.nextPlayerTurnButton_Click);
            // 
            // nextGameTurnButton
            // 
            this.nextGameTurnButton.Location = new System.Drawing.Point(280, 44);
            this.nextGameTurnButton.Name = "nextGameTurnButton";
            this.nextGameTurnButton.Size = new System.Drawing.Size(100, 25);
            this.nextGameTurnButton.TabIndex = 3;
            this.nextGameTurnButton.Text = "Next game turn";
            this.nextGameTurnButton.UseVisualStyleBackColor = true;
            this.nextGameTurnButton.Click += new System.EventHandler(this.nextGameTurnButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Simulation speed";
            // 
            // simulationSpeedNumericUpDown
            // 
            this.simulationSpeedNumericUpDown.Location = new System.Drawing.Point(47, 40);
            this.simulationSpeedNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.simulationSpeedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simulationSpeedNumericUpDown.Name = "simulationSpeedNumericUpDown";
            this.simulationSpeedNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.simulationSpeedNumericUpDown.TabIndex = 0;
            this.simulationSpeedNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simulationSpeedNumericUpDown.ValueChanged += new System.EventHandler(this.simulationSpeedNumericUpDown_ValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.BackgroundImage = global::PopulationWars.Properties.Resources.up_right;
            this.radioButton2.Location = new System.Drawing.Point(77, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(30, 30);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "2";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.BackgroundImage = global::PopulationWars.Properties.Resources.up_left;
            this.radioButton3.Location = new System.Drawing.Point(5, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(30, 30);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "8";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.BackgroundImage = global::PopulationWars.Properties.Resources.left;
            this.radioButton4.Location = new System.Drawing.Point(5, 55);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(30, 30);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "7";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.BackgroundImage = global::PopulationWars.Properties.Resources.center;
            this.radioButton5.Location = new System.Drawing.Point(41, 55);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(30, 30);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Tag = "0";
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.BackgroundImage = global::PopulationWars.Properties.Resources.right;
            this.radioButton6.Location = new System.Drawing.Point(77, 55);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(30, 30);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Tag = "3";
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton7.BackgroundImage = global::PopulationWars.Properties.Resources.down_left;
            this.radioButton7.Location = new System.Drawing.Point(5, 91);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(30, 30);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Tag = "6";
            this.radioButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton8.BackgroundImage = global::PopulationWars.Properties.Resources.down;
            this.radioButton8.Location = new System.Drawing.Point(41, 91);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(30, 30);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Tag = "5";
            this.radioButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton9.BackgroundImage = global::PopulationWars.Properties.Resources.down_right;
            this.radioButton9.Location = new System.Drawing.Point(77, 91);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(30, 30);
            this.radioButton9.TabIndex = 8;
            this.radioButton9.TabStop = true;
            this.radioButton9.Tag = "4";
            this.radioButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // skipCheckBox
            // 
            this.skipCheckBox.AutoSize = true;
            this.skipCheckBox.Location = new System.Drawing.Point(167, 115);
            this.skipCheckBox.Name = "skipCheckBox";
            this.skipCheckBox.Size = new System.Drawing.Size(136, 17);
            this.skipCheckBox.TabIndex = 10;
            this.skipCheckBox.Text = "Skip the rest of the turn";
            this.skipCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(854, 568);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nation Wars";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.playersAndControlsPanel.ResumeLayout(false);
            this.playersAndControlsPanel.PerformLayout();
            this.gameControlGroupBox.ResumeLayout(false);
            this.gameControlGroupBox.PerformLayout();
            this.directionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationNumericUpDown)).EndInit();
            this.gameplayControlPanel.ResumeLayout(false);
            this.gameplayControlGroupBox.ResumeLayout(false);
            this.gameplayControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationSpeedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem addPlayerToolStripMenuItem;
        private ToolStripMenuItem editPlayerToolStripMenuItem;
        private ToolStripMenuItem showWorldMapToolStripMenuItem;
        private ToolStripMenuItem trainNationToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip;
        private ToolStripMenuItem deletePlayerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem startGameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private TableLayoutPanel tableLayoutPanel;
        private Panel environmentPanel;
        private Panel playersAndControlsPanel;
        private Panel gameplayControlPanel;
        private Label label1;
        private GroupBox gameControlGroupBox;
        private ListBox playerListBox;
        private GroupBox gameplayControlGroupBox;
        private Button makeMoveButton;
        private RadioButton advancedModeRadioButton;
        private RadioButton normalModeradioButton;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private NumericUpDown populationNumericUpDown;
        private Button nextPlayerTurnButton;
        private Button nextGameTurnButton;
        private Label label5;
        private NumericUpDown simulationSpeedNumericUpDown;
        private Button holdOnContinueButton;
        private ToolStripMenuItem resetGameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem saveNationsToolStripMenuItem;
        private GroupBox directionGroupBox;
        private RadioButton radioButton1;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private CheckBox skipCheckBox;
    }
}


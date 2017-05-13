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
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWorldMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.saveNationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newGameToolStripMenuItem.Text = "New Game...";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPlayerToolStripMenuItem,
            this.editPlayerToolStripMenuItem,
            this.showWorldMapToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gameToolStripMenuItem.Text = "Game...";
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
            // 
            // showWorldMapToolStripMenuItem
            // 
            this.showWorldMapToolStripMenuItem.Name = "showWorldMapToolStripMenuItem";
            this.showWorldMapToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showWorldMapToolStripMenuItem.Text = "Show World Map...";
            this.showWorldMapToolStripMenuItem.Click += new System.EventHandler(this.showWorldMapToolStripMenuItem_Click);
            // 
            // saveNationToolStripMenuItem
            // 
            this.saveNationToolStripMenuItem.Name = "saveNationToolStripMenuItem";
            this.saveNationToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveNationToolStripMenuItem.Text = "Save Nation...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(806, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(806, 543);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nation Wars";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private ToolStripMenuItem saveNationToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip;
    }
}


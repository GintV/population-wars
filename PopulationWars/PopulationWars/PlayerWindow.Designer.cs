﻿namespace PopulationWars
{
    partial class PlayerWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nationListBox = new System.Windows.Forms.ListBox();
            this.nationNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nationGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.governmentListBox = new System.Windows.Forms.ListBox();
            this.typeListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(161, 38);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Color";
            // 
            // nationListBox
            // 
            this.nationListBox.FormattingEnabled = true;
            this.nationListBox.Items.AddRange(new object[] {
            "New Nation..."});
            this.nationListBox.Location = new System.Drawing.Point(9, 54);
            this.nationListBox.Name = "nationListBox";
            this.nationListBox.Size = new System.Drawing.Size(100, 69);
            this.nationListBox.TabIndex = 9;
            this.nationListBox.SelectedIndexChanged += new System.EventHandler(this.nationListBox_SelectedIndexChanged);
            // 
            // nationNameTextBox
            // 
            this.nationNameTextBox.Location = new System.Drawing.Point(115, 54);
            this.nationNameTextBox.Name = "nationNameTextBox";
            this.nationNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nationNameTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "New nation name";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Black;
            this.colorButton.Location = new System.Drawing.Point(161, 64);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(100, 23);
            this.colorButton.TabIndex = 12;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(34, 316);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 25);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(179, 316);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nationGroupBox
            // 
            this.nationGroupBox.Controls.Add(this.label4);
            this.nationGroupBox.Controls.Add(this.governmentListBox);
            this.nationGroupBox.Controls.Add(this.nationListBox);
            this.nationGroupBox.Controls.Add(this.nationNameTextBox);
            this.nationGroupBox.Controls.Add(this.label5);
            this.nationGroupBox.Location = new System.Drawing.Point(43, 170);
            this.nationGroupBox.Name = "nationGroupBox";
            this.nationGroupBox.Size = new System.Drawing.Size(226, 129);
            this.nationGroupBox.TabIndex = 15;
            this.nationGroupBox.TabStop = false;
            this.nationGroupBox.Text = "Nation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Copy nation from";
            // 
            // governmentListBox
            // 
            this.governmentListBox.FormattingEnabled = true;
            this.governmentListBox.Items.AddRange(new object[] {
            "Anarchy",
            "HomeGrownNetwork",
            "AForgeNetwork",
            "AgentBot"});
            this.governmentListBox.Location = new System.Drawing.Point(115, 80);
            this.governmentListBox.Name = "governmentListBox";
            this.governmentListBox.Size = new System.Drawing.Size(100, 43);
            this.governmentListBox.TabIndex = 12;
            // 
            // typeListBox
            // 
            this.typeListBox.FormattingEnabled = true;
            this.typeListBox.Items.AddRange(new object[] {
            "Agent",
            "Human"});
            this.typeListBox.Location = new System.Drawing.Point(161, 109);
            this.typeListBox.Name = "typeListBox";
            this.typeListBox.Size = new System.Drawing.Size(100, 30);
            this.typeListBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Type";
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 375);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeListBox);
            this.Controls.Add(this.nationGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "PlayerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.nationGroupBox.ResumeLayout(false);
            this.nationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox nationListBox;
        private System.Windows.Forms.TextBox nationNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox nationGroupBox;
        private System.Windows.Forms.ListBox typeListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox governmentListBox;
        private System.Windows.Forms.Label label4;
    }
}
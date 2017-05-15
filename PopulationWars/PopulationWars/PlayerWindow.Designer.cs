namespace PopulationWars
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
            this.label3 = new System.Windows.Forms.Label();
            this.nationListBox = new System.Windows.Forms.ListBox();
            this.nationNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nationGroupBox = new System.Windows.Forms.GroupBox();
            this.humanRadioButton = new System.Windows.Forms.RadioButton();
            this.agentRadioButton = new System.Windows.Forms.RadioButton();
            this.agentsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addAgentButton = new System.Windows.Forms.Button();
            this.nationGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Color";
            // 
            // nationListBox
            // 
            this.nationListBox.FormattingEnabled = true;
            this.nationListBox.Items.AddRange(new object[] {
            "New Nation..."});
            this.nationListBox.Location = new System.Drawing.Point(9, 35);
            this.nationListBox.Name = "nationListBox";
            this.nationListBox.Size = new System.Drawing.Size(100, 69);
            this.nationListBox.TabIndex = 9;
            // 
            // nationNameTextBox
            // 
            this.nationNameTextBox.Location = new System.Drawing.Point(118, 35);
            this.nationNameTextBox.Name = "nationNameTextBox";
            this.nationNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nationNameTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nation name (oponal)";
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
            this.saveButton.Location = new System.Drawing.Point(34, 371);
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
            this.cancelButton.Location = new System.Drawing.Point(179, 371);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nationGroupBox
            // 
            this.nationGroupBox.Controls.Add(this.nationListBox);
            this.nationGroupBox.Controls.Add(this.nationNameTextBox);
            this.nationGroupBox.Controls.Add(this.label5);
            this.nationGroupBox.Location = new System.Drawing.Point(43, 228);
            this.nationGroupBox.Name = "nationGroupBox";
            this.nationGroupBox.Size = new System.Drawing.Size(226, 125);
            this.nationGroupBox.TabIndex = 15;
            this.nationGroupBox.TabStop = false;
            this.nationGroupBox.Text = "Nation";
            // 
            // humanRadioButton
            // 
            this.humanRadioButton.AutoSize = true;
            this.humanRadioButton.Location = new System.Drawing.Point(6, 19);
            this.humanRadioButton.Name = "humanRadioButton";
            this.humanRadioButton.Size = new System.Drawing.Size(59, 17);
            this.humanRadioButton.TabIndex = 16;
            this.humanRadioButton.TabStop = true;
            this.humanRadioButton.Text = "Human";
            this.humanRadioButton.UseVisualStyleBackColor = true;
            this.humanRadioButton.CheckedChanged += new System.EventHandler(this.humanRadioButton_CheckedChanged);
            // 
            // agentRadioButton
            // 
            this.agentRadioButton.AutoSize = true;
            this.agentRadioButton.Location = new System.Drawing.Point(6, 42);
            this.agentRadioButton.Name = "agentRadioButton";
            this.agentRadioButton.Size = new System.Drawing.Size(53, 17);
            this.agentRadioButton.TabIndex = 17;
            this.agentRadioButton.TabStop = true;
            this.agentRadioButton.Text = "Agent";
            this.agentRadioButton.UseVisualStyleBackColor = true;
            this.agentRadioButton.CheckedChanged += new System.EventHandler(this.agentRadioButton_CheckedChanged);
            // 
            // agentsListBox
            // 
            this.agentsListBox.FormattingEnabled = true;
            this.agentsListBox.Location = new System.Drawing.Point(6, 65);
            this.agentsListBox.Name = "agentsListBox";
            this.agentsListBox.Size = new System.Drawing.Size(185, 56);
            this.agentsListBox.Sorted = true;
            this.agentsListBox.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addAgentButton);
            this.groupBox1.Controls.Add(this.humanRadioButton);
            this.groupBox1.Controls.Add(this.agentsListBox);
            this.groupBox1.Controls.Add(this.agentRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(43, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 129);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // addAgentButton
            // 
            this.addAgentButton.Location = new System.Drawing.Point(197, 65);
            this.addAgentButton.Name = "addAgentButton";
            this.addAgentButton.Size = new System.Drawing.Size(23, 23);
            this.addAgentButton.TabIndex = 19;
            this.addAgentButton.Text = "+";
            this.addAgentButton.UseVisualStyleBackColor = true;
            this.addAgentButton.Click += new System.EventHandler(this.addAgentButton_Click);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nationGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "PlayerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.nationGroupBox.ResumeLayout(false);
            this.nationGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox nationListBox;
        private System.Windows.Forms.TextBox nationNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox nationGroupBox;
        private System.Windows.Forms.RadioButton humanRadioButton;
        private System.Windows.Forms.RadioButton agentRadioButton;
        private System.Windows.Forms.ListBox agentsListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addAgentButton;
    }
}
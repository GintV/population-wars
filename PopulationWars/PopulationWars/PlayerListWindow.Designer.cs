namespace PopulationWars
{
    partial class PlayerListWindow
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
            this.playerListBox = new System.Windows.Forms.ListBox();
            this.editDeletebutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerListBox
            // 
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.Location = new System.Drawing.Point(28, 25);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.playerListBox.Size = new System.Drawing.Size(229, 173);
            this.playerListBox.TabIndex = 0;
            // 
            // editDeletebutton
            // 
            this.editDeletebutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.editDeletebutton.Location = new System.Drawing.Point(28, 220);
            this.editDeletebutton.Name = "editDeletebutton";
            this.editDeletebutton.Size = new System.Drawing.Size(100, 25);
            this.editDeletebutton.TabIndex = 1;
            this.editDeletebutton.UseVisualStyleBackColor = true;
            this.editDeletebutton.Click += new System.EventHandler(this.editDeletebutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(157, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // PlayerListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editDeletebutton);
            this.Controls.Add(this.playerListBox);
            this.Name = "PlayerListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox playerListBox;
        private System.Windows.Forms.Button editDeletebutton;
        private System.Windows.Forms.Button cancelButton;
    }
}
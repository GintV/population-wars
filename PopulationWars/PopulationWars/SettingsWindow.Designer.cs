namespace PopulationWars
{
    partial class SettingsWindow
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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colonyScopeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameDurationMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gameDurationMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.growthRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.worldWidthNmericUpDown = new System.Windows.Forms.NumericUpDown();
            this.worldHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.colonyScopeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDurationMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDurationMaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.growthRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthNmericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(60, 163);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 25);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Ok";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(221, 163);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Colony scope";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game duration in turns (min, max)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Population growth rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "World size (width, height)";
            // 
            // colonyScopeNumericUpDown
            // 
            this.colonyScopeNumericUpDown.Location = new System.Drawing.Point(255, 27);
            this.colonyScopeNumericUpDown.Name = "colonyScopeNumericUpDown";
            this.colonyScopeNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.colonyScopeNumericUpDown.TabIndex = 12;
            // 
            // gameDurationMinNumericUpDown
            // 
            this.gameDurationMinNumericUpDown.Location = new System.Drawing.Point(221, 53);
            this.gameDurationMinNumericUpDown.Name = "gameDurationMinNumericUpDown";
            this.gameDurationMinNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gameDurationMinNumericUpDown.TabIndex = 13;
            // 
            // gameDurationMaxNumericUpDown
            // 
            this.gameDurationMaxNumericUpDown.Location = new System.Drawing.Point(290, 53);
            this.gameDurationMaxNumericUpDown.Name = "gameDurationMaxNumericUpDown";
            this.gameDurationMaxNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.gameDurationMaxNumericUpDown.TabIndex = 14;
            // 
            // growthRateNumericUpDown
            // 
            this.growthRateNumericUpDown.Location = new System.Drawing.Point(254, 79);
            this.growthRateNumericUpDown.Name = "growthRateNumericUpDown";
            this.growthRateNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.growthRateNumericUpDown.TabIndex = 15;
            // 
            // worldWidthNmericUpDown
            // 
            this.worldWidthNmericUpDown.Location = new System.Drawing.Point(221, 105);
            this.worldWidthNmericUpDown.Name = "worldWidthNmericUpDown";
            this.worldWidthNmericUpDown.Size = new System.Drawing.Size(51, 20);
            this.worldWidthNmericUpDown.TabIndex = 16;
            // 
            // worldHeightNumericUpDown
            // 
            this.worldHeightNumericUpDown.Location = new System.Drawing.Point(290, 105);
            this.worldHeightNumericUpDown.Name = "worldHeightNumericUpDown";
            this.worldHeightNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.worldHeightNumericUpDown.TabIndex = 17;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 215);
            this.Controls.Add(this.worldHeightNumericUpDown);
            this.Controls.Add(this.worldWidthNmericUpDown);
            this.Controls.Add(this.growthRateNumericUpDown);
            this.Controls.Add(this.gameDurationMaxNumericUpDown);
            this.Controls.Add(this.gameDurationMinNumericUpDown);
            this.Controls.Add(this.colonyScopeNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose game settings";
            ((System.ComponentModel.ISupportInitialize)(this.colonyScopeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDurationMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameDurationMaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.growthRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldWidthNmericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldHeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown colonyScopeNumericUpDown;
        private System.Windows.Forms.NumericUpDown gameDurationMinNumericUpDown;
        private System.Windows.Forms.NumericUpDown gameDurationMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown growthRateNumericUpDown;
        private System.Windows.Forms.NumericUpDown worldWidthNmericUpDown;
        private System.Windows.Forms.NumericUpDown worldHeightNumericUpDown;
    }
}
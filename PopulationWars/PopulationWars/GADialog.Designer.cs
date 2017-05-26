namespace PopulationWars
{
    partial class GADialog
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
            this.playersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.generationsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Agents";
            // 
            // playersNumericUpDown
            // 
            this.playersNumericUpDown.Location = new System.Drawing.Point(78, 74);
            this.playersNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.playersNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.playersNumericUpDown.Name = "playersNumericUpDown";
            this.playersNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.playersNumericUpDown.TabIndex = 1;
            this.playersNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Generations";
            // 
            // generationsNumericUpDown
            // 
            this.generationsNumericUpDown.Location = new System.Drawing.Point(78, 164);
            this.generationsNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.generationsNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.generationsNumericUpDown.Name = "generationsNumericUpDown";
            this.generationsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.generationsNumericUpDown.TabIndex = 3;
            this.generationsNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(29, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(157, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // GADialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generationsNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playersNumericUpDown);
            this.Controls.Add(this.label1);
            this.Name = "GADialog";
            this.Text = "New GA Game";
            ((System.ComponentModel.ISupportInitialize)(this.playersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown playersNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown generationsNumericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
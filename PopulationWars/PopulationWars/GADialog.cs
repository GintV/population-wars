using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopulationWars
{
    public partial class GADialog : Form
    {
        public int NumberOfPlayers { get; set; }
        public int NumberOfGenerations { get; set; }

        public GADialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberOfPlayers = (int)playersNumericUpDown.Value;
            NumberOfGenerations = (int)generationsNumericUpDown.Value;
        }
    }
}

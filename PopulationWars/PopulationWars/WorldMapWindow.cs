using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopulationWars.Utilities;


namespace PopulationWars
{
    public partial class WorldMapWindow : Form
    {
        private Panel[,] m_map;

        public WorldMapWindow()
        {
            InitializeComponent();
            LoadMap();
        }

        private void LoadMap()
        {
            const int tileSize = 20;
            Tuple<int, int> size = Settings.GameSettings.WorldSize;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            m_map = new Panel[size.Item2 + 2, size.Item1 + 2];

            for (var m = 0; m < size.Item1 + 2; ++m)
            {
                for (var n = 0; n < size.Item2 + 2; ++n)
                {
                    var panel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m),
                        BackColor = (m + n) % 2 == 0 ? Color.WhiteSmoke : Color.White
                    };

                    if (m == 0 || m == size.Item1 + 1 || n == 0 || n == size.Item2 + 1)
                    {
                        panel.BackColor = Color.Black;
                        panel.BorderStyle = BorderStyle.None;

                        if (!(m == 0 && n == 0) && !(m == size.Item1 + 1 && n == size.Item2 + 1) &&
                            !(m == 0 && n == size.Item2 + 1) && !(m == size.Item1 + 1 && n == 0))
                        {
                            panel.Controls.Add(new Label()
                            {
                                Text = (m == size.Item1 + 1 || n == size.Item2 + 1 ?
                                    Math.Min(m, n) : Math.Max(m, n)).ToString(),
                                ForeColor = Color.Yellow,
                                Font = new Font(Font, FontStyle.Bold)
                            });
                        }
                    }

                    this.Controls.Add(panel);
                    m_map[n, m] = panel;
                }
            }
        }
    }
}

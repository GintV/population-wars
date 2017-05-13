using System;
using System.Drawing;
using System.Windows.Forms;
using PopulationWars.Utilities;

using static System.Drawing.Color;
using static System.Math;

namespace PopulationWars
{
    public partial class WorldMapWindow : Form
    {
        private Panel[,] m_map;

        public WorldMapWindow(Settings settings)
        {
            InitializeComponent();
            LoadMap(settings);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Hide();
            e.Cancel = true;
        }

        private void LoadMap(Settings settings)
        {
            const int tileSize = 20;
            Tuple<int, int> size = settings.WorldSize;
            var clr1 = DarkGray;
            var clr2 = White;

            m_map = new Panel[size.Item2 + 2, size.Item1 + 2];

            for (var m = 0; m < size.Item1 + 2; ++m)
            {
                for (var n = 0; n < size.Item2 + 2; ++n)
                {
                    var panel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m),
                        BackColor = (m + n) % 2 == 0 ? WhiteSmoke : White
                    };

                    if (m == 0 || m == size.Item1 + 1 || n == 0 || n == size.Item2 + 1)
                    {
                        panel.BackColor = Black;
                        panel.BorderStyle = BorderStyle.None;

                        if (!(m == 0 && n == 0) && !(m == size.Item1 + 1 && n == size.Item2 + 1) &&
                            !(m == 0 && n == size.Item2 + 1) && !(m == size.Item1 + 1 && n == 0))
                        {
                            panel.Controls.Add(new Label()
                            {
                                Text = (m == size.Item1 + 1 || n == size.Item2 + 1 ?
                                    Min(m, n) : Max(m, n)).ToString(),
                                ForeColor = Yellow,
                                Font = new Font(Font, FontStyle.Bold)
                            });
                        }
                    }

                    Controls.Add(panel);
                    m_map[n, m] = panel;
                }
            }
        }
    }
}

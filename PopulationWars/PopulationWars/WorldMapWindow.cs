using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PopulationWars.Utilities;

using static System.Drawing.Color;
using static System.Math;

namespace PopulationWars
{
    public partial class WorldMapWindow : Form
    {
        private Panel[][] m_map;
        private Settings m_settings;

        public WorldMapWindow(Settings settings)
        {
            InitializeComponent();
            LoadMap(settings);
            m_settings = settings;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Hide();
            e.Cancel = true;
        }

        public void UpdateTile(Tuple<int, int> position, Color color, int population = 0)
        {
            var x = position.Item1 + 1;
            var y = position.Item2 + 1;
            m_map[x][y].Invoke((MethodInvoker)delegate
            {
                var label = m_map[x][y].Controls.OfType<Label>().First();

                if (population < 1)
                {
                    label.Text = "";
                    m_map[x][y].BackColor = (x + y) % 2 == 0 ? WhiteSmoke : White;
                }
                else
                {
                    label.Text = population.ToString();
                    m_map[x][y].BackColor = color;
                }
            });
        }

        public Panel GetTile(Tuple<int, int> position) => m_map[position.Item1][position.Item2];

        private void LoadMap(Settings settings)
        {
            const int tileSize = 20;
            Tuple<int, int> size = settings.WorldSize;
            var clr1 = DarkGray;
            var clr2 = White;

            m_map = new Panel[size.Item1 + 2][];

            for (var n = 0; n < size.Item1 + 2; ++n)
            {
                m_map[n] = new Panel[size.Item2 + 2];

                for (var m = 0; m < size.Item2 + 2; ++m)
                {
                    var panel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m),
                        BackColor = (m + n) % 2 == 0 ? WhiteSmoke : White
                    };

                    var label = new Label
                    {
                        AutoSize = true,
                        ForeColor = White,
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    panel.Controls.Add(label);

                    if (m == 0 || m == size.Item2 + 1 || n == 0 || n == size.Item1 + 1)
                    {
                        panel.BackColor = Black;
                        panel.BorderStyle = BorderStyle.None;

                        if (!(m == 0 && n == 0) && !(m == size.Item2 + 1 && n == size.Item1 + 1) &&
                            !(m == 0 && n == size.Item1 + 1) && !(m == size.Item2 + 1 && n == 0))
                        {
                            label.Text = (m == 0 || m == size.Item2 + 1 ? n : m).ToString();
                            label.ForeColor = Yellow;
                            label.Font = new Font(Font, FontStyle.Bold);
                        }
                    }

                    Controls.Add(panel);
                    m_map[n][m] = panel;
                }
            }
        }
    }
}

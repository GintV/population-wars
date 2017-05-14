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

        public void ChangeTitle(int x, int y, Color? color, int? number)
        {
            Label current = GetFirstLabel(m_map[x, y]);
            if (current == null)
            {
                current = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                m_map[x, y].Controls.Add(current);
            }
            if (color != null)
            {
                current.BackColor = (Color)color;
            }
            if (number != null)
            {
                current.Text = ((int)number).ToString();
            }
        }

        private Label GetFirstLabel(Control parent)
        {
            return parent.Controls.OfType<Label>().Select(control => control).FirstOrDefault();
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
                            panel.Controls.Add(new Label
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

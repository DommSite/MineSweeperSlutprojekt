using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MineSweeperSlutprojekt
{
    public partial class Form2 : Form
    {
        private Button[][] musknapp;
        private LogikSaker logik;

        public Form2()
        {
            Startup();
        }

        public Form2(string text, int rad, int kol, int storlek, int bomber) : this()
        {
            this.Text = text;
            logik = new LogikSaker(rad, kol, bomber);
            this.ClientSize = new Size(kol * storlek, rad * storlek);
            musknapp = new Button[rad][];
            for (int i = 0; i < rad; i++)
            {
                musknapp[i] = new Button[kol];
                for (int j = 0; j < kol; j++)
                {
                    musknapp[i][j] = new Button
                    {
                        Text = "",
                        BackColor = Color.White,
                        Name = i + "," + j,
                        Size = new Size(storlek, storlek),
                        Location = new Point(storlek * j, storlek * i),
                        UseVisualStyleBackColor = false
                    };
                    musknapp[i][j].MouseUp += new MouseEventHandler(mustryck);
                    this.Controls.Add(musknapp[i][j]);
                }
            }
        }

        private void mustryck(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            int z = b.Name.IndexOf(",");
            int x = int.Parse(b.Name.Substring(0, z));
            int y = int.Parse(b.Name.Substring(z + 1));

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (!logik.Startat)
                    {
                        logik.Startup(x, y);
                    }
                    Vänster(x, y);
                    break;

                case MouseButtons.Right:
                    Höger(x, y, b);
                    break;

                case MouseButtons.Middle:
                    Skrollhjul(x, y, b);
                    break;
            }
        }

        private void Vänster(int x, int y)
        {
            if (logik.BombKoll(x, y))
            {
                VisaBomber();
                StängAvInput();
                MessageBox.Show("Du förlorade, du tryckte på en mina");
                return;
            }

            if (logik.Upptäckt.Contains(x * musknapp[0].Length + y))
                return;

            foreach (int a in logik.GetSafeIsland(x, y))
            {
                int i = a / musknapp[0].Length;
                int j = a % musknapp[0].Length;
                musknapp[i][j].BackColor = Color.LightGray;
                int h = logik.BombRäkning(i, j);
                if (h > 0)
                {
                    musknapp[i][j].Text = h.ToString();
                    musknapp[i][j].BackColor = Color.LightBlue;
                }
                else
                {
                    musknapp[i][j].Enabled = false;
                }
            }
            if (logik.VinstKoll())
            {
                MessageBox.Show("Grattis, du vann");
            }
        }

        private void Höger(int x, int y, Button b)
        {
            int index = x * musknapp[0].Length + y;
            if (logik.Upptäckt.Contains(index))
                return;

            if (logik.Markerad.Contains(index))
            {
                b.BackColor = Color.White;
                logik.Markerad.Remove(index);
            }
            else
            {
                b.BackColor = Color.Green;
                logik.Markerad.Add(index);
            }
            if (logik.VinstKoll())
            {
                StängAvInput();
                MessageBox.Show("Grattis, du vann");
            }
        }

        private void Skrollhjul(int x, int y, Button b)
        {
            if (!logik.Upptäckt.Contains(x * musknapp[0].Length + y))
                return;

            int AntalMarkeringar = logik.GrannKoll(x, y).Count(n => logik.Markerad.Contains(n));

            if (logik.BombRäkning(x, y) != AntalMarkeringar)
                return;

            foreach (int k in logik.GrannKoll(x, y))
            {
                if (logik.Markerad.Contains(k) || logik.Upptäckt.Contains(k))
                    continue;

                if (logik.BombKoll(k / musknapp[0].Length, k % musknapp[0].Length))
                {
                    b.BackColor = Color.Red;
                    MessageBox.Show("Du förlorade, du tryckte på en mina");
                    return;
                }

                foreach (int l in logik.GetSafeIsland(k / musknapp[0].Length, k % musknapp[0].Length))
                {
                    int i = l / musknapp[0].Length;
                    int j = l % musknapp[0].Length;
                    musknapp[i][j].BackColor = Color.LightGray;
                    int h = logik.BombRäkning(i, j);
                    if (h > 0)
                    {
                        musknapp[i][j].Text = h.ToString();
                        musknapp[i][j].BackColor = Color.LightBlue;
                    }
                    else
                    {
                        musknapp[i][j].Enabled = false;
                    }
                }

                if (logik.VinstKoll())
                {
                    MessageBox.Show("Grattis, du vann");
                }
            }
        }
        private void VisaBomber()
        {
            for (int i = 0; i < musknapp.Length; i++)
            {
                for (int j = 0; j < musknapp[i].Length; j++)
                {
                    if (logik.BombKoll(i, j))
                    {
                        musknapp[i][j].BackColor = Color.Red;
                    }
                }
            }
        }

        private void StängAvInput()
        {
            foreach (Button[] rad in musknapp)
            {
                foreach (Button button in rad)
                {
                    button.Enabled = false;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
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
        private Button[][] buttons;
        private LogikSaker logik;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string text, int row, int col, int size, int mines) : this()
        {
            this.Text = text;
            logik = new LogikSaker(row, col, mines);
            this.ClientSize = new Size(col * size, row * size);
            buttons = new Button[row][];
            for (int i = 0; i<row; i++)
            {
                buttons[i] = new Button[col];
            }
            foreach(int i in Enumerable.Range(0, row))
            {
                foreach (int j in Enumerable.Range(0, col))
                {
                    buttons[i][j] = new Button();
                    buttons[i][j].Text = "";
                    buttons[i][j].BackColor= Color.White;
                    buttons[i][j].Name = i + "," + j;
                    buttons[i][j].Size = new Size(size, size);
                    buttons[i][j].Location = new Point(size * j, size * i);
                    buttons[i][j].UseVisualStyleBackColor = false;
                    buttons[i][j].MouseUp += new MouseEventHandler(Button_Click);
                    this.Controls.Add(buttons[i][j]);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int temp = b.Name.IndexOf(",");
            int x = Int16.Parse(b.Name.Substring(0, temp));
            int y = Int16.Parse(b.Name.Substring(++temp));
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (!this.logik.Started)
                    {
                        this.logik.Initialize(x, y);
                    }
                    int m = this.logik.CountMines(x,y);
                    if (this.logik.IsMine(x, y))
                    {
                        b.BackColor = Color.Red;
                        MessageBox.Show("Du förlorade, du tryckte på en mina");
                        break;
                    }
                    if (this.logik.Discovered.Contains(x * buttons[0].Length + y))
                    {
                        break;
                    }
                    foreach(int a in this.logik.GetSafeIsland(x, y))
                    {
                        int i = a / buttons[0].Length;
                        int j = a % buttons[0].Length;
                        buttons[i][j].BackColor=Color.LightGray;
                        int h = this.logik.CountMines(i,j);
                        if(h > 0)
                        {
                            buttons[i][j].Text = h + "";
                            buttons[i][j].BackColor = Color.LightBlue;
                        }
                        else
                        {
                            buttons[i][j].Enabled = false;
                        }
                    }
                    if (logik.Win(x, y))
                    {
                        MessageBox.Show("Grattis, du vann");
                    }
                    break;
                case MouseButtons.Right:
                    if (this.logik.Discovered.Contains(x * buttons[0].Length + y))
                    {
                        break;
                    }
                    if (logik.Flagged.Contains(x * buttons[0].Length + y))
                    {
                        b.BackColor = Color.White;
                        logik.Flagged.Remove(x * buttons[0].Length + y);
                    }
                    else
                    {
                        b.BackColor= Color.Green;
                        logik.Flagged.Add(x * buttons[0].Length + y);
                    }
                    break;
                case MouseButtons.Middle:
                    if (!this.logik.Discovered.Contains(x * buttons[0].Length + y))
                    {
                        break;
                    }
                    int Flagged_Count = 0;
                    foreach(int k in this.logik.GetNeighbors(x, y))
                    {
                        if (logik.Flagged.Contains(k))
                        {
                            Flagged_Count++;
                        }
                    }
                    if (this.logik.CountMines(x, y) != Flagged_Count)
                    {
                        break;
                    }
                    foreach(int k in this.logik.GetNeighbors(x, y))
                    {
                        if(logik.Flagged.Contains(k) || logik.Discovered.Contains(k))
                        {
                            continue;
                        }
                        if (this.logik.IsMine(k / buttons[0].Length, k % buttons[0].Length))
                        {
                            b.BackColor = Color.Red;
                            MessageBox.Show("Du förlorade, du tryckte på en mina");
                            break;
                        }
                        foreach(int l in this.logik.GetSafeIsland(k / buttons[0].Length, k % buttons[0].Length))
                        {
                            int i = l / buttons[0].Length;
                            int j = l % buttons[0].Length;
                            buttons[i][j].BackColor= Color.LightGray;
                            int h = this.logik.CountMines(i, j);
                            if (h > 0)
                            {
                                buttons[i][j].Text = h + "";
                                buttons[i][j].BackColor=Color.LightBlue;
                            }
                            else
                            {
                                buttons[i][j].Enabled = false;
                            }                           
                        }
                        if (logik.Win(x, y))
                        {
                            MessageBox.Show("Grattis, du vann");
                        }                    
                    }
                    break;
            }
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

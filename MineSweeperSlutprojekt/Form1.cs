namespace MineSweeperSlutprojekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Play_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;
            int mines = 0;
            string text = "";
            Form2 startsak = null;
            if (Easy.Checked)
            {
                row = 9;
                col = 9;
                mines = 10;
                text = "Easy";
            }
            else if (Medium.Checked)
            {
                row = 16;
                col = 16;
                mines = 40;
                text = "Medium";
            }
            else if (Hard.Checked)
            {
                row = 16;
                col = 30;
                mines = 99;
                text = "Hard";
            }
            else if (Impossible.Checked)
            {
                row = 30;
                col = 30;
                mines = 800;
                text = "Impossible";
            }
            else
                return;
            int size= Math.Min(30, 1000 / Math.Max(row,col));
            startsak = new Form2(text, row, col, size, mines);
        }
    }
}

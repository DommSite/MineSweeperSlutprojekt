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
            int rad = 0;
            int kol = 0;
            int bomber = 0;
            string text = "";
            Form2 startsak = null;
            if (Easy.Checked)
            {
                rad = 9;
                kol = 9;
                bomber = 10;
                text = "Easy";
            }
            else if (Medium.Checked)
            {
                rad = 16;
                kol = 16;
                bomber = 40;
                text = "Medium";
            }
            else if (Hard.Checked)
            {
                rad = 16;
                kol = 30;
                bomber = 99;
                text = "Hard";
            }
            else if (Impossible.Checked)
            {
                rad = 30;
                kol = 30;
                bomber = 800;
                text = "Impossible";
            }
            else
                return;
            int storlek= Math.Min(30, 1000 / Math.Max(rad,kol));
            startsak = new Form2(text, rad, kol, storlek, bomber);
            startsak.Show();
        }
    }
}

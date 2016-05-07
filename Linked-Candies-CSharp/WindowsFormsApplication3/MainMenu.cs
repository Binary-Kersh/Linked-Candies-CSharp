using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            LevelList lvl = new LevelList();
            this.Hide();
            lvl.ShowDialog();
            this.Close();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.ImageLocation = "images\\Logo.png";
            panel1.Controls.Add(pb);
        }
    }
}

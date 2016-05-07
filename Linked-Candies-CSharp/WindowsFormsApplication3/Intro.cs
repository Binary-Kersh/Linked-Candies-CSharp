using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Intro : Form
    {
        public int sec = 0;
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.ImageLocation = "images\\Kersh.jpg";
            panel1.Controls.Add(pb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec==1)
            {
                //Thread.Sleep(5000);
                MainMenu mm = new MainMenu();
                this.Hide();
                mm.ShowDialog();
                this.Close();
            }
        }
    }
}

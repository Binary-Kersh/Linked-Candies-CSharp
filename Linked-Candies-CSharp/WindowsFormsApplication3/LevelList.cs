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
    public partial class LevelList : Form
    {
        public LevelList()
        {
            InitializeComponent();
            button2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            gamePlay gp = gamePlay.CreatGamePlay(2);
            gp.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            gamePlay gp = gamePlay.CreatGamePlay(1);
            gp.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            gamePlay gp = gamePlay.CreatGamePlay(3);
            gp.ShowDialog();
            this.Close();
        }

        private void LevelList_Load(object sender, EventArgs e)
        {

        }

        private void LevelList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu a=new MainMenu();
            a.ShowDialog();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class gamePlay : Form
    {

        private static gamePlay Game;
        public List<List<PictureBox>> candies = new List<List<PictureBox>>();
        int oneortwo = 0, noTheme = 0, noeffects = 0;
        public LinkedCandies Link;
        public int score = 0;
        public int moves = 10;
        FileStream fs;
        Candy firstone;
        SoundPlayer simpleSound;
        private gamePlay()
        {
            InitializeComponent();
            fs = new FileStream("Scores.txt", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            StreamReader sr = new StreamReader(fs);
            if (sr.Peek() == -1)
            {
                sw.WriteLine("0");
            }
            sw.Close();
            sr.Close();
            fs.Close();
        }
        //Senglton ---- Object Creator...
        private static readonly object syncLock = new object();// For Thread Safe
        public static gamePlay CreatGamePlay()
        {
            lock (syncLock)
            {
                if (Game == null)
                {
                    
                    return Game = new gamePlay();
                }
            }
            return Game;

        }
        private void gamePlay_Load(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer("Theme.wav");
            simpleSound.Play();
            Bitmap bm = new Bitmap("Map.jpg");
            panel1.BackgroundImage = bm;
            Link = new LinkedCandies();
            Candy temp = Link.root.d.r, temp1;
            int px = 82, py;
            List<Candy> listcandy = new List<Candy>();
            for (int h = 0; h < 9; h++)
            {
                listcandy.Add(temp);
                temp = temp.r;
            }
            int ii = 0;
            foreach (Candy k in listcandy)
            {
                py = -45;
                px += 127;
                temp1 = k;
                List<PictureBox> tmp = new List<PictureBox>();
                for (int h = 0; h < 9; h++)
                {
                    py += 74;
                    if (temp1 != null)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Name = "candy" + ii + "/" + h;
                        pb.BackColor = Color.Transparent;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.ImageLocation = temp1.type + ".png";
                        pb.Location = new Point(px, py);
                        tmp.Add(pb);
                        temp1 = temp1.d;
                    }
                }
                ii++;
                candies.Add(tmp);
            }
            for (int i = 0; i < candies.Count; i++)
            {
                for (int j = 0; j < candies[i].Count; j++)
                {
                    panel1.Controls.Add(candies[i][j]);
                    candies[i][j].MouseClick += new MouseEventHandler(candy_click);
                }
            }
            Checker tempcheck = new Checker(this);
            tempcheck.CheckAll(Link.root, false);
            newmap();
        }
        
        public void newmap()
        {
            Candy temp = Link.root.d.r, temp1;
            List<Candy> listcandy = new List<Candy>();
            for (int h = 0; h < 9; h++)
            {
                listcandy.Add(temp);
                temp = temp.r;
            }
            int i = 0;
            foreach (Candy k in listcandy)
            {
                temp1 = k;
                List<PictureBox> tmp = new List<PictureBox>();
                for (int j = 0; j < 9; j++)
                {
                    if (temp1 != null)
                    {
                        if (candies[i][j].ImageLocation != temp1.type+".png")
                            candies[i][j].ImageLocation=temp1.type + ".png";
                        temp1 = temp1.d;
                    }
                }
                i++;
            }
        }
        private void candy_click(object sender,MouseEventArgs e)
        {
            PictureBox pp = (PictureBox)sender;
            int i = pp.Name[5]-'0', j = pp.Name[7]-'0';
            if (oneortwo==0)
            {
                firstone = getcandy(i, j);
                oneortwo++;
            }
            else
            {
                Checker temp = new Checker(this);
                if (temp.CheckSwap(firstone, getcandy(i, j))==true)
                {
                    if (noeffects == 0)
                    {
                        simpleSound.Stop();
                        RandomColor r = new RandomColor();
                        SoundPlayer sweet = new SoundPlayer( r.RandSound() + ".wav");
                        sweet.Play();
                        Thread.Sleep(1500);
                        simpleSound.Play();
                    }
                    temp.change(firstone, getcandy(i, j),true);
                    //newmap();
                    Checker tempcheck = new Checker(this);
                    tempcheck.CheckAll(Link.root,true);
                    //newmap();
                    moves--;
                    label2.Text = moves.ToString();
                    label1.Text = score.ToString();
                    if (moves==0)
                    {
                        MessageBox.Show("Game Over");
                        fs = new FileStream("Scores.txt", FileMode.Open);
                        StreamReader sr = new StreamReader(fs);
                        int filescore = int.Parse(sr.ReadLine());
                        sr.Close();
                        fs.Close();
                        if (filescore<score)
                        {
                            MessageBox.Show("New Highscore :D");
                            fs = new FileStream("Scores.txt", FileMode.Create);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine(score);
                            sw.Close();
                        }
                        else
                        {
                            MessageBox.Show("Your Score: " + score+" & Highscore is " + filescore ) ;
                        }
                        simpleSound.Stop();
                        panel1.Hide();
                        PictureBox p= new PictureBox();
                        p.ImageLocation = "pic.jpg";
                        p.Size = new Size(1024, 500);
                        p.Dock = DockStyle.Fill;
                        this.Controls.Add(p);
                    }
                }
                oneortwo = 0;
            }
        }
        public void bombcandy(int x, int y, bool z)
        {
            if(z==false)
            {
                while (candies[x][y].Size.Width != 0 && candies[x][y].Size.Height!=0)
                    candies[x][y].Size=new Size(candies[x][y].Size.Width-10,candies[x][y].Size.Height-10);
            }
            else
            {
                candies[x][y].Size = new Size(100, 50);
            }
        }
        public Candy getcandy(int j,int i)
        {
            Candy temp=Link.getcandy();
            for (int h = 0; h <= i; h++)
            {
                temp = temp.d;
            }
            for (int h = 0; h <= j; h++)
            {
                temp = temp.r;
            }
            return temp;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void gamePlay_Click(object sender, EventArgs e)
        {
        }

        private void gamePlay_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private void background_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void background_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            noeffects = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure that you want exit game?","Want to Exit?",MessageBoxButtons.YesNo);
            if (result1==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (noTheme == 0)
            {
                simpleSound.Stop();
                noTheme = 1;
            }
            else
            {
                simpleSound.Play();
                noTheme = 0;
            }
        }
    }
}
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
        public int moves = 30;
        public int gameType;
        public int seconds = 120;
        int x, y, x1, y1;// for invalid move notification // swap  the candies twice 
        FileStream fs;
        Candy firstCandy, secondCandy;
        SoundPlayer simpleSound, ending;
        private gamePlay(int gameType)
        {
            InitializeComponent();
            this.gameType = gameType;
            if (gameType == 1)
            {
                label3.Text = "Remaining Time:";
                label2.Text = "120";
                label4.Text = "1";
            }
            else if (gameType == 2)
            {
                label3.Text = "Remaining Moves:";
                label2.Text = "30";
                label4.Text = "2";
            }
            else
            {
                label3.Text = "Remaining Score:";
                label2.Text = "1000";
                label4.Text = "3";
                seconds = 0;
            }
        }
        //Senglton ---- Object Creator...
        private static readonly object syncLock = new object();// For Thread Safe
        public static gamePlay CreatGamePlay(int gameType)
        {
            lock (syncLock)
            {
                if (Game == null)
                {
                    return Game = new gamePlay(gameType);
                }
            }
            return Game;

        }
        private void gamePlay_Load(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer("sounds\\Theme.wav");
            simpleSound.Play();
            Bitmap bm = new Bitmap("images\\Map.jpg");
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
                        pb.ImageLocation ="images\\"+ temp1.type + ".png";
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
            tempcheck.CheckAll(Link.root, 0);
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
                        if (candies[i][j].ImageLocation != "images\\"+temp1.type + ".png")
                            candies[i][j].ImageLocation = "images\\" + temp1.type + ".png";
                        temp1 = temp1.d;
                    }
                }
                i++;
            }
        }
        private void candy_click(object sender, MouseEventArgs e)
        {
            PictureBox pp = (PictureBox)sender;
            int i = pp.Name[5] - '0', j = pp.Name[7] - '0';
            if (oneortwo == 0)
            {
                firstCandy = getcandy(i, j);
                x = i;
                y = j;
                oneortwo++;
            }
            else
            {
                Checker temp = new Checker(this);
                secondCandy = getcandy(i, j);
                x1 = i;
                y1 = j;
                if (temp.CheckSwap(firstCandy, secondCandy) == true)
                {
                    if (noeffects == 0)
                    {
                        simpleSound.Stop();
                        RandomColor r = new RandomColor();
                        SoundPlayer sweet = new SoundPlayer("sounds\\" + r.RandSound() + ".wav");
                        sweet.Play();
                        Thread.Sleep(2000);
                        if (noTheme == 0)
                            simpleSound.Play();
                    }
                    temp.change(firstCandy, getcandy(i, j), 2);
                    temp.CheckAll(Link.root, 1);
                    bool end = false;
                    if (gameType == 1)
                    {
                        label1.Text = score.ToString();
                        if (seconds == 0) { end = true; }
                    }
                    else if (gameType == 2)
                    {
                        moves--;
                        label2.Text = moves.ToString();
                        label1.Text = score.ToString();
                        if (moves == 0) { end = true; }
                        else if (moves == 1) label3.Text = "Remaining Move:";
                    }
                    else
                    {
                        label2.Text = (1000 - score).ToString();
                        label1.Text = score.ToString();
                        if (1000 - score <= 0) { timer1.Stop(); end = true; }
                    }
                    if (end == true)
                    {
                        if (gameType == 1) gameOver("scores\\Time.txt");
                        else if (gameType == 2) gameOver("scores\\Moves.txt");
                        else if (gameType == 3) gameOver("scores\\Scores.txt");
                    }
                }
                else
                {
                    try { throw new InvaledPlay(); }

                    catch (InvaledPlay error)
                    {
                        List<int> list = new List<int>();
                        list.Add(x);
                        list.Add(y);
                        list.Add(x1);
                        list.Add(y1);
                        error.NotifyUser(list, this);
                    }
                }
                if (temp.CheckAll(Link.root, 0) == false)
                {
                    while (temp.CheckAll(Link.root, 0) == false)
                    {
                        Link = new LinkedCandies();
                    }
                    newmap();
                }
                oneortwo = 0;
            }
        }
        public void bombcandy(int x, int y, bool z)
        {
            if (z == false)
            {
                while (candies[x][y].Size.Width != 0 && candies[x][y].Size.Height != 0)
                    candies[x][y].Size = new Size(candies[x][y].Size.Width - 10, candies[x][y].Size.Height - 10);
            }
            else
            {
                candies[x][y].Size = new Size(100, 50);
            }
        }
        public Candy getcandy(int j, int i)
        {
            Candy temp = Link.getcandy();
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
        public void gameOver(string fileName)
        {
            MessageBox.Show("Game Over");
            fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int filescore = int.Parse(sr.ReadLine());
            sr.Close();
            fs.Close();
            if (fileName != "scores\\Scores.txt")
            {
                if (filescore < score)
                {
                    MessageBox.Show("New Highscore :D", "Congratulations");
                    fs = new FileStream(fileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(score);
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("Your Score: " + score + " & Highscore is " + filescore, "Highscores");
                }
            }
            else
            {
                if (filescore > seconds)
                {
                    MessageBox.Show("New Best Time :D", "Congratulations!");
                    fs = new FileStream(fileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(seconds);
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("Your Time: " + seconds + " & Best Time is " + filescore, "Highscores");
                }
            }
            simpleSound.Stop();
            panel1.Hide();
            ending = new SoundPlayer("sounds\\Victory.wav");
            ending.Play();
            PictureBox p = new PictureBox();
            p.ImageLocation = "images\\pic.jpg";
            p.Size = new Size(1024, 500);
            p.Dock = DockStyle.Fill;
            this.Controls.Add(p);
            try
            {
                
                throw new GameOver();
            }
            catch (GameOver over)
            {
                List<int> list = new List<int>();
                over.NotifyUser(list, this);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            noeffects = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameType == 1)
            {
                //label2.Text = DateTime.Now.ToString();
                label2.Text = seconds.ToString();
                seconds--;
                if (seconds == 0)
                {
                    timer1.Stop();
                    gameOver("scores\\Time.txt");
                }
            }
            else
            {
                seconds++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure that you want exit game? :(", "Want to Exit?", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
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
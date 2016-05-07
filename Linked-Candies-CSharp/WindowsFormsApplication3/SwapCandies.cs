using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public class SwapCandies
    {
        public Dictionary<string, PictureBox> listimage = new Dictionary<string, PictureBox>();
        public SwapCandies()
        {
            //PictureBox pb = new PictureBox();
            //pb.BackColor = Color.Transparent;
            //pb.SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Green.png"] = new PictureBox();
            listimage["Green.png"].ImageLocation= "images\\Green.png" ;
            listimage["Green.png"].BackColor = Color.Transparent;
            listimage["Green.png"].SizeMode= PictureBoxSizeMode.Zoom;
            listimage["Green.png"].Load();
            listimage["Blue.png"] = new PictureBox();
            listimage["Blue.png"].ImageLocation = "images\\Blue.png";
            listimage["Blue.png"].BackColor = Color.Transparent;
            listimage["Blue.png"].SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Blue.png"].Load();
            listimage["Red.png"] = new PictureBox();
            listimage["Red.png"].ImageLocation = "images\\Red.png";
            listimage["Red.png"].BackColor = Color.Transparent;
            listimage["Red.png"].SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Red.png"].Load();
            listimage["Yellow.png"] = new PictureBox();
            listimage["Yellow.png"].ImageLocation = "images\\Yellow.png";
            listimage["Yellow.png"].BackColor = Color.Transparent;
            listimage["Yellow.png"].SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Yellow.png"].Load();
            listimage["Orange.png"] = new PictureBox();
            listimage["Orange.png"].ImageLocation = "images\\Orange.png";
            listimage["Orange.png"].BackColor = Color.Transparent;
            listimage["Orange.png"].SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Orange.png"].Load();
            listimage["Pink.png"] = new PictureBox();
            listimage["Pink.png"].ImageLocation = "images\\Pink.png";
            listimage["Pink.png"].BackColor = Color.Transparent;
            listimage["Pink.png"].SizeMode = PictureBoxSizeMode.Zoom;
            listimage["Pink.png"].Load();
        }

        public void swapcandies(int x1, int y1, int x2, int y2, gamePlay game)
        {
            Size sz = new Size(game.candies[x1][y1].Size.Width, game.candies[x1][y1].Size.Height);
            while (game.candies[x1][y1].Size.Width != 0 && game.candies[x1][y1].Size.Height != 0)
            {
                game.candies[x1][y1].Size = new Size(game.candies[x1][y1].Size.Width - 20, game.candies[x1][y1].Size.Height );
                game.candies[x2][y2].Size = new Size(game.candies[x1][y1].Size.Width - 20, game.candies[x1][y1].Size.Height );
                game.candies[x1][y1].Update();
                game.candies[x2][y2].Update();
            }
            Image pp = game.candies[x2][y2].Image;
            game.candies[x2][y2].Image = game.candies[x1][y1].Image;
            game.candies[x1][y1].Image = pp;
            game.candies[x1][y1].Size = sz;
            game.candies[x2][y2].Size = sz;
            game.candies[x1][y1].Update();
            game.candies[x2][y2].Update();
            //MessageBox.Show(game.candies[x1][y1].Location + "///" + game.candies[x2][y2].Location);
        }
        public void bombcandy(List<List<bool>> des, List<List<string>> nwmap, gamePlay game)
        {
            List<List<bool>> tmp = new List<List<bool>>();
            for (int j = 0; j < des[0].Count; j++)
            {
                List<bool> col = new List<bool>();
                for (int i = 0; i < des.Count; i++)
                {
                    col.Add(des[i][j]);
                }
                tmp.Add(col);
            }
            des = tmp; ;
            for (int i = 0; i < des.Count; i++)
            {
                int idx = 0;
                for (int j = 0; j < des[i].Count; j++)
                    if (des[i][j] == true)
                        idx++;
                for (int j = 0; j < des[i].Count; j++)
                {
                    if (des[i][j] == true)
                    {
                        animation(i, j, game);
                        game.candies[i][j].Update();
                        //Thread.Sleep(500);
                        /////////////////////////

                        for(int k=j-1;k>=0;k--)
                        {
                            animation(i, k, game);
                            game.candies[i][k + 1].Image=listimage[nwmap[k+idx][i]+".png"].Image;
                            game.candies[i][k + 1].Size = new Size(100, 50);
                            game.candies[i][k + 1].Update();
                            //hread.Sleep(50);
                        }
                        idx--;
                        //Thread.Sleep(50);
                        game.candies[i][0].Image = listimage[nwmap[idx][i] + ".png"].Image;
                        game.candies[i][0].Size = new Size(100, 50);
                        game.candies[i][0].Update();

                        /////////////////////////
                    }
                }
                /*if (idx != -1)
                {
                    for (int j = 0; j < des[i].Count; j++)
                    {
                        if (des[i][j] == true)
                            break;
                        des[i][j] = true;
                    }
                }
                for (int j = des[i].Count - 1; j >= 0; j--)
                {
                    if (des[i][j] == true)
                    {
                        if (j != 0)
                        {
                            j--;
                            animation(i, j, game);
                            j++;
                        }
                        //MessageBox.Show(nwmap[j][i]);
                        game.candies[i][j].Image =listimage[nwmap[j][i] + ".png"].Image;
                        game.candies[i][j].Size = new Size(100, 50);
                        game.candies[i][j].Update();
                        Thread.Sleep(500);
                    }
                }*/
            }
        }
        public void animation(int i,int j,gamePlay game)
        {
            while (game.candies[i][j].Size.Width != 0 )
            {
                game.candies[i][j].Size = new Size(game.candies[i][j].Size.Width - 20, game.candies[i][j].Size.Height);
                game.candies[i][j].Update();
                //Thread.Sleep(50);
            }
        }
    }
}

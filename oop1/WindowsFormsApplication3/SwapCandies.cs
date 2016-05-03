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

namespace WindowsFormsApplication3
{
    public class SwapCandies
    {
        public SwapCandies() { }

        public void swapcandies(int x1, int y1, int x2, int y2, gamePlay game)
        {
            Size sz = new Size(game.candies[x1][y1].Size.Width, game.candies[x1][y1].Size.Height);
            while (game.candies[x1][y1].Size.Width != 0 && game.candies[x1][y1].Size.Height != 0)
            {
                game.candies[x1][y1].Size = new Size(game.candies[x1][y1].Size.Width - 10, game.candies[x1][y1].Size.Height - 10);
                game.candies[x2][y2].Size = new Size(game.candies[x1][y1].Size.Width - 10, game.candies[x1][y1].Size.Height - 10);
            }
            string pp = game.candies[x1][y1].ImageLocation;
            game.candies[x1][y1].ImageLocation = game.candies[x2][y2].ImageLocation;
            game.candies[x2][y2].ImageLocation = pp;
            game.candies[x1][y1].Size = sz;
            game.candies[x2][y2].Size = sz;
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
                int idx = -1;
                for (int j = 0; j < des[i].Count; j++)
                {
                    if (des[i][j] == true)
                    {
                        if (idx == -1)
                            idx = j;
                        while (game.candies[i][j].Size.Width != 0 && game.candies[i][j].Size.Height != 0)
                        {
                            game.candies[i][j].Size = new Size(game.candies[i][j].Size.Width - 10, game.candies[i][j].Size.Height - 10);
                        }
                        //MessageBox.Show(i + " " + j);
                        //MessageBox.Show("leeh ._.");
                        Thread.Sleep(500);
                    }
                }
                if (idx != -1)
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
                            while (game.candies[i][j].Size.Width != 0 && game.candies[i][j].Size.Height != 0)
                            {
                                game.candies[i][j].Size = new Size(game.candies[i][j].Size.Width - 10, game.candies[i][j].Size.Height - 10);
                            }
                            j++;
                        }
                        game.candies[i][j].ImageLocation = nwmap[j][i] + ".png";
                        game.candies[i][j].Size = new Size(100, 50);
                        //MessageBox.Show(i + " " + j);
                        //MessageBox.Show("leeh T-T");
                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}

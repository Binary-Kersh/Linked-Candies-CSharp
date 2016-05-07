using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace WindowsFormsApplication3
{
    abstract class GameException : SystemException
    {
        public string message;
        public abstract void NotifyUser(List<int>arg, gamePlay game);
    }
    class InvaledPlay : GameException
    {


        public override void NotifyUser(List<int> arg, gamePlay game)
        {
            {
                SoundPlayer sweet = new SoundPlayer("sounds\\Invalid.wav");
                sweet.Play();
                SwapCandies swap = new SwapCandies();
              //swap.swapcandies(int x1, int y1, int x2, int y1, gamePlay game)
                swap.swapcandies(arg[0], arg[1], arg[2], arg[3], game);
                swap.swapcandies(arg[0], arg[1], arg[2], arg[3], game);
            }
        }
    }
    class GameOver : GameException
    {

        public override void NotifyUser(List<int> arg,gamePlay game)
        {
            {
                game.Close();
            }
        }
    }
}

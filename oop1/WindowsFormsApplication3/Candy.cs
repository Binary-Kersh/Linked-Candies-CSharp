using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class Candy
    {
        int score;
        public string type;
        public Candy l, r, u, d;
        public Candy()
        {
            RandomColor color = new RandomColor();
            score = 0;
            type = color.RandColor();
            l = null;
            r = null;
            u = null;
            d = null;
        }
    }
}

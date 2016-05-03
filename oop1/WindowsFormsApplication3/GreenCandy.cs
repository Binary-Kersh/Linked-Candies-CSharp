using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class Candy : CandyNode
    {
        int score;
        public string col;
        public Candy l, r, u, d;
        public Candy()
        {
            score = 0;
            col = "koko";
            l = null;
            r = null;
            u = null;
            d = null;
        }
    }
}

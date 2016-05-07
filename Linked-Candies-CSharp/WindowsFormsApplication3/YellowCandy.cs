using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class YellowCandy : CandyNode
    {
        int score;
        string path;
        public CandyNode l, r, u, d;
        public YellowCandy()
        {
            score = 0;
            path = "";
            l = null;
            r = null;
            u = null;
            d = null;
        }
        public CandyNode right()
        {
            return this.r;
        }
       public CandyNode left()
        {
            return this.l;
        }
        public CandyNode up()
        {
            return this.u;
        }
        public CandyNode down()
        {
            return this.d;
        }
    }
}

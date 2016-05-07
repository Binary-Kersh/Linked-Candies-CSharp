using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
//1 Green
//2 Blue
//3 Red
//4 Yellow 
namespace WindowsFormsApplication3
{

    public class LinkedCandies : Candy
    {
        RandomColor color = new RandomColor();
        public Candy root;
        public int size;
        public LinkedCandies()
        {
            root = new Candy();
            root.type = "root";
            size = 9;
            Candy temp1 = root;
            for (int i = 0; i < size; i++)
            {
                temp1.d = new Candy();
                temp1.d.type = "subroot";
                temp1.d.u = temp1;
                temp1 = temp1.d;
            }
            temp1 = root;
            for (int i = 0; i < size; i++)
            {
                temp1 = temp1.d;
                Candy temp2 = temp1;
                temp1 = temp2;
                for (int h = 0; h < size; h++)
                {
                    temp2.r = new Candy();
                    temp2.r.type = color.RandColor();
                    temp2.r.l = temp2;
                    temp2 = temp2.r;
                }
            }
            temp1 = root;
            for (int i = 0; i < size - 1; i++)
            {
                Candy temp2 = temp1.d;
                temp1 = temp2;
                Candy temp3 = temp2.d;
                for (int h = 0; h < size; h++)
                {
                    temp2 = temp2.r;
                    temp3 = temp3.r;
                    temp2.d = temp3;
                    temp3.u = temp2;
                }
            }
        }
        public Candy getcandy()
        {
            return root;
        }
    }

}

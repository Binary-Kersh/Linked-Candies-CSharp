using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class RandomColor
    {
        Random rand;
        Random sodd;
        public RandomColor()
        {
            sodd = new Random();
            rand = new Random();
        }
        public string RandColor()
        {

            int num = rand.Next(1, 7);
            string color;
            switch (num)
            {
                case 1:
                    color = "Green";
                    break;
                case 2:
                    color = "Blue";
                    break;
                case 3:
                    color = "Yellow";
                    break;
                case 4:
                    color = "Red";
                    break;
                case 5:
                    color = "Orange";
                    break;
                case 6:
                    color = "Pink";
                    break;
                default:
                    color = RandColor();
                    break;
            }
            return color;
        }
        public string RandSound()
        {

            int num = sodd.Next(1, 5);
            string color;
            switch (num)
            {
                case 1:
                    color = "Sweet";
                    break;
                case 2:
                    color = "Tasty";
                    break;
                case 3:
                    color = "Delicious";
                    break;
                case 4:
                    color = "Sugar";
                    break;
                default:
                    color = RandSound();
                    break;
            }
            return color;
        }
    }
}

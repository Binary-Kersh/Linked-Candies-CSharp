using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication3
{
    class Checker
    {
        gamePlay gameplay;
        int size;
        public Checker(gamePlay game)
        {
            size = 9;
            gameplay = game;
        }
        public bool CheckSwap(Candy first, Candy second)
        {
            //MessageBox.Show(first.type + " " + first.l.type + " " + first.r.type);
            if (first.d != second && first.u != second && first.l != second && first.r != second) return false;
            string tmp = second.type;
            second.type = first.type;
            first.type = tmp;
            Candy temp;
            //MessageBox.Show(first.type + " " + first.l.type + " " + first.r.type);
            int counterfirst = 0;
            {
                if (first.r != null)
                {
                    temp = first.r;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Right: " + first.type + " " + temp.type);
                        if (temp.type == first.type) counterfirst++;
                        else break;
                        if (temp.r == null) break;
                        temp = temp.r;
                    }
                }
            }
            {
                if (first.l != null)
                {
                    temp = first.l;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Left: " + first.type + " " + temp.type);
                        if (temp.type == first.type) counterfirst++;
                        else break;
                        if (temp.l == null) break;
                        temp = temp.l;
                    }
                }
            }
            if (counterfirst + 1 >= 3)
            {
                tmp = second.type;
                second.type = first.type;
                first.type = tmp;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                Candy tempx = first, tempy = first;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y1++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x1++;
                }
                tempx = second;
                tempy = second;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y2++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x2++;
                }
                //SwapCandies swap = new SwapCandies();
                //swap.swapcandies(y1, x1, y2, x2, gameplay);
                return true;
            }
            counterfirst = 0;
            {
                if (first.u != null)
                {
                    temp = first.u;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Right: " + first.type + " " + temp.type);
                        if (temp.type == first.type) counterfirst++;
                        else break;
                        if (temp.u == null) break;
                        temp = temp.u;
                    }
                }
            }
            {
                if (first.d != null)
                {
                    temp = first.d;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Left: " + first.type + " " + temp.type);
                        if (temp.type == first.type) counterfirst++;
                        else break;
                        if (temp.d == null) break;
                        temp = temp.d;
                    }
                }
            }
            if (counterfirst + 1 >= 3)
            {
                tmp = second.type;
                second.type = first.type;
                first.type = tmp;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                Candy tempx = first, tempy = first;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y1++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x1++;
                }
                tempx = second;
                tempy = second;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y2++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x2++;
                }
                //SwapCandies swap = new SwapCandies();
                //swap.swapcandies(y1, x1, y2, x2, gameplay);
                return true;
            }
            int countersecond = 0;
            {
                if (second.r != null)
                {
                    temp = second.r;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Right: " + first.type + " " + temp.type);
                        if (temp.type == second.type) countersecond++;
                        else break;
                        if (temp.r == null) break;
                        temp = temp.r;
                    }
                }
            }
            {
                if (second.l != null)
                {
                    temp = second.l;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Left: " + first.type + " " + temp.type);
                        if (temp.type == second.type) countersecond++;
                        else break;
                        if (temp.l == null) break;
                        temp = temp.l;
                    }
                }
            }
            if (countersecond + 1 >= 3)
            {
                tmp = second.type;
                second.type = first.type;
                first.type = tmp;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                Candy tempx = first, tempy = first;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y1++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x1++;
                }
                tempx = second;
                tempy = second;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y2++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x2++;
                }
                //SwapCandies swap = new SwapCandies();
                //swap.swapcandies(y1, x1, y2, x2, gameplay);
                return true;
            }
            countersecond = 0;
            {
                if (second.u != null)
                {
                    temp = second.u;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Right: " + first.type + " " + temp.type);
                        if (temp.type == second.type) countersecond++;
                        else break;
                        if (temp.u == null) break;
                        temp = temp.u;
                    }
                }
            }
            {
                if (second.d != null)
                {
                    temp = second.d;
                    for (int i = 0; i < 9; i++)
                    {
                        //MessageBox.Show("Left: " + first.type + " " + temp.type);
                        if (temp.type == second.type) countersecond++;
                        else break;
                        if (temp.d == null) break;
                        temp = temp.d;
                    }
                }
            }
            if (countersecond + 1 >= 3)
            {
                tmp = second.type;
                second.type = first.type;
                first.type = tmp;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                Candy tempx = first, tempy = first;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y1++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x1++;
                }
                tempx = second;
                tempy = second;
                while (tempy.u != null)
                {
                    tempy = tempy.u;
                    y2++;
                }
                while (tempx.l.type != "subroot")
                {
                    tempx = tempx.l;
                    x2++;
                }
                //SwapCandies swap = new SwapCandies();
                //
                return true;
            }
            //MessageBox.Show(counterfirst.ToString());
            tmp = second.type;
            second.type = first.type;
            first.type = tmp;
            return false;

        }
        public bool CheckAll(Candy root, bool ok2)
        {
            bool ok = false;
            Candy temp = root, temp1;
            for (int i = 0; i < 9; i++)
            {
                temp1 = temp.d;
                for (int h = 0; h < 9; h++)
                {
                    temp1 = temp1.r;
                    if (temp1 != null)
                    {
                        if (temp1.r != null && CheckSwap(temp1, temp1.r) == true)
                        {
                            if (temp1.type == temp1.r.type)
                            {
                                change(temp1, temp1.r, ok2);
                                return CheckAll(root, ok2);
                            }
                            else
                                ok = true;
                        }
                        if (temp1.l != null && CheckSwap(temp1, temp1.l) == true)
                        {
                            if (temp1.type == temp1.l.type)
                            {
                                change(temp1, temp1.l, ok2);
                                return CheckAll(root, ok2);
                            }
                            else
                                ok = true;
                        }
                        if (temp1.d != null && CheckSwap(temp1, temp1.d) == true)
                        {
                            if (temp1.type == temp1.d.type)
                            {
                                change(temp1, temp1.d, ok2);
                                return CheckAll(root, ok2);
                            }
                            else
                                ok = true;
                        }
                        if (temp1.u != null && CheckSwap(temp1, temp1.u) == true)
                        {
                            if (temp1.type == temp1.u.type)
                            {
                                change(temp1, temp1.u, ok2);
                                return CheckAll(root, ok2);
                            }
                            else
                                ok = true;
                        }
                    }
                }
                temp = temp.d;
            }
            return ok;
        }
        public void change(Candy first, Candy second, bool ok2)
        {
            //MessageBox.Show("" + CheckSwap(first, second));
            //MessageBox.Show(getxy(first)[0] + " " + getxy(first)[1] + " " + getxy(second)[0] + " " + getxy(second)[1]);
            HashSet<Candy> Bomber = new HashSet<Candy>();
            string tmp = second.type;
            second.type = first.type;
            first.type = tmp;
            SwapCandies swap = new SwapCandies();
            swap.swapcandies(getxy(first)[0],getxy(first)[1],getxy(second)[0],getxy(second)[1],gameplay);
            Candy temp;
            //
            {
                HashSet<Candy> tempbomber = new HashSet<Candy>();
                {
                    if (first.d != null)
                    {
                        temp = first.d;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Left: " + first.type + " " + temp.type);
                            if (temp.type == first.type) tempbomber.Add(temp);
                            else break;
                            if (temp.d == null) break;
                            temp = temp.d;
                        }
                    }
                }
                tempbomber.Add(first);
                {
                    if (first.u != null)
                    {
                        temp = first.u;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Right: " + first.type + " " + temp.type);
                            if (temp.type == first.type) tempbomber.Add(temp);
                            else break;
                            if (temp.u == null) break;
                            temp = temp.u;
                        }
                    }
                }
                if (tempbomber.Count >= 3)
                {
                    foreach (Candy i in tempbomber)
                        Bomber.Add(i);
                }
            }
            //
            {
                HashSet<Candy> tempbomber = new HashSet<Candy>();
                {
                    if (first.r != null)
                    {
                        temp = first.r;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Right: " + first.type + " " + temp.type);
                            if (temp.type == first.type) tempbomber.Add(temp);
                            else break;
                            if (temp.r == null) break;
                            temp = temp.r;
                        }
                    }
                }
                tempbomber.Add(first);
                {
                    if (first.l != null)
                    {
                        temp = first.l;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Left: " + first.type + " " + temp.type);
                            if (temp.type == first.type) tempbomber.Add(temp);
                            else break;
                            if (temp.l == null) break;
                            temp = temp.l;
                        }
                    }
                }
                if (tempbomber.Count >= 3)
                {
                    foreach (Candy i in tempbomber)
                        Bomber.Add(i);
                }
            }
            //
            {
                HashSet<Candy> tempbomber = new HashSet<Candy>();
                {
                    if (second.d != null)
                    {
                        temp = second.d;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Left: " + first.type + " " + temp.type);
                            if (temp.type == second.type) tempbomber.Add(temp);
                            else break;
                            if (temp.d == null) break;
                            temp = temp.d;
                        }
                    }
                }
                tempbomber.Add(second);
                {
                    if (second.u != null)
                    {
                        temp = second.u;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Right: " + first.type + " " + temp.type);
                            if (temp.type == second.type) tempbomber.Add(temp);
                            else break;
                            if (temp.u == null) break;
                            temp = temp.u;
                        }
                    }
                }
                if (tempbomber.Count >= 3)
                {
                    foreach (Candy i in tempbomber)
                        Bomber.Add(i);
                }
            }
            //
            {
                HashSet<Candy> tempbomber = new HashSet<Candy>();
                {
                    if (second.r != null)
                    {
                        temp = second.r;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Right: " + first.type + " " + temp.type);
                            if (temp.type == second.type) tempbomber.Add(temp);
                            else break;
                            if (temp.r == null) break;
                            temp = temp.r;
                        }
                    }
                }
                tempbomber.Add(second);
                {
                    if (second.l != null)
                    {
                        temp = second.l;
                        for (int i = 0; i < 9; i++)
                        {
                            //MessageBox.Show("Left: " + first.type + " " + temp.type);
                            if (temp.type == second.type) tempbomber.Add(temp);
                            else break;
                            if (temp.l == null) break;
                            temp = temp.l;
                        }
                    }
                }
                if (tempbomber.Count >= 3)
                {
                    foreach (Candy i in tempbomber)
                        Bomber.Add(i);
                }
            }
            /* MessageBox.Show(Bomber.Count + "");
             foreach (Candy i in Bomber)
             {
                 MessageBox.Show(i.type);
             }
             /***************************/
            Bomball(Bomber, ok2);
        }
        public void Bomball(HashSet<Candy> Bomber, bool ok2)
        {
            List<int> liy = new List<int>();
            List<Candy> lic1 = new List<Candy>();
            List<Candy> lic2 = new List<Candy>();
            foreach (Candy i in Bomber)
            {
                List<int> temp = getxy(i);
                liy.Add(temp[1]);
                lic1.Add(i);
            }
            for (int i = 0; i < size; i++)
            {
                for (int h = 0; h < liy.Count; h++)
                {
                    if (liy[h] == i)
                    {
                        lic2.Add(lic1[h]);
                    }
                }
            }
            RandomColor color = new RandomColor();
            SwapCandies swap = new SwapCandies();
            List<int> tempxy;
            List<List<bool>> goingbool = new List<List<bool>>();
            Candy root = new Candy();
            for (int i = 0; i < size; i++)
            {
                goingbool.Add(new List<bool>());
                for (int h = 0; h < size; h++)
                    goingbool[i].Add(false);
            }
            //MessageBox.Show(Bomber.Count + "");
            foreach (Candy i in Bomber)
            {
                tempxy = getxy(i);
                root = i;
                goingbool[tempxy[1]][tempxy[0]] = true;
            }
            foreach (Candy cand in lic2)
            {
                Candy tmp1 = cand;
                while (tmp1.u != null)
                {
                    tmp1.type = tmp1.u.type;
                    tmp1 = tmp1.u;
                }
                tmp1.type = color.RandColor();
            }
            while (root.type != "subroot")
            {
                root = root.l;
            }
            while (root.type != "root")
            {
                root = root.u;
            }
            List<List<string>> goingstring = new List<List<string>>();
            for (int i = 0; i < 9; i++)
            {
                Candy temp2 = root.d;
                goingstring.Add(new List<string>());
                for (int h = 0; h < 9; h++)
                {
                    temp2 = temp2.r;
                    goingstring[i].Add(temp2.type);
                }
                root = root.d;
            }
            if (ok2 == true)
            {
                //MessageBox.Show(Bomber.Count + "");
                gameplay.score += (Bomber.Count * 10);
                swap.bombcandy(goingbool, goingstring, gameplay);
            }

        }

        public List<int> getxy(Candy first)
        {
            Candy tempx = first, tempy = first;
            int y1 = 0, x1 = 0;
            while (tempy.u != null)
            {
                tempy = tempy.u;
                y1++;
            }
            while (tempx.l.type != "subroot")
            {
                tempx = tempx.l;
                x1++;
            }
            List<int> li = new List<int>();
            li.Add(x1);
            li.Add(y1);
            return li;
        }
    }
}

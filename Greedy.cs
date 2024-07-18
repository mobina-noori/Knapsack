using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack
{
    public class item
    {
        public int value;
        public int weight;

        public item(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
        }
    }
    class cprCompare : IComparer
    {
        public int Compare(Object x, Object y)
        {
            item item1 = (item)x;
            item item2 = (item)y;
            double cpr1 = (double)item1.value / (double)item1.weight;
            double cpr2 = (double)item2.value / (double)item2.weight;

            if (cpr1 < cpr2)
                return 1;

            return cpr1 > cpr2 ? -1 : 0;
        }
    }
    internal class Greedy
    {
        public static double KnapSack(item[] items, int w)
        {
        
            cprCompare cmp = new cprCompare();
            Array.Sort(items, cmp);
            //Array.Reverse(items);

            double totalVal = 0f;
            int currW = 0;

            foreach (item i in items)
            {
                float remaining = w - currW;

                if (i.weight <= remaining)
                {
                    totalVal += (double)i.value;
                    currW += i.weight;
                }
            }
            return totalVal;
        }

 
    }
}

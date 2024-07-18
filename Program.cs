//using backtrack_knapsack;
using System.Diagnostics;


namespace knapsack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter the number of objects : ");
            var n = Convert.ToInt32(Console.ReadLine());
            int[] weight = new int[n];
            int[] value = new int[n];



            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("enter the weight of object " + i + ": ");
                weight[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("enter the value of object " + j + ": ");
                value[j] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("enter the capacity : ");
            var cap = Convert.ToInt32(Console.ReadLine());

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("using a Divide and Conquer alghorithm : " + knapSack(cap, weight, value, n));
            sw.Stop();
            Console.WriteLine("Time:" + sw.Elapsed.TotalMilliseconds + " ms");

            sw.Start();
            Console.WriteLine("using a Dynamic Programming alghorithm : " + knapSack_DP(cap, weight, value, n));
            sw.Stop();
            Console.WriteLine("Time:" + sw.Elapsed.TotalMilliseconds + " ms");

            sw.Start();
            Console.WriteLine("using a Greedy alghorithm : " + KnapSack_gr(cap, weight, value, n));
            sw.Stop();
            Console.WriteLine("Time:" + sw.Elapsed.TotalMilliseconds + " ms");

        }
        // Here is the divide and conquer
        static int max(int a, int b)
        { return (a > b) ? a : b; }

        static int knapSackRec(int cap, int[] weight, int[] value, int n, int[,] dp)

        {
            if (n == 0 || cap == 0)
                return 0;
            if (dp[n, cap] != -1)
                return dp[n, cap];
            if (weight[n - 1] > cap)

                return dp[n, cap]
                    = knapSackRec(cap, weight, value, n - 1, dp);

            else

                return dp[n, cap]
                    = max((value[n - 1] + knapSackRec(cap - weight[n - 1], weight, value, n - 1, dp)),
                           knapSackRec(cap, weight, value, n - 1, dp));
        }


        static int knapSack(int cap, int[] weight, int[] value, int n)
        {

            
            int[,] dp = new int[n + 1, cap + 1];

            for (int i = 0; i < n + 1; i++)
                for (int j = 0; j < cap + 1; j++)
                    dp[i, j] = -1;

            return knapSackRec(cap, weight, value, n, dp);
        }


        // A Dynamic Programming based solution for 0-1 Knapsack problem
        static int knapSack_DP(int cap, int[] weight, int[] value, int n)
        {
            int i, w;
            int[,] q = new int[n + 1, cap + 1];

            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= cap; w++)
                {
                    if (i == 0 || w == 0)
                        q[i, w] = 0;

                    else if (weight[i - 1] <= w)
                        q[i, w] = Math.Max( value[i - 1] + q[i - 1, w - weight[i - 1]], q[i - 1, w]);
                    else
                        q[i, w] = q[i - 1, w];
                }
            }

            return q[n, cap];
        }

        static double KnapSack_gr(int cap, int[] weight, int[] value, int n)
        {
            item [] items=new item[weight.Length];
            for (int i = 0; i < weight.Length; i++)
            {
                item item = new item(value[i], weight[i]);
                items[i] = item;
            }
            return Greedy.KnapSack(items, cap);

        }

        


    }
}
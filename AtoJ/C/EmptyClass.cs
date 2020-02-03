using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var act = new int[n][];
            for (int i = 0; i < n; i++)
            {
                act[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }
            long[][] dp = new long[n + 1][];
            dp = dp.Select(e => e = new long[] { 0, 0, 0 }).ToArray();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < act[i - i].Length; j++)
                {
                    for (int k = 0; k < act[i - 1].Length; k++)
                    {
                        if (k == j) continue;
                        changeMax(ref dp[i][k], dp[i - 1][j] + act[i - 1][k]);
                    }
                }
            }
            long res = 0;
            for (int i = 0; i < 3; i++)
            {
                changeMax(ref res, dp[n][i]);
            }
            Console.WriteLine(res);
        }

        static bool changeMax(ref long a, long b)
        {
            if (a < b)
            {
                a = b;
                return true;
            }
            return false;
        }
    }
}
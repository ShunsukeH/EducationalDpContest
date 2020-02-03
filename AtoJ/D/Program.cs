using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[][] wv = new int[nk[0]][];
            for (int i = 0; i < nk[0]; i++)
            {
                wv[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }

            long[][] dp = new long[nk[0] + 1][];
            dp = dp.Select(e => e = new long[100001]).ToArray();
            dp = dp.Select(e => e.Select(elem => elem = 0).ToArray()).ToArray();
            for (int i = 0; i < nk[0]; i++)
            {
                for (int sumW = 0; sumW <= nk[1]; sumW++)
                {
                    if (sumW - wv[i][0] >= 0)
                    {
                        changeMax(ref dp[i + 1][sumW], dp[i][sumW - wv[i][0]] + wv[i][1]);
                    }
                    changeMax(ref dp[i + 1][sumW], dp[i][sumW]);
                }
            }
            Console.WriteLine(dp[nk[0]][nk[1]]);
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

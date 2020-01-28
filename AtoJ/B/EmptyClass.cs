using System;
namespace B
{
    public class EmptyClass
    {
        static void Main(string[] args)
        {

            int[] nk = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long[] dp = new long[nk[0]];
            dp[0] = 0;
            for (int i = 1; i < nk[0]; i++)
            {
                dp[i] = long.MaxValue;
                for (int j = 1; j <= Math.Min(nk[0],nk[1]); j++)
                {
                    if (i - j < 0) break;
                    ChangeMin(ref dp[i], dp[i - j] + Math.Abs(h[i] - h[i - j]));
                }
            }

            Console.WriteLine(dp[nk[0] - 1]);
        }

        static bool ChangeMin(ref long a, long b)
        {
            if (a > b)
            {
                a = b;
                return true;
            }
            return false;
        }
    }
}

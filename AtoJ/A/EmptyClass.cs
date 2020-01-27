using System;
namespace A
{
    public class EmptyClass
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long[] dp = new long[n];
            dp[0] = 0;
            for (int i = 1; i < n; i++)
            {
                dp[i] = long.MaxValue;
                ChangeMin(ref dp[i], dp[i - 1] + Math.Abs(h[i] - h[i - 1]));
                if (i > 1) ChangeMin(ref dp[i], dp[i - 2] + Math.Abs(h[i] - h[i - 2]));
            }

            Console.WriteLine(dp[n - 1]);
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

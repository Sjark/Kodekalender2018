using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag19
{
    class Program
    {
        static List<List<string>> arrs = new List<List<string>>();
        static int[,] dp;

        static void Main(string[] args)
        {
            var s1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. God jul.";
            var s2 = "The quick brown fox jumps over the lazy dog. Godt nytt år.";
            
            Console.WriteLine(Compute(s1, s2));
            Console.Read();
        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}

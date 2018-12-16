using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dag16
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input\\input-palindrom.txt")
                .Split(',')
                .Select(a => int.Parse(a))
                .ToList();

            //var input = "1,6,3,8,3,2,1,2,4"
            //    .Split(',')
            //    .Select(a => int.Parse(a))
            //    .ToList();

            var result = LargestPrimePalindromeSum(input);

            Console.WriteLine(result);
            Console.Read();
        }

        static bool IsPrime(long n)
        {
            // Corner cases 
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;

            // This is checked so  
            // that we can skip 
            // middle five numbers 
            // in below loop 
            if (n % 2 == 0 ||
                n % 3 == 0)
                return false;

            for (int i = 5;
                     i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }

        public static int LargestPrimePalindromeSum(List<int> s)
        {
            var result = 0;
            for (int i = 0; i < s.Count; i++)
            {
                var p1 = ExpandAroundCenter(s, i, i);
                if (p1.Count > 1)
                {
                    var p1Sum = p1.Sum();
                    if (p1Sum > result && IsPrime(p1Sum))
                    {
                        result = p1Sum;
                    }
                }

                var p2 = ExpandAroundCenter(s, i, i + 1);
                if (p2.Count > 1)
                {
                    var p2Sum = p2.Sum();
                    if (p2Sum > result && IsPrime(p2Sum))
                    {
                        result = p2Sum;
                    }
                }
            }

            return result;
        }

        private static List<int> ExpandAroundCenter(List<int> s, int i, int j)
        {
            while (i >= 0 && j < s.Count && s[i] == s[j])
            {
                i--;
                j++;
            }

            return s.GetRange(i + 1, j - i - 1);
        }
    }
}

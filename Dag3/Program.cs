using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dag3
{
    class Program
    {
        static void Main(string[] args)
        {
            long startNum = 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
            long endNum = 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
            var numbers = 0;
            var primes = GetPrimes((long)Math.Sqrt(4294967296));
            Parallel.For(startNum, endNum, i =>
            {
                if (FindFactors(i, primes) == 14)
                {
                    numbers++;
                }
            });

            Console.WriteLine(numbers);
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

        // Function to print primes 
        static List<long> GetPrimes(long n)
        {
            var result = new List<long>();
            for (long i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static int FindFactors(long num, List<long> primes)
        {
            var result = 0;

            // Take out the 2s.
            while (num % 2 == 0)
            {
                result++;
                num /= 2;

                if (result > 14)
                {
                    return 0;
                }
            }

            // Take out other primes.
            var i = 1;
            long factor = primes[i];
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    // This is a factor.
                    result++;
                    num /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    i++;
                    factor = primes[i];
                }

                if (i > 5 && result < 12)
                {
                    return 0;
                }

                if (result > 14)
                {
                    return 0;
                }
            }

            // If num is not 1, then whatever is left is prime.
            if (num > 1) result++;

            return result;
        }
    }
}

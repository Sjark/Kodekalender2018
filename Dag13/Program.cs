using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dag13
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var numbers = new List<int> { 1, 3 };

            var primes = new List<int> { 3 };

            var number = 4;
            while (primes.Count < 100)
            {
                var hits = 0;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    var n1 = numbers[i];

                    if (n1 >= Math.Ceiling(number / 2.0))
                    {
                        break;
                    }

                    for (int y = i + 1; y < numbers.Count; y++)
                    {
                        var n2 = numbers[y];

                        if (n1 + n2 == number)
                        {
                            hits += 1;
                            break;
                        }
                    }

                    if (hits > 1)
                    {
                        break;
                    }
                }

                if (hits == 1)
                {
                    numbers.Add(number);

                    if (IsPrime(number))
                    {
                        primes.Add(number);
                    }
                }

                number++;
            }
            
            Console.WriteLine(primes.Sum());
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.Read();
        }

        static bool IsPrime(long n)
        {
            if (n <= 1)
            {
                return false;
            }
                
            if (n <= 3)
            {
                return true;
            }                

            if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }

            for (int i = 5; i * i <= n; i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

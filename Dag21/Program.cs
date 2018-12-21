using System;

namespace Dag21
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeSieve = SieveOfEratosthenes(10000001);
            long result = 0;

            for (int i = 3; i < 10000000; i++)
            {
                if (primeSieve[i - 1] && primeSieve[i + 1] && DivisorsSummedLargerThanNumber(i))
                {
                    result += i;
                }
            }

            Console.WriteLine(result);
            Console.Read();
        }

        static bool DivisorsSummedLargerThanNumber(int number)
        {
            var result = 0;
            
            int newMax = number;
            for (int i = 2; i < newMax; ++i)
            {
                if (number % i == 0)
                {
                    int divisor2 = number / i;
                    result += i;
                    if (divisor2 != i)
                    {
                        result += number / i;
                    }
                    newMax = number / i;
                }

                if (result > number)
                {
                    return true;
                }
            }

            return false;
        }
        static bool[] SieveOfEratosthenes(int max)
        {
            var e = new bool[max];
            for (int i = 2; i < max; i++)
            {
                e[i] = true;
            }
            
            for (int j = 2; j < max; j++)
            {
                if (e[j])
                {
                    for (long p = 2; (p * j) < max; p++)
                    {
                        e[p * j] = false;
                    }
                }
            }

            return e;
        }
    }
}

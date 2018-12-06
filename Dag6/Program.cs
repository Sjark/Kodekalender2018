using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag6
{
    class Program
    {
        static void Main(string[] args)
        {
            var nullHeavyNumbers = new List<long>();

            for (long i = 1; i <= 18163106; i++)
            {
                var iAsString = i.ToString();

                if (iAsString.Count(a => a == '0') > iAsString.Count(a => a != '0'))
                {
                    nullHeavyNumbers.Add(i);
                }
            }

            Console.WriteLine(nullHeavyNumbers.Sum());
            Console.Read();
        }
    }
}

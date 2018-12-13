using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag7
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = File.ReadAllLines("Input\\input-vekksort.txt")
                .Select(a => int.Parse(a))
                .ToArray();

            var p = new int[x.Length];
            var m = new int[x.Length + 1];
            var l = 0;

            for (int i = 0; i < x.Length; i++)
            {
                var lo = 1;
                var hi = l;

                while (lo <= hi)
                {
                    var mid = (int)Math.Ceiling((double)((lo + hi) / 2));
                    if (x[m[mid]] <= x[i])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }

                var newL = lo;

                p[i] = m[newL - 1];
                m[newL] = i;

                if (newL > l)
                {
                    l = newL;
                }
            }

            Console.WriteLine(l);
            Console.Read();
        }
    }
}

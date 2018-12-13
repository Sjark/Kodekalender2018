using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllLines("Input\\input-vekksort.txt");
            var result = new List<int>();
            var num1 = 0;

            for (int i = 0; i < file.Length; i++)
            {
                var num2 = int.Parse(file[i]);

                if (num2 < num1)
                {
                    continue;
                }

                num1 = num2;
                result.Add(num2);
            }

            Console.WriteLine(result.Sum());
            Console.Read();
        }
    }
}

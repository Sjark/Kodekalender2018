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
            var input = File.ReadAllLines("Input\\input-vekksort.txt")
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                if (i + 2 >= input.Count)
                {
                    if (i + 1 < input.Count)
                    {
                        var n1 = int.Parse(input[i]);
                        var n2 = int.Parse(input[i + 1]);

                        if (n1 > n2)
                        {
                            input.RemoveAt(i);
                        }
                    }

                    break;
                }

                var num1 = int.Parse(input[i]);
                var num2 = int.Parse(input[i + 1]);

                if (num1 < num2)
                {
                    continue;
                }
                else
                {
                    var num3 = int.Parse(input[i + 2]);

                    if (num3 < num2)
                    {
                        input.RemoveAt(i + 1);
                    }
                    else
                    {
                        input.RemoveAt(i--);
                    }
                }
            }

            Console.WriteLine(input.Count);
            Console.Read();
        }
    }
}

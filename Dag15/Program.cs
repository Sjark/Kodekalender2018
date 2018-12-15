using System;
using System.IO;
using System.Linq;

namespace Dag15
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\input-gullbursdag.txt")
                .Select(a => int.Parse(a.Substring(a.IndexOf("f.") + 2)))
                .ToList();

            var result = 0;

            foreach (var year in input)
            {
                var i = 1;

                while (true)
                {
                    var goldYear = year + i;
                    var ageSquared = (int)Math.Pow(i, 2);

                    if (ageSquared == goldYear)
                    {
                        result += 1;
                        break;
                    }

                    if (ageSquared > goldYear)
                    {
                        break;
                    }

                    i++;
                }
            }
            
            Console.WriteLine(result);
            Console.Read();
        }
    }
}

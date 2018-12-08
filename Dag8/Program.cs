using System;
using System.IO;
using System.Linq;

namespace Dag8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\input-dolls.txt")
                .Select(a => {
                    var b = a.Split(',');

                    return new
                    {
                        Color = b[0],
                        Size = int.Parse(b[1])
                    };
                })
                .OrderBy(a => a.Size)
                .ToList();

            var count = 0;
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i].Color != input[i + 1].Color)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}

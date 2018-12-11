using System;
using System.IO;

namespace Dag11
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input\\input-crisscross.txt"))
            {
                var x = 0;
                var y = 0;

                while (!reader.EndOfStream)
                {
                    var ch1 = (char)reader.Read();
                    var ch2 = (char)reader.Read();

                    switch (ch2)
                    {
                        case 'H':
                            x += (int)char.GetNumericValue(ch1);
                            break;
                        case 'V':
                            x -= (int)char.GetNumericValue(ch1);
                            break;
                        case 'F':
                            y += (int)char.GetNumericValue(ch1);
                            break;
                        case 'B':
                            y -= (int)char.GetNumericValue(ch1);
                            break;
                    }
                }

                Console.WriteLine($"[{x},{y}]");
            }

            Console.Read();
        }
    }
}

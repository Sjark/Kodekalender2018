using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Dag2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var file = File.ReadAllLines("Input\\input-rain.txt");

            var results = new Dictionary<double, int>();

            foreach (var line in file)
            {
                var cords = line.Replace("(", "").Replace(")", "").Split(';');
                var cord1 = cords[0].Split(',');
                var cord2 = cords[1].Split(',');
                var x1 = double.Parse(cord1[0]);
                var y1 = double.Parse(cord1[1]);
                var x2 = double.Parse(cord2[0]);
                var y2 = double.Parse(cord2[1]);

                var slope = (y2 - y1) / (x2 - x1);

                if (results.ContainsKey(slope))
                {
                    results[slope]++;
                }
                else
                {
                    results.Add(slope, 1);
                }
            }

            sw.Stop();

            Console.WriteLine($"Result: {results.Values.Max()} in {sw.Elapsed}");

            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag17
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<Coord>
            {
                new Coord(7.1, 10.5),
                new Coord(18.8, 9.2),
                new Coord(2.1, 62.1),
                new Coord(74.2, 1.5),
                new Coord(58.4, 5.6),
                new Coord(15.9, 6.2),
                new Coord(44.5, 15.6),
                new Coord(88.1, 53.4),
                new Coord(36.2, 84.2),
                new Coord(26.9, 8.5)
            };

            var permutations = Permute(input);

            var minDistance = permutations.Select(a => ComputeDistance(a)).Min();

            Console.WriteLine(minDistance);
            Console.Read();
        }

        private static int ComputeDistance(List<Coord> input)
        {
            var distance = 0.0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                var coord1 = input[i];
                var coord2 = input[i + 1];

                distance += Math.Sqrt(Math.Pow(coord1.X - coord2.X, 2) + Math.Pow(coord1.Y - coord2.Y, 2));
            }

            return (int)Math.Round(distance);
        }

        public static List<List<Coord>> Permute(List<Coord> v)
        {
            var result = new List<List<Coord>>();

            Permute(v, v.Count, result);

            return result;
        }

        private static void Permute(List<Coord> v, int n, List<List<Coord>> result)
        {
            if (n == 1)
            {
                result.Add(new List<Coord>(v));
            }
            else
            {
                for (var i = 0; i < n; i++)
                {
                    Permute(v, n - 1, result);
                    Swap(v, n % 2 == 1 ? 0 : i, n - 1);
                }
            }
        }

        private static void Swap<T>(IList<T> v, int i, int j)
        {
            var t = v[i];
            v[i] = v[j];
            v[j] = t;
        }
    }

    public class Coord
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}

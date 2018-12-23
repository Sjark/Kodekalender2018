using System;
using System.IO;
using System.Linq;

namespace Dag22
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\input-luke-22.txt")
                .Select(a =>
                {
                    var coords = a.Split(",");

                    return new Coord(decimal.Parse(coords[0].Replace('.', ',')), decimal.Parse(coords[1].Replace('.', ',')));
                }).ToList();

            Console.Read();
        }
    }

    public class Coord
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Coord(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag14
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input\\input-bounding-crisscross.txt"))
            {
                var x = 0;
                var y = 0;
                var steps = 0;
                var visitedCoords = new List<Coord>
                {
                    new Coord(x, y)
                };

                while (!reader.EndOfStream)
                {
                    var ch1 = (char)reader.Read();
                    var ch2 = (char)reader.Read();

                    for (int i = 0; i < (int)char.GetNumericValue(ch1); i++)
                    {
                        steps++;

                        switch (ch2)
                        {
                            case 'H':
                                x += 1;
                                break;
                            case 'V':
                                x -= 1;
                                break;
                            case 'F':
                                y += 1;
                                break;
                            case 'B':
                                y -= 1;
                                break;
                        }

                        var coord = new Coord(x, y);
                        if (!visitedCoords.Contains(coord))
                        {
                            visitedCoords.Add(coord);
                        }
                    }
                }

                var minX = visitedCoords.Min(a => a.X);
                var maxX = visitedCoords.Max(a => a.X);
                var minY = visitedCoords.Min(a => a.Y);
                var maxY = visitedCoords.Max(a => a.Y);
                decimal notVisitedSquares = 0;
                
                for (int i = minX; i <= maxX; i++)
                {
                    for (int ii = minY; ii <= maxY; ii++)
                    {
                        var coord = new Coord(i, ii);

                        if (!visitedCoords.Contains(coord))
                        {
                            notVisitedSquares += 1;
                        }
                    }
                }

                Console.WriteLine(Math.Round(visitedCoords.Count / notVisitedSquares, 16).ToString().Replace(",", "."));
            }

            Console.Read();
        }
    }

    public struct Coord : IEquatable<Coord>
    {
        private readonly int _x;
        private readonly int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Coord(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override bool Equals(object other)
        {
            return other is Coord && Equals((Coord)other);
        }

        public bool Equals(Coord other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}

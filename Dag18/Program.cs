using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag18
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input\\input-rpslog.txt");

            var i = 0;

            var game = new List<char>();
            var players = new HashSet<int> { 0, 1, 2 };
            var results = new Dictionary<int, int>
            {
                { 0, 0 },
                { 1, 0 },
                { 2, 0 }
            };

            while (i < input.Length)
            {
                for (int y = 0; y < players.Count; y++)
                {
                    game.Add(input[i++]);
                }

                players = GetWinners(game, players);

                if (players.Count == 1)
                {
                    results[players.First()]++;

                    players = new HashSet<int> { 0, 1, 2 };
                }

                game = new List<char>();
            }

            Console.WriteLine($"{results[0]},{results[1]},{results[2]}");

            Console.Read();
        }

        static HashSet<int> GetWinners(List<char> game, HashSet<int> players)
        {
            var winners = new HashSet<int>();

            for (int i = 0; i < players.Count; i++)
            {
                for (int y = 0; y < players.Count; y++)
                {
                    if (i == y)
                    {
                        continue;
                    }
                    if (Winner(game[i], game[y]))
                    {
                        winners.Add(i);
                    }
                }
            }

            if (winners.Count == 0)
            {
                return players;
            }

            return winners;
        }

        static bool Winner(char player1, char player2)
        {
            if (player1 == 'R' && player2 == 'S' || player1 == 'S' && player2 == 'P' || player1 == 'P' && player2 == 'R')
            {
                return true;
            }

            return false;
        }
    }
}

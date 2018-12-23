using System;
using System.IO;
using System.Linq;

namespace Dag23
{
    class Program
    {
        private static readonly int[] _ctrl1 = new[] { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
        private static readonly int[] _ctrl2 = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input\\input-fnr.txt");
            var result = 0;

            foreach (var fnr in input)
            {
                if (IsWoman(fnr) && BornInAugust(fnr) && ValidCtrlNumbers(fnr) && ValidBirthday(fnr))
                {
                    result++;
                }
            }

            Console.WriteLine(result);
            Console.Read();
        }

        private static bool ValidBirthday(string fnr)
        {
            var date = fnr.Substring(4, 4) + "-" + fnr.Substring(2, 2) + "-" + fnr.Substring(0, 2);

            return DateTime.TryParse(date, out var _);
        }

        private static bool ValidCtrlNumbers(string fnr)
        {
            var sum1 = _ctrl1.Select((a, i) => (fnr[i] - '0') * a)
                .Sum() % 11;

            var ctrl1 = sum1 == 0 ? 0 : 11 - sum1;

            if (ctrl1 == 10 || ctrl1 != (fnr[9] - '0'))
            {
                return false;
            }

            var sum2 = _ctrl2.Select((a, i) => (fnr[i] - '0') * a)
                .Sum() % 11;

            var ctrl2 = sum2 == 0 ? 0 : 11 - sum2;

            if (ctrl2 == 10 || ctrl2 != (fnr[10] - '0'))
            {
                return false;
            }

            return true;
        }

        private static bool BornInAugust(string fnr)
        {
            return fnr[3] == '8';
        }

        private static bool IsWoman(string fnr)
        {
            return fnr[8] % 2 == 0;
        }
    }
}

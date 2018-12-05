using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag5
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "7", "6", "5", "4", "3", "2", "1" };
            var addsTo42 = 0;
            var ops = GetPermutationsWithRept(new List<string> { "+", "-", "X" }, numbers.Count - 1);
            
            foreach (var item in ops)
            {
                var itemList = item.ToList();
                var result = "";
                for (int i = 0; i < itemList.Count; i++)
                {
                    result += numbers[i] + itemList[i];
                }

                result += numbers.Last();

                if (Is42(result))
                {
                    addsTo42++;
                }
            }
            
            Console.WriteLine(addsTo42);
            Console.Read();
        }

        private static bool Is42(string input)
        {
            var inputWithoutX = input.Replace("X", "");
            var numbers = new List<long>();
            var ops = new List<char>();
            
            for (int i = 0; i < inputWithoutX.Length; i++)
            {
                string character = inputWithoutX[i].ToString();

                while ((i + 1) < inputWithoutX.Length && char.IsNumber(inputWithoutX[i + 1]))
                {
                    character += inputWithoutX[++i];
                }

                numbers.Add(long.Parse(character));

                if (i != inputWithoutX.Length - 1)
                {
                    ops.Add(inputWithoutX[++i]);
                }
            }

            var result = numbers[0];
            for (int i = 0; i < ops.Count; i++)
            {
                if (ops[i] == '+')
                {
                    result += numbers[i + 1];
                }
                else
                {
                    result -= numbers[i + 1];
                }
            }

            return result == 42;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutationsWithRept(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}

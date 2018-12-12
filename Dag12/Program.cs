using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"😡😚😀😷😨😥😮😀😩😀😤😩😥😌😀😩😀😷😡😮😮😡😀😤😩😥😀😬😩😫😥😀😣😡😥😳😡😲😎😀😱😚😀😨😯😷😀😣😯😭😥😟😀😡😚😀😨😥😀😤😩😥😤😀😡😭😯😮😧😀😨😩😳😀😦😲😩😥😮😤😳😎";
            var output = new List<int>();

            for (int i = 0; i < input.Length -1; i++)
            {
                output.Add(input[i] + input[++i]);
            }

            var minEmoji = output.Min();

            Console.WriteLine(new string(output.Select(a => (char)(a - minEmoji + 32)).ToArray()));
            Console.Read();
        }
    }
}

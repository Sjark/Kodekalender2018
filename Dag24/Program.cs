using System;
using System.Numerics;

namespace Dag24
{
    class Program
    {
        static string Alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
        static void Main(string[] args)
        {
            Console.WriteLine(NumberFromExcelColumn("GODJULOGGODTNYTTÅR"));
            Console.Read();
        }

        public static BigInteger NumberFromExcelColumn(string column)
        {
            BigInteger retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                BigInteger colNum = Alphabeth.IndexOf(colPiece) + 1;
                retVal = BigInteger.Add(retVal, BigInteger.Multiply(colNum, BigInteger.Pow(29, col.Length - (iChar + 1))));
            }

            return retVal;
        }
    }
}

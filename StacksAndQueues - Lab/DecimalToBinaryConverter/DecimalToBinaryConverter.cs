using System;
using System.Collections.Generic;
using System.Linq;

namespace DecimalToBinaryConverter
{
    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            int decimalNumber = int.Parse(Console.ReadLine());

            if (decimalNumber > 0)
            {
                Stack<int> binaryRepr = new Stack<int>();
                while (decimalNumber > 0)
                {
                    binaryRepr.Push(decimalNumber % 2);
                    decimalNumber /= 2;
                }

                int length = binaryRepr.Count;
                for (int i = 0; i < length; i++)
                {
                    Console.Write(binaryRepr.Pop());
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

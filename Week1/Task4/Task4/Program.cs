using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int size2 = size;
            string[,] array = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(array[i, j] = "[*]");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

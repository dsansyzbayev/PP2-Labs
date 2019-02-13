using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[int.Parse(Console.ReadLine())]; //Giving a size to array with a user input
            string[] nums = Console.ReadLine().Split(); //Read and splits line on single strings and fill string array
            num = Array.ConvertAll(nums, int.Parse); //convert string array into number array

            //Writing double numbers in the console

            for (int i = 0; i < num.Length; i++) //first loop for first number to be printed out
            {
                for (int j = -1; j <= i / num.Length; j++) //second number to be printed out
                {

                    Console.Write(num[i] + " "); //doubles and shows the number inputted

                }

            }
            Console.ReadKey();
        }
    }
}

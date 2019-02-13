using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = new string[50];
            line = System.IO.File.ReadAllText(@"C:\Users\Daniyar\Desktop\PP2\Lab2\L2T2\PrimeOrNot.txt").Split();
            int[] num = new int[line.Length];
            num = Array.ConvertAll(line, int.Parse);
            string Primes;


            List<int> ans = new List<int>();

            for (int i = 0; i < num.Length; i++) //1 is not prime number, so loop starts at 1
            {
                bool check = false;

                for (int j = 2; j <= Math.Sqrt(num[i]); j++)    //Prime numbers start at 2 and divisible on itself and 1
                {
                    if (num[i] % j == 0) //If non-prime number is found, bool 'check' change to true than loop break
                    {
                        check = true;

                        break;
                    }
                }
                if (check == false) //If check is still false, it means that prime number is found
                {
                    ans.Add(num[i]);
                    check = false;
                }
            }

            Primes = string.Join(" ", ans); //Join array elements in one string 
            File.WriteAllText(@"C:\Users\Daniyar\Desktop\PP2\Lab2\L2T2\Prime.txt", Primes); //write "Primes" string to the text file


            Console.ReadKey();
        }
    }
}

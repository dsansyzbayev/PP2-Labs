using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] num = new int[int.Parse(Console.ReadLine())]; //Giving a size to array with a user input
            string[] nums = Console.ReadLine().Split(); //Read and splits line on single strings and fill string array
            num = Array.ConvertAll(nums, int.Parse); //convert string array into number array
            int[] Pnum = new int[num.Length];//Array for prime numbers
            int n = 0;

            //Check if number is prime
            for (int i = 1; i < num.Length; i++) //1 is not prime number, so loop starts at 1
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
                    n++;    //this integer counts the number of primes
                    Pnum[i] = num[i]; //fills the array of prime numbers
                    check = false; //set check back to fall, so loop could start over
                }
            }
            Console.WriteLine(n); //showing number of primes

            foreach (var k in Pnum) // using foreach to show all prime numbers
            {
                if (k != 0)
                {
                    Console.Write(k + " ");
                }
            }




            Console.Read();
        }
    }
}

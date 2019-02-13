using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Daniyar\Desktop\PP2\Lab2\L2T1\T1.txt"); //Read all text from the '.txt' file

            Console.WriteLine("Is this word a polindrome? {0}", text); //Shows text from txt file and asks if this word a polyndrome

            bool check = true;
            int FL = 0;

            while (FL < text.Length - 1) //while loop which is active while first letter is less than last letter, if values are equal, loop breaks.
            {
                if (check) // if statement that lets you enter 'for' loop only if check is true
                {
                    for (int LL = text.Length - 1; LL >= 0; LL--) //'for' loop that checks if last letter is equal to the first letter
                    {
                        if (text[FL] == text[LL]) // check if first letter is equal to the last letter
                        {
                            check = true; // if they are equal 'check' stays true
                        }
                        else
                        {
                            check = false; //if they are not equal 'check' turns to false, loop breaks
                            break;
                        }
                        FL++; //goes to the next letter after the first one
                    }
                }
                else // if check is false, loop will break without checking all the letters
                {
                    break;
                }
            }

            // if check is true, console will write "Yes". if not, it will write "NO"

            if (check)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();


        }
    }
}

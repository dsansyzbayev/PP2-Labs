using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            Console.WriteLine(student1.GetName());
            Console.WriteLine(student1.GetID());
            Console.WriteLine(student1.GetYear());
            Console.ReadKey();



        }

    }
}

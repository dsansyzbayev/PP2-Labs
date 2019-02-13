using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Daniyar\source\path\test.txt"; //creating a path for the file
            string path1 = @"C:\Users\Daniyar\source\path1\test.txt";//creating a target path

            using (FileStream fs = File.Create(path)) { Console.WriteLine("File 'test.txt' is created in the path {0}", path); } //FIle is created in a new path

            if (File.Exists(path1)) //checks if target path containg file. if it does, deletes it
            {
                File.Delete(path1);
            }


            File.Move(path, path1); //moves file from one path to another and the delete file from path 1

            if (File.Exists(path1)) //check if file exists in a new path
            {
                Console.WriteLine("Old location of the file: the path {0} \nNew Location of the file: the path1 {1} ", path, path1);
            }

            Console.ReadKey();
        }
    }
}

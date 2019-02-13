using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Daniyar\source\repos"); //creating new directory
            CreateList(directory, 0); //Calls recursive function that goes through directory, and 0 is the beginning of spaces
            Console.ReadKey();
        }

        static void CreateList(FileSystemInfo FileSource, int t)
        {
            string spaces = new string(' ', t); //memory gets allocated for new string that uses 't' to count where to put spaces
            Console.WriteLine(spaces + FileSource.Name); //shows files and names
            if (FileSource.GetType() == typeof(DirectoryInfo)) //allows to enter the loop only members of type DirectoryInfo
            {
                FileSystemInfo[] mfiles = ((DirectoryInfo)FileSource).GetFileSystemInfos(); //Creates an array for found members of directory and fills it
                for (int i = 0; i < mfiles.Length; i++) //loop that recursively calls function untill it reach the size of array FileSystemInfo
                {
                    CreateList(mfiles[i], t + 3); //"+3" is needed to add spaces
                }
            }


        }


    }
}

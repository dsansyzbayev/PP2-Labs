using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    enum Mode{ DIR,FILE}
    class Program
    {
        static void Main(string[] args)
        {
            Mode mode = Mode.DIR; //Choosing the mode to be used in the beginning
            DirectoryInfo path = new DirectoryInfo(@"C:\Users\Daniyar\source\repos"); //allocates memory for class DirectoryInfo, in this case, it used to create path to the files
            Stack<Layer> history = new Stack<Layer>(); //allocates memory for class Stack that stack instances of the same type in this case, it's class Layer
            history.Push(   //Here we push on top of the 'history' stack a new instance of "Layer" that is filled information received from the path 
                    new Layer
                    {
                        Content = path.GetFileSystemInfos().ToList(),
                        Item = 0
                    }
                );


            while (true)
            {
                if (mode == Mode.DIR)
                {
                    history.Peek().Draw();  //when mode is DIR, top of stack is peeked, and then Draw function is called
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();  //Class of ConsoleKeyInfo is created that read keys from keyboard
                switch (consoleKeyInfo.Key) //the process of switching between different cases
                {
                    case ConsoleKey.UpArrow:    //UpArrow key lets you move up the list of  files or directories
                        history.Peek().Item--;
                        break;

                    case ConsoleKey.DownArrow: //DownArraw key lets you move down the list of file or directories
                        history.Peek().Item++;
                        break;

                    case ConsoleKey.Backspace: //Backspace key lets you leave the file or direcotory
                        if (mode == Mode.DIR)
                        {
                            history.Pop();
                        }
                        else
                        {
                            mode = Mode.DIR;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.Enter:  //Enter key lets you enter inside of file or directory
                        FileSystemInfo fileSystemInfo = history.Peek().Content[history.Peek().Item];  //Class of FileSystemInfo is created that peek through Content List with peeked item from stack
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo)) //Check what type of FileSystemInfo is detected. If it is a directory it pass the first 'if' statement. If not,it will move to 'else' statement.
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            history.Push(
                               new Layer
                               {
                                   Content = directoryInfo.GetFileSystemInfos().ToList(),
                                   Item = 0
                               });
                        }
                        else //here file will go if it does not pass 'if' statement
                        {
                            mode = Mode.FILE;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            using (StreamReader sr = new StreamReader(fileSystemInfo.FullName))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                        break;

                   case ConsoleKey.Delete:  //Delete key lets you delete files or directories
                        history.Peek().DeleteItem();
                        break;

                   case ConsoleKey.F2:  //F2 key lets you rename directory or file
                        history.Peek().Rename(history.Peek().Content[history.Peek().Item]);
                        break;
                    case ConsoleKey.Escape: //Escape key lets you close everything and exit console
                        Environment.Exit(0);
                        break;
                   
                }
                   
                
            }
        }
    }
}
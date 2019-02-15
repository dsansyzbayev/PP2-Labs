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
            Mode mode = Mode.DIR;
            DirectoryInfo path = new DirectoryInfo(@"C:\Users\Daniyar\source\repos");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(
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
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().Item--;
                        break;

                    case ConsoleKey.DownArrow:
                        history.Peek().Item++;
                        break;

                    case ConsoleKey.Backspace:
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

                    case ConsoleKey.Enter:
                        int x = history.Peek().Item;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            history.Push(
                               new Layer
                               {
                                   Content = directoryInfo.GetFileSystemInfos().ToList(),
                                   Item = 0
                               });
                        }
                        else
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

                   case ConsoleKey.Delete:
                        history.Peek().DeleteItem();
                        break;

                   case ConsoleKey.F2:
                        history.Peek().Rename(history.Peek().Content[history.Peek().Item]);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                   
                }
                   
                
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarManager
{
    class Layer
    {
        private int item;
        public int Item
        {
            get
            {
                return item;
            }
            set
            {
                if(value >= Content.Count)
                {
                    item = 0;
                }
                else if(value < 0)
                {
                    item = Content.Count - 1;
                }
                else
                {
                    item = value;
                }

            }
        }
        
        public List<FileSystemInfo> Content
        {
            get;
            set;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            for ( int i = 0; i < Content.Count; i++)
            {
                if(i == Item)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(i+1 +". "+ Content[i].Name);
            }
        }

        public void DeleteItem()
        {
            FileSystemInfo fsi = Content[Item];
            if(fsi.GetType() == typeof(DirectoryInfo) )
            {
                Directory.Delete(fsi.FullName, true);
            }
            else
            {
                File.Delete(fsi.FullName);
            }
            Content.RemoveAt(Item);
            Item--;
        }
       
        public void Rename(FileSystemInfo fsi)
        {
            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo dir = fsi as DirectoryInfo;
                for (int i = 1; i <= 2; i++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("  ");
                }
                Console.Write("Name: ");
                string newname = Path.Combine(dir.Parent.FullName, Console.ReadLine());
                dir.MoveTo(newname);
            }
            else
            {
                FileInfo file = fsi as FileInfo;
                for (int i = 1; i <= 2; i++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("  ");
                }
                Console.Write("Name:");
                string newname = Path.Combine(file.Directory.FullName, Console.ReadLine());
                file.MoveTo(newname);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    public class Mark
    {
        public string Name { get; set; }
        public string GPA { get; set; }

        public string getLetter()
        {
            return GPA;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, GPA);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            FileStream fs = new FileStream("stundent.xml", FileMode.Create, FileAccess.Write);

            Mark m = new Mark();
            List<Mark> marks = new List<Mark>();
            Random random = new Random(DateTime.Now.Second);

            for (int i = 0; i < 5; ++i)
            {
                marks.Add(new Mark
                {
                    Name = Guid.NewGuid().ToString(),
                    GPA = random.Next(0, 4).ToString()
                });
            }

            xs.Serialize(fs, marks);

            fs.Close();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task1
{
    public class Complex
    {
        public double a;
        public double b;

        XmlSerializer xs = new XmlSerializer(typeof(Complex));
        string fname = "Complex.xml";

        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0} + {1}*i", a, b));
        }
        
        public void Serialize()
        {
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Complex Deserialize()
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            Complex complex = xs.Deserialize(fs) as Complex;
            fs.Close();
            return complex;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex com = new Complex();
            com.a = 2;
            com.b = 3;
            com.PrintInfo();
            com.Serialize();

            Complex com2 = com.Deserialize();
            Console.WriteLine(com2);

            Console.ReadKey();
        }
    }
}

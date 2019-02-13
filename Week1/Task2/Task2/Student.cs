using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        String Name;
        String Id;
        double Year;

        public Student()
        {
            Name = "Daniyar Sansyzbayev";
            Id = "19BD00001";
            Year = 2019;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetID()
        {
            return Id;
        }

        public double GetYear()
        {
            return Year++;
        }
    }
}

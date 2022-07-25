using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak12345.Fdnevnik;

namespace Zadatak12345
{
    public class Student
    {
        public static int Id { get; set; } = 0;
        public int ID { get; set; }
        public Adress Adress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public SpisakPredmeta GradeList { get; set; }
        public Student(Adress a)
        {
            GradeList = new SpisakPredmeta();
            Adress = a;
            ID = Id++;
        }

        public int getID()
        {
            return ID;
        }

        public string getName()
        {
            return Name;
        }

        public Adress getAdress()
        {
            return Adress;
        }     
    }
}

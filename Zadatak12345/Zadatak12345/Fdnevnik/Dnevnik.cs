using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak12345.Fdnevnik
{
    public sealed class Dnevnik
    {
        private Dictionary<string, Odeljenje> dnevnik = new Dictionary<string, Odeljenje>();

        
        public Dictionary<string, Odeljenje> getDnevnik()
        {
            return dnevnik;
        }
        public void addOdeljenje(Odeljenje o)
        {
            dnevnik.Add(o.Name, o);
        }

        public Odeljenje GetOdeljenje(string odeljenje)
        {
            return dnevnik[odeljenje];
        }

        public Student GetStudent(string odeljenje, string student)
        {
            return dnevnik[odeljenje].getStudentByName(student);
        }

        public Student GetStudent(string odeljenje, int student)
        {
            return dnevnik[odeljenje].getStudentByID(student);
        }

        

       
        private Dnevnik() { }
        private static Dnevnik instance = null;
        public static Dnevnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dnevnik();


                }
                return instance;
            }
        }


    }
}

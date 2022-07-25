using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak12345.Fdnevnik;

namespace Zadatak12345
{
    internal interface IProfesor : IKorisnik
    {
        public void setOdsustvo(Student s, bool x);

        public void addGrade(Student s, byte o);

       // public void setLogChanges(List<string> x, string oo);
    }
}

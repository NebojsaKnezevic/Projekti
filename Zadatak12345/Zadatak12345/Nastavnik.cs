using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak12345.Fdnevnik;

namespace Zadatak12345
{
    public class Nastavnik : Student, IProfesor
    {

        
        public static int PID { get; set; } = 0;
        public string PredajePredmet { get; set; }

        public Odeljenje odel;
        public Nastavnik(Adress a, Odeljenje o) : base(a)
        {
            ID = ++PID;
            odel = o;
            Id--;
        }

        public void setOdsustvo(Student s, bool x)
        {
            DateTime datum = DateTime.Now;
            setLogChanges($"[{datum}] Predmet: {PredajePredmet} odsutan: {s.Name} opravdanost: {x}", "Odsustvo");
            
        }

        public void addGrade(Student s, byte o)
        {
            DateTime datum = DateTime.Now;
            s.GradeList.setGrade($"{PredajePredmet.ToLower()}", o);
            setLogChanges($"[{datum}] Ucenik {s.Name} dobio ocenu {o} iz {PredajePredmet}", "Ocena");
            
            //  d.GetStudent(odel.Name, s.Name).GradeList.setGrade(PredajePredmet.ToLower(), o);
            //  setLogChanges($"Ucenik {s.Name} dobio ocenu {o} iz {PredajePredmet}", "Ocena");
        }

        public void prosekUcenika(Dnevnik d, string odeljenje, int student)
        {
            DateTime datum = DateTime.Now;
           
            setLogChanges($"[{datum}] Izracuna prosek ucenika {d.GetStudent(odeljenje, student).Name}: {Math.Round(d.GetStudent(odeljenje, student).GradeList.prosekSvihOcena(), 2)}", "Ocena");
           
        }
        public async void prosekOdeljenja(Dnevnik d, Odeljenje odeljenje)
        {
            DateTime datum = DateTime.Now;
            int i = 0;
            double sum = 0;

            foreach (var s in d.getDnevnik()[odeljenje.Name].studentsByID)
            {
                sum += s.Value.GradeList.prosekSvihOcena();
                Console.WriteLine($"SUMA: {sum}");
                i++;
            }
            
            //setLogChanges(grades, "Ocena");
            setLogChanges($"[{datum}] Prosek odeljenja: {odeljenje.Name} iznosi: {Math.Round(sum / i, 2)}", "Ocena");
           

        }

        public void setLogChanges(string x, string oo)
        {
            string filePath = @$"C:\Users\WIN10\source\repos\Zadatak12345\Zadatak12345\Fdnevnik\log{oo}.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(x);
                
            }
          
        }
    }
}

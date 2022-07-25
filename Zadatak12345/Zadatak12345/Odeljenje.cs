using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak12345;

namespace Zadatak12345
{
    public class Odeljenje
    {
        public string Name { get; set; }
        public Dictionary<string,Student> studentsByName { get; set; }
        public Dictionary<int, Student> studentsByID { get; set; }

        public Nastavnik Staresina { get; set; }
        public Odeljenje(string name)
        {
            studentsByID = new Dictionary<int, Student>();
            studentsByName = new Dictionary<string, Student>();
            Name = name;
        }

        public Student getStudentByName(string s)
        {
            return studentsByName[s];
        }

        public void setStudent(Student s)
        {
            studentsByID.Add(s.ID, s);
            studentsByName.Add(s.Name, s);
        }

        public Student getStudentByID(int n)
        {
            return studentsByID[n];
        }
    }
}

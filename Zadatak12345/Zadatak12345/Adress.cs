using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak12345
{
    public class Adress
    {
        public int StreetNumber { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }

        public Adress(int nubmer, string city, string street)
        {
            StreetName = street;
            StreetNumber = nubmer;
            CityName = city;
        }
    }
}

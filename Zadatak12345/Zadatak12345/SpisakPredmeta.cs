using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak12345
{
    public class SpisakPredmeta
    {
        protected List<byte> Matematika;
        protected List<byte> Fizika;
        protected List<byte> Biologija;
        protected List<byte> Geografija;
        protected List<byte> Istorija;

        public SpisakPredmeta()
        {
            Matematika = new List<byte>();
            Fizika = new List<byte>();
            Biologija = new List<byte>();
            Geografija = new List<byte>();
            Istorija = new List<byte>();
        }

        public void setGrade(string x, byte o)
        {
            switch (x.ToLower())
            {
                case "matematika":
                    Matematika.Add(o);
                    break;
                case "fizika":
                    Fizika.Add(o);
                    break;
                case "biologija":
                    Biologija.Add(o);
                    break;
                case "geografija":
                    Geografija.Add(o);
                    break;
                case "istorija":
                    Istorija.Add(o);
                    break;
                default:
                    throw new Exception("Predmet nije na spisku!");
            }
        }
        public double prosekSvihOcena()
        {
            return (prosekPredmeta(Matematika) + prosekPredmeta(Fizika) + prosekPredmeta(Geografija) + prosekPredmeta(Istorija) + prosekPredmeta(Biologija)) / 5.00;
        }
        public double prosekPredmeta(List<byte> p)
        {
            double sum = 0;
            int i = 0;
            while(i < p.Count)
            {
                sum += p[i];
                i++;
            }
            return sum / i;
        }
    }
}

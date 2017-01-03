using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.CarnetSuivi
{
    public class Entry
    {
        public String entryName { get; set; }
        public Double glycemie { get; set; }
        public Double glucides { get; set; } // g/100g
        public Double totalGlucids { get; set; }
        public int rapide { get; set; }
        public Uri alimentLogo { get; set; }

        public Entry() { }

        public Entry(String name, Double glycemie, Double glucides, int rapide)
        {
            this.entryName = name;
            this.glycemie = glycemie;
            this.glucides = glucides;
            this.rapide = rapide;
        }
    }
}

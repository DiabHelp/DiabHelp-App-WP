using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.Glucocompteur
{
    public class Aliment
    {
        public String alimentname { get; set; }
        public Double weight { get; set; }
        public Double Glucides { get; set; } // g/100g
        public Double totalGlucids { get; set; }
        public Uri alimentLogo { get; set; }

        public Aliment() { }

        public Aliment(String name, Double weight, Double glucids)
        {
            this.alimentname = name;
            this.weight = weight;
            this.Glucides = glucids;
            this.totalGlucids = (weight * glucids) / 100;
        }


    }
}

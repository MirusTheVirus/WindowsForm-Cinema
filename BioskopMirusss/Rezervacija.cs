using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Rezervacija
    {
        private int idprojekcije, idkupca, brmesta;
        private double ukupnacena;

        public Rezervacija(int idprojekcije, int idkupca, int brmesta, double ukupnacena)
        {
            this.Idprojekcije = idprojekcije;
            this.Idkupca = idkupca;
            this.Brmesta = brmesta;
            this.Ukupnacena = ukupnacena;
        }

        public int Idprojekcije { get => idprojekcije; set => idprojekcije = value; }
        public int Idkupca { get => idkupca; set => idkupca = value; }
        public int Brmesta { get => brmesta; set => brmesta = value; }
        public double Ukupnacena { get => ukupnacena; set => ukupnacena = value; }

        public override string ToString()
        {
            return "Id projekcije: " + idprojekcije.ToString() + " id kupca: "+idkupca.ToString() + "; Broj mesta: "+brmesta.ToString() + " Ukupna cena: "+ukupnacena.ToString();
        }
    }
}

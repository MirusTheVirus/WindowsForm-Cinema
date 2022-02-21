using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Kupac : Korisnik
    {
        private string ime, prezime,pol;
        private int telefon;
        private DateTime datumrodjenja;
        private bool ban = false;

        public Kupac(string username,string password,int id,string ime, string prezime, string pol, int telefon, DateTime datumrodjenja)
            :base(username,password,id)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Telefon = telefon;
            this.Datumrodjenja = datumrodjenja;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Pol { get => pol; set => pol = value; }
        public int Telefon { get => telefon; set => telefon = value; }
        public DateTime Datumrodjenja { get => datumrodjenja; set => datumrodjenja = value; }
        public bool Ban { get => ban; set => ban = value; }

        public override string ToString()
        {
            return ime+" " + prezime + "; Ban: " + (ban ? "DA" : "NE");
        }
        public string sveInformacije()
        {
            return "Ime i prezime: "+ ime + " " + prezime + "; Datum Rodjenja: " + datumrodjenja + "; pol: " + pol + "; Broj telefona: " + telefon+"; Ban: "+ (ban ? "DA" : "NE");
        }
    }
}

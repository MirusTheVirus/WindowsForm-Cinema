using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Administrator : Korisnik
    {
        private string ime, prezime;
        private int telefon;

        public Administrator(string username, string password, int id,string ime, string prezime, int telefon)
            :base(username,password,id)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Telefon = telefon;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public int Telefon { get => telefon; set => telefon = value; }

        public override string ToString()
        {
            return Ime + " " + Prezime + "; telefon: " + Telefon;
        }
    }
}

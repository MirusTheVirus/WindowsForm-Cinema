using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Film
    {
        private int id, trajanje, granicagodina;
        private string naziv, zanr;

        public Film(int id, int trajanje, int granicagodina, string naziv, string zanr)
        {
            this.Id = id;
            this.Trajanje = trajanje;
            this.Granicagodina = granicagodina;
            this.Naziv = naziv;
            this.Zanr = zanr;
        }

        public int Id { get => id; set => id = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public int Granicagodina { get => granicagodina; set => granicagodina = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }

        public override string ToString()
        {
            return "\""+naziv+"\" "+trajanje+" min";
        }
    }
}

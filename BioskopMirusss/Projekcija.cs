using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Projekcija
    {
        private int id,brsati,brmin,brdostupnihsedista;
        private double cenakarte;
        private DateTime datumprojekcije;
        private Sala sala;
        private Film film;
        private bool dostupan = true;

        public Projekcija(int id, Film film, Sala sala, double cenakarte, DateTime datumprojekcije, int brsati, int brmin)
        {
            this.Id = id;
            this.Film = film;
            this.Sala = sala;
            this.Cenakarte = cenakarte;
            this.Datumprojekcije = datumprojekcije;
            this.Brsati = brsati;
            this.Brmin = brmin;
            Brdostupnihsedista = sala.Brsedista;
        }

        public int Id { get => id; set => id = value; }
        public int Brsati { get => brsati; set => brsati = value; }
        public int Brmin { get => brmin; set => brmin = value; }
        public double Cenakarte { get => cenakarte; set => cenakarte = value; }
        public DateTime Datumprojekcije { get => datumprojekcije; set => datumprojekcije = value; }
        public int Brdostupnihsedista { get => brdostupnihsedista; set => brdostupnihsedista = value; }
        public bool Dostupan { get => dostupan; set => dostupan = value; }
        internal Sala Sala { get => sala; set => sala = value; }
        internal Film Film { get => film; set => film = value; }

        public string satminut()
        {
            return brsati.ToString() + ":" + brmin.ToString();
        }
        public override string ToString()
        {
            return film.ToString() + "; Cena karte: " + cenakarte + "; Datum i vreme: " + datumprojekcije.ToString("dd.MM.yyyy.")+" - "+satminut()+"; "+sala.ToString()+"; Broj dostupnih sedista: "+brdostupnihsedista;
        }

    }
}

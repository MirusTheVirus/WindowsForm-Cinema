using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Korisnik
    {
        private string username, password;
        private int id;

        public Korisnik(string username, string password,int id)
        {
            this.Username = username;
            this.Password = password;
            this.Id = id;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }

        public bool uporediKorisnika(string name,string pass)
        {
            if (username == name && password == pass)
                return true;
            else;
            return false;
        }

    }
}

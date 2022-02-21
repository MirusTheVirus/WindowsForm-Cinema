using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopMirusss
{
    [Serializable()]
    class Sala
    {
        private int id, brsale, brsedista;

        public Sala(int id, int brsale, int brsedista)
        {
            this.Id = id;
            this.Brsale = brsale;
            this.Brsedista = brsedista;
        }

        public int Id { get => id; set => id = value; }
        public int Brsale { get => brsale; set => brsale = value; }
        public int Brsedista { get => brsedista; set => brsedista = value; }

        public override string ToString()
        {
            return "Sala " + brsale;
        }
    }
}

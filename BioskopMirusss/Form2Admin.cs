using BioskopMirusss.AdminForme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioskopMirusss
{
    public partial class Form2Admin : Form
    {
        public Form2Admin()
        {
            InitializeComponent();
        }

        private void btnFilmovi_Click(object sender, EventArgs e)
        {
            FormFilm ff = new FormFilm();
            ff.ShowDialog();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            FormSale fs = new FormSale();
            fs.ShowDialog();
        }

        private void btnProjekcije_Click(object sender, EventArgs e)
        {
            FormProjekcije fp = new FormProjekcije();
            fp.ShowDialog();
        }

        private void btnKupci_Click(object sender, EventArgs e)
        {
            FormKupci fk = new FormKupci();
            fk.ShowDialog();
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            FormRezervacije fr = new FormRezervacije();
            fr.ShowDialog();
        }

        private void btnAdmini_Click(object sender, EventArgs e)
        {
            FormAdmini fa = new FormAdmini();
            fa.ShowDialog();
        }
    }
}

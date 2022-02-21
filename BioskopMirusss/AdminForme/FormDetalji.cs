using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioskopMirusss.AdminForme
{
    public partial class FormDetalji : Form
    {
        List<Projekcija> projekcije;
        List<Kupac> kupci;
        string putanjaKupac = "Kupci.txt";
        string putanjaP = "Projekcije.txt";
        public FormDetalji()
        {
            kupci = new List<Kupac>();
            projekcije = new List<Projekcija>();
            InitializeComponent();
        }
        Form r;
        public void pokazi(int idk,int idp,Form roditelj)
        {
            r = roditelj;
            foreach (Kupac k in kupci)
                if (k.Id == idk)
                    lblKupac.Text = k.sveInformacije();
            foreach (Projekcija p in projekcije)
                if (p.Id == idp)
                    lblProjekcija.Text = p.ToString();
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            gud();
            this.Close();
            
        }
        public delegate void dug();
        public event dug gud;
        private void FormDetalji_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaKupac))
            {
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Dispose();
            }
            if (File.Exists(putanjaP))
            {
                FileStream fs = new FileStream(putanjaP, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                fs.Dispose();
            }
        }
    }
}

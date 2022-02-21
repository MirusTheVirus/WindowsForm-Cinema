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
    public partial class FormRezervacije : Form
    {
        string putanjaR = "Rezervacije.txt";
        List<Rezervacija> rezervacije;
        int indeks;
        List<Projekcija> projekcije;
        string putanjaP = "Projekcije.txt";
        public FormRezervacije()
        {
            rezervacije = new List<Rezervacija>();
            projekcije = new List<Projekcija>();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaR) && File.Exists(putanjaP))
            {
                indeks = listBox1.SelectedIndex;
                int idp = rezervacije[indeks].Idprojekcije;
                for (int i = 0; i < projekcije.Count(); i++)
                {
                    if(idp==projekcije[i].Id)
                        projekcije[i].Brdostupnihsedista += rezervacije[indeks].Brmesta;
                }
                rezervacije.RemoveAt(indeks);
                listBox1.Items.RemoveAt(indeks);
                FileStream fs = new FileStream(putanjaR, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, rezervacije);
                fs.Dispose();
                FileStream fsp = new FileStream(putanjaP, FileMode.Open, FileAccess.Write);
                BinaryFormatter bfp = new BinaryFormatter();
                bfp.Serialize(fsp, projekcije);
                fsp.Dispose();
                btnBrisi.Enabled = false;
            }
        }
        public void dugme()
        {
            btnDetalji.Enabled = true;
        }
        private void FormRezervacije_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaP))
            {
                FileStream fs = new FileStream(putanjaP, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                fs.Dispose();
            }
            if (File.Exists(putanjaR))
            {
                FileStream fs = new FileStream(putanjaR, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacija>;
                fs.Dispose();
                foreach (Rezervacija r in rezervacije)
                    listBox1.Items.Add(r.ToString());
            }
        }
        FormDetalji fd;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnBrisi.Enabled = true;
                indeks = listBox1.SelectedIndex;
                if (btnDetalji.Enabled==false)
                {
                    nin(rezervacije[indeks].Idkupca, rezervacije[indeks].Idprojekcije,this);
                }
            }
        }
        public delegate void nosiInfo(int idkupca, int idprojekcije,Form roditelj);
        public nosiInfo nin;
        private void btnDetalji_Click(object sender, EventArgs e)
        {
            fd = new FormDetalji();
            this.nin += new nosiInfo(fd.pokazi);
            fd.gud += new FormDetalji.dug(dugme);
            fd.Show();
            btnDetalji.Enabled = false;
        }
    }
}

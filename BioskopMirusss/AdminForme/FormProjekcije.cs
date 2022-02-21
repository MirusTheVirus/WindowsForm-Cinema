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
    public partial class FormProjekcije : Form
    {
        int iden = 0;
        string putanjaS = "Sale.txt";
        string putanjaF = "Filmovi.txt";
        string putanjaP = "Projekcije.txt";
        List<Sala> sale;
        List<Film> filmovi;
        List<Projekcija> projekcije;
        bool menjanje = false;
        int indeksmenjanja = 0, idmenjanja = 0;
        public FormProjekcije()
        {
            sale = new List<Sala>();
            filmovi = new List<Film>();
            projekcije = new List<Projekcija>();
            InitializeComponent();
        }

        private void FormProjekcije_Load(object sender, EventArgs e)
        {
            dtpDatum.MinDate = DateTime.Today;
            dtpDatum.Value = DateTime.Today;
            if (File.Exists(putanjaF))
            {
                FileStream fs = new FileStream(putanjaF, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                fs.Dispose();
                iden = filmovi[filmovi.Count() - 1].Id + 1;
                foreach (Film f in filmovi)
                    cbFilmovi.Items.Add(f.ToString());
                cbFilmovi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Nije moguce napraviti projekciju bez filma!");
                this.Close();
            }
            if (File.Exists(putanjaS))
            {
                FileStream fs = new FileStream(putanjaS, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                sale = bf.Deserialize(fs) as List<Sala>;
                fs.Dispose();
                iden = sale[sale.Count() - 1].Id + 1;
                foreach (Sala s in sale)
                    cbSale.Items.Add(s.ToString());
                cbSale.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Nije moguce napraviti projekciju bez sale!");
                this.Close();
            }
            if (File.Exists(putanjaP))
            {
                FileStream fs = new FileStream(putanjaP, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                projekcije = bf.Deserialize(fs) as List<Projekcija>;
                fs.Dispose();
                iden = projekcije[projekcije.Count() - 1].Id + 1;

                for (int i = 0; i < projekcije.Count(); i++)
                {
                    bool ima = false;
                    foreach (Sala s in sale)
                    {
                        if (s.Id == projekcije[i].Sala.Id)
                            ima = true;
                    }
                    if (!ima)
                        projekcije[i].Dostupan = false;
                }
                for (int i = 0; i < projekcije.Count(); i++)
                {
                    bool ima = false;
                    foreach (Film f in filmovi)
                    {
                        if (f.Id == projekcije[i].Film.Id)
                            ima = true;
                    }
                    if (!ima)
                        projekcije[i].Dostupan = false;
                }
                for (int i = 0; i < projekcije.Count(); i++)
                {
                    listBox1.Items.Add(projekcije[i].ToString() + (projekcije[i].Dostupan ? "" : " NEDOSTUPAN"));
                }
                FileStream fsp = new FileStream(putanjaP, FileMode.Open, FileAccess.Write);
                BinaryFormatter bfp = new BinaryFormatter();
                bfp.Serialize(fsp, projekcije);
                fsp.Dispose();
            }

        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilmovi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=true;
        }

        private void cbSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            double broj = 0;
            if (!double.TryParse(txtCenaKarte.Text, out broj))
            {
                MessageBox.Show("Nisu uneti podaci");
            }
            else
            {
                Projekcija pro = new Projekcija(iden,filmovi[cbFilmovi.SelectedIndex],sale[cbSale.SelectedIndex],broj,dtpDatum.Value,int.Parse(nupSati.Text),int.Parse(nupMinuti.Text));
                if (File.Exists(putanjaP))
                {
                    if (menjanje)
                    {
                        menjanje = false;
                        pro.Id = idmenjanja;
                        projekcije[indeksmenjanja] = pro;
                    }
                    else
                    {
                        pro.Id = iden;
                        projekcije.Add(pro);
                        iden++;
                    }
                    FileStream fs = new FileStream(putanjaP, FileMode.Open, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, projekcije);
                    fs.Dispose();
                }
                else
                {
                    projekcije.Add(pro);
                    FileStream fsa = new FileStream(putanjaP, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsa, projekcije);
                    fsa.Dispose();
                    iden++;
                }
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
                txtCenaKarte.Clear();
                listBox1.Items.Clear();
                foreach (Projekcija p in projekcije)
                    listBox1.Items.Add(p.ToString() + (p.Dostupan ? "" : " NEDOSTUPAN"));
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaP))
            {
                indeksmenjanja = listBox1.SelectedIndex;
                projekcije.RemoveAt(indeksmenjanja);
                listBox1.Items.RemoveAt(indeksmenjanja);
                FileStream fs = new FileStream(putanjaP, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, projekcije);
                fs.Dispose();
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            menjanje = true;
            indeksmenjanja = listBox1.SelectedIndex;
            idmenjanja = filmovi[indeksmenjanja].Id;
            dtpDatum.Value = projekcije[indeksmenjanja].Datumprojekcije;
            nupSati.Value = projekcije[indeksmenjanja].Brsati;
            nupMinuti.Value = projekcije[indeksmenjanja].Brmin;
            txtCenaKarte.Text = projekcije[indeksmenjanja].Cenakarte.ToString();
            for (int i = 0; i < cbFilmovi.Items.Count; i++)
                if (projekcije[indeksmenjanja].Film.Id == filmovi[i].Id)
                    cbFilmovi.SelectedIndex = i;
            for (int i = 0; i < cbSale.Items.Count; i++)
                if (projekcije[indeksmenjanja].Sala.Id == sale[i].Id)
                    cbSale.SelectedIndex = i;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnIzmeni.Enabled = true;
                btnBrisi.Enabled = true;
            }
        }

        private void nupSati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

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

namespace BioskopMirusss
{
    public partial class Form2 : Form
    {
        List<Rezervacija> rezervacije;
        List<Kupac> kupci;
        List<Sala> sale;
        List<Film> filmovi;
        List<Projekcija> projekcije;
        string putanjaR = "Rezervacije.txt";
        string putanjaKupac = "Kupci.txt";
        string putanjaS = "Sale.txt";
        string putanjaF = "Filmovi.txt";
        string putanjaP = "Projekcije.txt";
        int idKupca;
        public Form2(int id)
        {
            rezervacije = new List<Rezervacija>();
            kupci = new List<Kupac>();
            sale = new List<Sala>();
            filmovi = new List<Film>();
            projekcije = new List<Projekcija>();
            filterlista = new List<Projekcija>();
            InitializeComponent();
            idKupca = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dtpPocetni.MinDate = DateTime.Today;
            dtpKrajnji.MinDate = DateTime.Today;
            dtpPocetni.Value = DateTime.Today;
            dtpKrajnji.Value = DateTime.Today;
            if (File.Exists(putanjaKupac))
            {
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Dispose();
            }
            if (File.Exists(putanjaS))
            {
                FileStream fs = new FileStream(putanjaS, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                sale = bf.Deserialize(fs) as List<Sala>;
                fs.Dispose();
            }
            if (File.Exists(putanjaF))
            {
                FileStream fs = new FileStream(putanjaF, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                fs.Dispose();
            }
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
            }
            cbFilmovi.Items.Add("Svi filmovi");
            cbSale.Items.Add("Sve sale");
            cbFilmovi.SelectedIndex = 0;
            cbSale.SelectedIndex = 0;
            foreach (Sala s in sale)
                cbSale.Items.Add(s.ToString());
            foreach (Film f in filmovi)
                cbFilmovi.Items.Add("\"" + f.Naziv + "\"");
            Osvezi();
        }
        public void Osvezi()
        {
            foreach (Kupac k in kupci)
                if (k.Id == idKupca)
                    label2.Text = "Dobrodosli " + k.Ime + " " + k.Prezime;
            foreach (Projekcija p in projekcije)
                if(p.Dostupan)
                {
                    if (DateTime.Now.Date < p.Datumprojekcije.Date)
                        filterlista.Add(p);
                    else if(DateTime.Now.Date==p.Datumprojekcije.Date)
                        if(DateTime.Now.Hour<p.Brsati)
                            filterlista.Add(p);
                        else if(DateTime.Now.Hour==p.Brsati)
                            if(DateTime.Now.Minute<p.Brmin)
                                filterlista.Add(p);
                }
                
            listBox1.Items.Clear();
            foreach (Projekcija p in filterlista)
                listBox1.Items.Add(p.ToString());
            cbFilmovi.SelectedIndex = 0;
            cbSale.SelectedIndex = 0;
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<Projekcija> filterlista;
        private void btnFiltriraj_Click(object sender, EventArgs e)
        {
            btnRezervisi.Enabled = false;
            nupBrMesta.Value = 1;
            txtUkupnaCena.Clear();
            filterlista = new List<Projekcija>();
            listBox1.Items.Clear();
            int os = cbSale.SelectedIndex;
            int of = cbFilmovi.SelectedIndex;
            bool sves = false;
            if (os == 0)
                sves = true;
            bool svif = false;
            if (of == 0)
                svif = true;
            foreach (Projekcija p in projekcije)
            {
                bool unutarvremena = false;
                if (p.Dostupan)
                {
                    if (dtpPocetni.Value.Date > dtpKrajnji.Value.Date)
                        MessageBox.Show("Krajnji datum je pre pocetnog!");
                    else
                    {
                        if (dtpPocetni.Value.Date < p.Datumprojekcije.Date && dtpKrajnji.Value.Date >= p.Datumprojekcije.Date)
                            unutarvremena = true;
                        else if (dtpPocetni.Value.Date == p.Datumprojekcije.Date)
                        {
                            if (p.Brsati > DateTime.Now.Hour)
                                unutarvremena = true;
                            else if (p.Brsati == DateTime.Now.Hour)
                                if (p.Brmin > DateTime.Now.Minute)
                                    unutarvremena = true;
                        }
                    }
                    if (unutarvremena)
                    {
                        if (sves && svif)
                        {
                            listBox1.Items.Add(p.ToString());
                            filterlista.Add(p);
                        }
                        else if (!sves && !svif && p.Sala.Id == sale[os - 1].Id && p.Film.Id == filmovi[of - 1].Id)
                        {
                            listBox1.Items.Add(p.ToString());
                            filterlista.Add(p);
                        }
                        else if (sves && p.Film.Id == filmovi[of - 1].Id)
                        {
                            listBox1.Items.Add(p.ToString());
                            filterlista.Add(p);
                        }
                        else if (!sves && p.Sala.Id == sale[os - 1].Id && svif)
                        {
                            listBox1.Items.Add(p.ToString());
                            filterlista.Add(p);
                        }
                    }
                }
            }
        }
        int indeks;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                indeks = listBox1.SelectedIndex;
                btnRezervisi.Enabled = true;
                nupBrMesta.Maximum = filterlista[indeks].Brdostupnihsedista;
                txtUkupnaCena.Text = (double.Parse(nupBrMesta.Text)* filterlista[indeks].Cenakarte).ToString();
            }
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            Rezervacija r = new Rezervacija(filterlista[indeks].Id, idKupca, int.Parse(nupBrMesta.Text), double.Parse(nupBrMesta.Value.ToString()) * filterlista[indeks].Cenakarte);
            rezervacije.Add(r);
            int p=0;
            for (int i = 0; i < projekcije.Count(); i++)
            {
                if (projekcije[i].Id == filterlista[indeks].Id)
                {
                    projekcije[i].Brdostupnihsedista -= r.Brmesta;
                    p = i;
                }
            }
            if (File.Exists(putanjaR))
            {
                FileStream fs = new FileStream(putanjaR, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, rezervacije);
                fs.Dispose();
            }
            else
            {
                FileStream fsa = new FileStream(putanjaR, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fsa, rezervacije);
                fsa.Dispose();
            }
            FileStream fss = new FileStream(putanjaP, FileMode.Open, FileAccess.Write);
            BinaryFormatter bff = new BinaryFormatter();
            bff.Serialize(fss, projekcije);
            fss.Dispose();
            listBox1.Items[indeks] = projekcije[p].ToString();
            MessageBox.Show("Uspesno ste rezervisali mesta!");
        }

        private void txtUkupnaCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupBrMesta_ValueChanged(object sender, EventArgs e)
        {
            double x= double.Parse(nupBrMesta.Value.ToString()) * filterlista[indeks].Cenakarte;
            txtUkupnaCena.Text = x.ToString();
        }

        private void cbSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbFilmovi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

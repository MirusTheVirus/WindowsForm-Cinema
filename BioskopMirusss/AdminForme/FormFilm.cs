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
    public partial class FormFilm : Form
    {
        public string putanjaF = "Filmovi.txt";
        List<Film> filmovi;
        int iden=0;
        bool menjanje = false;
        int indeksmenjanja=0,idmenjanja=0;
        public FormFilm()
        {
            filmovi = new List<Film>();
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int broj = 0;
            int broj2 = 0;
            if(txtNaziv.Text.Trim()=="" || !int.TryParse(txtTrajanje.Text,out broj) || cbZanr.SelectedIndex<0)
            {
                MessageBox.Show("Nisu uneti podaci");
            }
            else
            {
                Film fi = new Film(iden, broj, int.Parse(nupUzrast.Text), txtNaziv.Text, cbZanr.Text);
                if (File.Exists(putanjaF))
                {
                    if (menjanje)
                    {
                        menjanje = false;
                        fi.Id = idmenjanja;
                        filmovi[indeksmenjanja] = fi;
                    }
                    else
                    {
                        fi.Id = iden;
                        filmovi.Add(fi);
                        iden++;
                    }
                    FileStream fs = new FileStream(putanjaF, FileMode.Open, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, filmovi);
                    fs.Dispose();
                }
                else
                {
                    filmovi.Add(fi);
                    FileStream fsa = new FileStream(putanjaF, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsa, filmovi);
                    fsa.Dispose();
                    iden++;
                }
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
                nupUzrast.Value = 0;
                txtNaziv.Clear();
                txtTrajanje.Clear();
                listBox1.Items.Clear();
                foreach (Film f in filmovi)
                    listBox1.Items.Add(f.Id + " " + f.Naziv + " " + f.Zanr + " " + f.Trajanje + " min, Najmanji uzrast " + f.Granicagodina + " godina");
            }
        }

        private void FormFilm_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaF))
            {
                FileStream fs = new FileStream(putanjaF, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                filmovi = bf.Deserialize(fs) as List<Film>;
                fs.Dispose();
                iden = filmovi[filmovi.Count()-1].Id + 1;
                foreach (Film f in filmovi)
                    listBox1.Items.Add(f.Id + " " + f.Naziv + " " + f.Zanr + " " + f.Trajanje + " min, Najmanji uzrast " + f.Granicagodina + " godina");
            }
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaF))
            {
                indeksmenjanja = listBox1.SelectedIndex;
                filmovi.RemoveAt(indeksmenjanja);
                listBox1.Items.RemoveAt(indeksmenjanja);
                FileStream fs = new FileStream(putanjaF, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, filmovi);
                fs.Dispose();
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnBrisi.Enabled = true;
                btnIzmeni.Enabled = true;
            }
        }

        private void cbZanr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void nupUzrast_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            menjanje = true;
            indeksmenjanja = listBox1.SelectedIndex;
            idmenjanja = filmovi[indeksmenjanja].Id;
            txtNaziv.Text = filmovi[indeksmenjanja].Naziv;
            cbZanr.Text = filmovi[indeksmenjanja].Zanr;
            txtTrajanje.Text = filmovi[indeksmenjanja].Trajanje.ToString();
            nupUzrast.Value = filmovi[indeksmenjanja].Granicagodina;
        }
    }
}

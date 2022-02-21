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
    public partial class FormAdmini : Form
    {
        public string putanjaA = "Admin.txt";
        List<Administrator> admini;
        int iden = 0;
        bool menjanje = false;
        int indeksmenjanja = 0, idmenjanja = 0;
        public FormAdmini()
        {
            admini = new List<Administrator>();
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int broj = 0;
            int broj2 = 0;
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtIme.Text.Trim() == "" || txtPrezime.Text.Trim() == "" || !int.TryParse(txtTelefon.Text, out broj))
            {
                MessageBox.Show("Nisu uneti podaci");
            }
            else
            {
                Administrator ad = new Administrator(txtUsername.Text, txtPassword.Text, iden, txtIme.Text, txtPrezime.Text,broj);
                if (File.Exists(putanjaA))
                {
                    if (menjanje)
                    {
                        menjanje = false;
                        ad.Id = idmenjanja;
                        admini[indeksmenjanja] = ad;
                    }
                    else
                    {
                        ad.Id = iden;
                        admini.Add(ad);
                        iden++;
                    }
                    FileStream fs = new FileStream(putanjaA, FileMode.Open, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, admini);
                    fs.Dispose();
                }
                else
                {
                    admini.Add(ad);
                    FileStream fsa = new FileStream(putanjaA, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsa, admini);
                    fsa.Dispose();
                    iden++;
                }
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
                txtUsername.Clear();
                txtIme.Clear();
                txtPassword.Clear();
                listBox1.Items.Clear();
                foreach (Administrator f in admini)
                    listBox1.Items.Add(ad.ToString());
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaA))
            {
                indeksmenjanja = listBox1.SelectedIndex;
                admini.RemoveAt(indeksmenjanja);
                listBox1.Items.RemoveAt(indeksmenjanja);
                FileStream fs = new FileStream(putanjaA, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, admini);
                fs.Dispose();
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            menjanje = true;
            indeksmenjanja = listBox1.SelectedIndex;
            idmenjanja = admini[indeksmenjanja].Id;
            txtUsername.Text = admini[indeksmenjanja].Username;
            txtPassword.Text = admini[indeksmenjanja].Password;
            txtIme.Text = admini[indeksmenjanja].Ime;
            txtPrezime.Text = admini[indeksmenjanja].Prezime;
            txtTelefon.Text = admini[indeksmenjanja].Telefon.ToString();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnBrisi.Enabled = true;
                btnIzmeni.Enabled = true;
            }
        }

        private void FormAdmini_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaA))
            {
                FileStream fs = new FileStream(putanjaA, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                admini = bf.Deserialize(fs) as List<Administrator>;
                fs.Dispose();
                iden = admini[admini.Count() - 1].Id + 1;
                foreach (Administrator a in admini)
                    listBox1.Items.Add(a.ToString());
            }
        }
    }
}

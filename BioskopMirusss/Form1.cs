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
    public partial class Form1 : Form
    {
        List<Administrator> admin;
        List<Kupac> kupci;
        string putanjaKupac = "Kupci.txt";
        string putanjaAdmin = "Admin.txt";
        int iden = 0;
        Form2 f2;
        Form2Admin f2admin;
        public Form1()
        {
            kupci = new List<Kupac>();
            admin = new List<Administrator>();
            InitializeComponent();
        }

        private void btnRegistruj_Click(object sender, EventArgs e)
        {
            int broj=0;
            string pol = "Zenski";
            if (rbM.Checked)
                pol = "Muski";
            if (txtUsernameR.Text.Trim() == "" || txtPasswordR.Text.Trim() == "" || txtIme.Text.Trim() == "" || txtPrezime.Text.Trim() == "" || !int.TryParse(txtTelefon.Text,out broj))
            {
                if (txtUsernameR.Text.Trim() == "")
                    txtUsernameR.BackColor = Color.IndianRed;
                else
                    txtUsernameR.BackColor = SystemColors.Window;
                if (txtPasswordR.Text.Trim() == "")
                    txtPasswordR.BackColor = Color.IndianRed;
                else
                    txtPasswordR.BackColor = SystemColors.Window;
                if (txtIme.Text.Trim() == "")
                    txtIme.BackColor = Color.IndianRed;
                else
                    txtIme.BackColor = SystemColors.Window;
                if (txtPrezime.Text.Trim() == "")
                    txtPrezime.BackColor = Color.IndianRed;
                else
                    txtPrezime.BackColor = SystemColors.Window;
                if (!int.TryParse(txtTelefon.Text, out broj))
                    txtTelefon.BackColor = Color.IndianRed;
                else
                    txtTelefon.BackColor = SystemColors.Window;
                MessageBox.Show("Podaci su lose uneti!");
            }
            else
            {
                Kupac k = new Kupac(txtUsernameR.Text, txtPasswordR.Text, 0, txtIme.Text, txtPrezime.Text, pol, broj, dtpRodjenje.Value);
                txtUsernameR.BackColor = SystemColors.Window;
                txtPasswordR.BackColor = SystemColors.Window;
                txtIme.BackColor = SystemColors.Window;
                txtPrezime.BackColor = SystemColors.Window;
                txtTelefon.BackColor = SystemColors.Window;
                if (File.Exists(putanjaKupac))
                {
                    k.Id = iden;
                    kupci.Add(k);
                    FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, kupci);
                    fs.Dispose();
                    iden++;
                }
                else
                {
                    kupci.Add(k);
                    FileStream fsa = new FileStream(putanjaKupac, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsa, kupci);
                    fsa.Dispose();
                    iden++;
                }
                txtUsernameR.Clear();
                txtPasswordR.Clear();
                txtIme.Clear();
                txtPrezime.Clear();
                txtTelefon.Clear();
                dtpRodjenje.Value = DateTime.Today;
                MessageBox.Show("Uspesno ste napravili nalog!");
                f2 = new Form2(k.Id);
                f2.ShowDialog();
            }
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            List<Kupac> pom = new List<Kupac>();
            int ban = 0;
            int bin = 0;
            if (txtUsernameP.Text.Trim() != "" && txtPasswordP.Text.Trim() != "")
            {
                txtUsernameP.BackColor = SystemColors.Window;
                txtPasswordP.BackColor = SystemColors.Window;
                Korisnik k = new Korisnik(txtUsernameP.Text, txtPasswordP.Text, 0);
                foreach (Administrator ad in admin)
                    if (ad.uporediKorisnika(k.Username, k.Password))
                        ban++;
                if (ban > 0)
                {
                    f2admin = new Form2Admin();
                    f2admin.ShowDialog();
                }
                else
                {
                    foreach (Kupac kup in kupci)
                        if (kup.uporediKorisnika(k.Username, k.Password))
                        {
                            pom.Add(kup);
                            bin++;
                        }
                    if (bin == 1)
                    {
                        if (pom[0].Ban)
                            MessageBox.Show("Ovaj korisnik je onemogucen!");
                        else
                        {
                            f2 = new Form2(pom[0].Id);
                            f2.ShowDialog();
                        }
                    }
                    else if (bin == 0)
                        MessageBox.Show("Ne postoji korisnik");
                    else
                    {
                        Form2Odabir f2o = new Form2Odabir(k.Username, k.Password);
                        f2o.ShowDialog();
                    }
                }
            }
            else if (txtPasswordP.Text.Trim() == "" || txtUsernameP.Text.Trim() == "")
            {
                if (txtUsernameP.Text.Trim() == "")
                    txtUsernameP.BackColor = Color.IndianRed;
                else
                    txtUsernameP.BackColor = SystemColors.Window;
                if (txtPasswordP.Text.Trim() == "")
                    txtPasswordP.BackColor = Color.IndianRed;
                else
                    txtPasswordP.BackColor = SystemColors.Window;
                MessageBox.Show("Podaci nisu uneti!");
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dtpRodjenje.MaxDate= DateTime.Today;
            dtpRodjenje.Value = DateTime.Today;
            if (!File.Exists(putanjaAdmin))
            {
                FileStream fs = new FileStream(putanjaAdmin, FileMode.Create, FileAccess.Write);
                Administrator a = new Administrator("mirus", "password", 0, "Miroljub", "Djokic", 0691155939);
                admin.Add(a);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, admin);
                fs.Dispose();
            }
            else
            {
                FileStream fs = new FileStream(putanjaAdmin, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                admin = bf.Deserialize(fs) as List<Administrator>;
                fs.Dispose();
            }
            Osvezi();
        }

        public void Osvezi()
        {
            if (File.Exists(putanjaKupac))
            {
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Dispose();
                iden = kupci[kupci.Count() - 1].Id + 1;
            }
        }


        private void btnIzadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            Osvezi();
            txtUsernameP.Clear();
            txtPasswordP.Clear();
        }
    }
}

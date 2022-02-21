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
    public partial class Form2Odabir : Form
    {
        string putanjaKupac= "Kupci.txt";
        Korisnik kor;
        List<Kupac> kupci;
        List<Kupac> pom;
        public Form2Odabir(string name,string pass)
        {
            InitializeComponent();
            kor = new Korisnik(name, pass, 0);
            kupci = new List<Kupac>();
            pom = new List<Kupac>();
        }

        private void Form2Odabir_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaKupac))
            {
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Dispose();
            }
            foreach (Kupac k in kupci)
                if (k.uporediKorisnika(kor.Username, kor.Password))
                {
                    listBox1.Items.Add(k.sveInformacije());
                    pom.Add(k);
                }
                    
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            try
            {
                int x = listBox1.SelectedIndex;
                if (pom[x].Ban)
                {
                    MessageBox.Show("Ovaj korisniku je onemogucen servis.");
                    this.Close();
                }
                else
                {
                    Form2 f2 = new Form2(pom[x].Id);
                    f2.ShowDialog();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Niste odabrali korisnika");
                throw;
            }
        }
    }
}

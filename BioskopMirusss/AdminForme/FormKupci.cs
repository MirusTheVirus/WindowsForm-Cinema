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
    public partial class FormKupci : Form
    {
        List<Kupac> kupci;
        string putanjaKupac = "Kupci.txt";
        int indeks;
        public FormKupci()
        {
            kupci = new List<Kupac>();
            InitializeComponent();
        }

        private void FormKupci_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaKupac))
            {
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                kupci = bf.Deserialize(fs) as List<Kupac>;
                fs.Dispose();
                foreach (Kupac k in kupci)
                    listBox1.Items.Add(k.Id+" "+k.Username + " " + k.Password + "; Licne informacije: " + k.sveInformacije());
            }
            else
            {
                MessageBox.Show("Ne postoje kupci!");
                this.Close();
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (kupci[indeks].Ban)
                kupci[indeks].Ban = false;
            else
                kupci[indeks].Ban = true;
            btnBrisi.Enabled = false;
            btnBan.Enabled = false;
            FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, kupci);
            fs.Dispose();
            listBox1.Items.Clear();
            foreach (Kupac k in kupci)
                listBox1.Items.Add(k.sveInformacije());
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaKupac))
            {
                kupci.RemoveAt(indeks);
                listBox1.Items.RemoveAt(indeks);
                FileStream fs = new FileStream(putanjaKupac, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, kupci);
                fs.Dispose();
                btnBrisi.Enabled = false;
                btnBan.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                indeks = listBox1.SelectedIndex;
                btnBrisi.Enabled = true;
                btnBan.Enabled = true;
                if (kupci[indeks].Ban)
                    btnBan.Text = "Unban";
                else
                    btnBan.Text = "Ban";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class FormSale : Form
    {
        public string putanjaS = "Sale.txt";
        List<Sala> sale;
        int iden = 0;
        bool menjanje = false;
        int indeksmenjanja = 0, idmenjanja = 0;
        public FormSale()
        {
            sale = new List<Sala>();
            InitializeComponent();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            menjanje = true;
            indeksmenjanja = listBox1.SelectedIndex;
            idmenjanja = sale[indeksmenjanja].Id;
            txtBrsed.Text = sale[indeksmenjanja].Brsedista.ToString();
            txtBrsale.Text = sale[indeksmenjanja].Brsale.ToString();
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (File.Exists(putanjaS))
            {
                indeksmenjanja = listBox1.SelectedIndex;
                sale.RemoveAt(indeksmenjanja);
                listBox1.Items.RemoveAt(indeksmenjanja);
                FileStream fs = new FileStream(putanjaS, FileMode.Open, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, sale);
                fs.Dispose();
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
            }
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            if (File.Exists(putanjaS))
            {
                FileStream fs = new FileStream(putanjaS, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                sale = bf.Deserialize(fs) as List<Sala>;
                fs.Dispose();
                iden = sale[sale.Count() - 1].Id + 1;
                foreach (Sala s in sale)
                    listBox1.Items.Add(s.Id + " Broj sale: " + s.Brsale + " Broj sedista: " + s.Brsedista);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                btnIzmeni.Enabled = true;
                btnBrisi.Enabled = true;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int broj = 0;
            int broj2 = 0;
            if (!int.TryParse(txtBrsale.Text, out broj) || !int.TryParse(txtBrsed.Text, out broj2))
            {
                MessageBox.Show("Nisu uneti podaci");
            }
            else
            {
                Sala sa = new Sala(iden, broj, broj2);
                if (File.Exists(putanjaS))
                {
                    if (menjanje)
                    {
                        menjanje = false;
                        sa.Id = idmenjanja;
                        sale[indeksmenjanja] = sa;
                    }
                    else
                    {
                        sa.Id = iden;
                        sale.Add(sa);
                        iden++;
                    }
                    FileStream fs = new FileStream(putanjaS, FileMode.Open, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, sale);
                    fs.Dispose();
                }
                else
                {
                    sale.Add(sa);
                    FileStream fsa = new FileStream(putanjaS, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsa, sale);
                    fsa.Dispose();
                    iden++;
                }
                btnIzmeni.Enabled = false;
                btnBrisi.Enabled = false;
                txtBrsale.Clear();
                txtBrsed.Clear();
                listBox1.Items.Clear();
                foreach (Sala s in sale)
                    listBox1.Items.Add(s.Id + " Broj sale: " + s.Brsale + " Broj sedista: " + s.Brsedista);
            }
        }
    }
}

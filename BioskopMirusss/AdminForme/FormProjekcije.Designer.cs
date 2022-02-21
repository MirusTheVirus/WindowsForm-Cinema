namespace BioskopMirusss.AdminForme
{
    partial class FormProjekcije
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCenaKarte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNazad = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnBrisi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFilmovi = new System.Windows.Forms.ComboBox();
            this.cbSale = new System.Windows.Forms.ComboBox();
            this.nupSati = new System.Windows.Forms.NumericUpDown();
            this.nupMinuti = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinuti)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(716, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "Datum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(716, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Cena karte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(716, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "Sala";
            // 
            // txtCenaKarte
            // 
            this.txtCenaKarte.Location = new System.Drawing.Point(856, 109);
            this.txtCenaKarte.Name = "txtCenaKarte";
            this.txtCenaKarte.Size = new System.Drawing.Size(161, 20);
            this.txtCenaKarte.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(716, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Film";
            // 
            // btnNazad
            // 
            this.btnNazad.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNazad.Location = new System.Drawing.Point(901, 401);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(116, 37);
            this.btnNazad.TabIndex = 17;
            this.btnNazad.Text = "Nazad";
            this.btnNazad.UseVisualStyleBackColor = true;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(901, 330);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(116, 37);
            this.btnDodaj.TabIndex = 16;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Enabled = false;
            this.btnIzmeni.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.Location = new System.Drawing.Point(134, 330);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(116, 37);
            this.btnIzmeni.TabIndex = 15;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnBrisi
            // 
            this.btnBrisi.Enabled = false;
            this.btnBrisi.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrisi.Location = new System.Drawing.Point(12, 330);
            this.btnBrisi.Name = "btnBrisi";
            this.btnBrisi.Size = new System.Drawing.Size(116, 37);
            this.btnBrisi.TabIndex = 14;
            this.btnBrisi.Text = "Brisi";
            this.btnBrisi.UseVisualStyleBackColor = true;
            this.btnBrisi.Click += new System.EventHandler(this.btnBrisi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(716, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 22);
            this.label6.TabIndex = 28;
            this.label6.Text = "Vreme";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(817, 153);
            this.dtpDatum.MinDate = new System.DateTime(2021, 4, 18, 0, 0, 0, 0);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 29;
            this.dtpDatum.Value = new System.DateTime(2021, 4, 18, 13, 2, 15, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(930, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = ":";
            // 
            // cbFilmovi
            // 
            this.cbFilmovi.FormattingEnabled = true;
            this.cbFilmovi.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbFilmovi.Location = new System.Drawing.Point(856, 19);
            this.cbFilmovi.Name = "cbFilmovi";
            this.cbFilmovi.Size = new System.Drawing.Size(161, 21);
            this.cbFilmovi.TabIndex = 31;
            this.cbFilmovi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFilmovi_KeyPress);
            // 
            // cbSale
            // 
            this.cbSale.FormattingEnabled = true;
            this.cbSale.Location = new System.Drawing.Point(856, 63);
            this.cbSale.Name = "cbSale";
            this.cbSale.Size = new System.Drawing.Size(161, 21);
            this.cbSale.TabIndex = 32;
            this.cbSale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSale_KeyPress);
            // 
            // nupSati
            // 
            this.nupSati.Location = new System.Drawing.Point(856, 204);
            this.nupSati.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nupSati.Name = "nupSati";
            this.nupSati.Size = new System.Drawing.Size(67, 20);
            this.nupSati.TabIndex = 33;
            this.nupSati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupSati_KeyPress);
            // 
            // nupMinuti
            // 
            this.nupMinuti.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupMinuti.Location = new System.Drawing.Point(950, 204);
            this.nupMinuti.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.nupMinuti.Name = "nupMinuti";
            this.nupMinuti.Size = new System.Drawing.Size(67, 20);
            this.nupMinuti.TabIndex = 34;
            this.nupMinuti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupSati_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(698, 303);
            this.listBox1.TabIndex = 35;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // FormProjekcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1029, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.nupMinuti);
            this.Controls.Add(this.nupSati);
            this.Controls.Add(this.cbSale);
            this.Controls.Add(this.cbFilmovi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCenaKarte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnBrisi);
            this.Name = "FormProjekcije";
            this.Text = "FormProjekcije";
            this.Load += new System.EventHandler(this.FormProjekcije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinuti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCenaKarte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNazad;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnBrisi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFilmovi;
        private System.Windows.Forms.ComboBox cbSale;
        private System.Windows.Forms.NumericUpDown nupSati;
        private System.Windows.Forms.NumericUpDown nupMinuti;
        private System.Windows.Forms.ListBox listBox1;
    }
}
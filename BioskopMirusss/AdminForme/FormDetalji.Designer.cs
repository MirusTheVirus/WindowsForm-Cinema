namespace BioskopMirusss.AdminForme
{
    partial class FormDetalji
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
            this.btnZatvori = new System.Windows.Forms.Button();
            this.lblKupac = new System.Windows.Forms.Label();
            this.lblProjekcija = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnZatvori
            // 
            this.btnZatvori.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZatvori.Location = new System.Drawing.Point(12, 276);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(324, 37);
            this.btnZatvori.TabIndex = 11;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // lblKupac
            // 
            this.lblKupac.AutoSize = true;
            this.lblKupac.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKupac.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKupac.Location = new System.Drawing.Point(12, 9);
            this.lblKupac.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblKupac.Name = "lblKupac";
            this.lblKupac.Size = new System.Drawing.Size(0, 22);
            this.lblKupac.TabIndex = 12;
            // 
            // lblProjekcija
            // 
            this.lblProjekcija.AutoSize = true;
            this.lblProjekcija.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjekcija.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProjekcija.Location = new System.Drawing.Point(12, 122);
            this.lblProjekcija.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblProjekcija.Name = "lblProjekcija";
            this.lblProjekcija.Size = new System.Drawing.Size(0, 22);
            this.lblProjekcija.TabIndex = 13;
            // 
            // FormDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 325);
            this.Controls.Add(this.lblProjekcija);
            this.Controls.Add(this.lblKupac);
            this.Controls.Add(this.btnZatvori);
            this.Name = "FormDetalji";
            this.Text = "FormDetalji";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDetalji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Label lblKupac;
        private System.Windows.Forms.Label lblProjekcija;
    }
}
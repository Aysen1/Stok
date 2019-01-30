namespace Stok_Programı
{
    partial class Form2
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
            this.lbl_serverip = new System.Windows.Forms.Label();
            this.txt_serverip = new System.Windows.Forms.TextBox();
            this.txt_veritabani = new System.Windows.Forms.TextBox();
            this.lbl_veritabani = new System.Windows.Forms.Label();
            this.txt_kullaniciadi = new System.Windows.Forms.TextBox();
            this.lbl_kullaniciadi = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ssimge = new DevExpress.XtraEditors.SimpleButton();
            this.scikis = new DevExpress.XtraEditors.SimpleButton();
            this.baglanti_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.baglanti_kontrol = new DevExpress.XtraEditors.SimpleButton();
            this.baglan = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_serverip
            // 
            this.lbl_serverip.AutoSize = true;
            this.lbl_serverip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_serverip.Location = new System.Drawing.Point(69, 83);
            this.lbl_serverip.Name = "lbl_serverip";
            this.lbl_serverip.Size = new System.Drawing.Size(64, 13);
            this.lbl_serverip.TabIndex = 0;
            this.lbl_serverip.Text = "Server IP:";
            // 
            // txt_serverip
            // 
            this.txt_serverip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_serverip.Location = new System.Drawing.Point(187, 80);
            this.txt_serverip.Name = "txt_serverip";
            this.txt_serverip.Size = new System.Drawing.Size(100, 20);
            this.txt_serverip.TabIndex = 1;
            // 
            // txt_veritabani
            // 
            this.txt_veritabani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_veritabani.Location = new System.Drawing.Point(187, 122);
            this.txt_veritabani.Name = "txt_veritabani";
            this.txt_veritabani.Size = new System.Drawing.Size(100, 20);
            this.txt_veritabani.TabIndex = 3;
            // 
            // lbl_veritabani
            // 
            this.lbl_veritabani.AutoSize = true;
            this.lbl_veritabani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_veritabani.Location = new System.Drawing.Point(69, 125);
            this.lbl_veritabani.Name = "lbl_veritabani";
            this.lbl_veritabani.Size = new System.Drawing.Size(90, 13);
            this.lbl_veritabani.TabIndex = 2;
            this.lbl_veritabani.Text = "Veritabanı Adı:";
            // 
            // txt_kullaniciadi
            // 
            this.txt_kullaniciadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_kullaniciadi.Location = new System.Drawing.Point(187, 168);
            this.txt_kullaniciadi.Name = "txt_kullaniciadi";
            this.txt_kullaniciadi.Size = new System.Drawing.Size(100, 20);
            this.txt_kullaniciadi.TabIndex = 5;
            // 
            // lbl_kullaniciadi
            // 
            this.lbl_kullaniciadi.AutoSize = true;
            this.lbl_kullaniciadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullaniciadi.Location = new System.Drawing.Point(69, 171);
            this.lbl_kullaniciadi.Name = "lbl_kullaniciadi";
            this.lbl_kullaniciadi.Size = new System.Drawing.Size(81, 13);
            this.lbl_kullaniciadi.TabIndex = 4;
            this.lbl_kullaniciadi.Text = "Kullanıcı Adı:";
            // 
            // txt_sifre
            // 
            this.txt_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_sifre.Location = new System.Drawing.Point(187, 212);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(100, 21);
            this.txt_sifre.TabIndex = 7;
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sifre.Location = new System.Drawing.Point(69, 215);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(37, 13);
            this.lbl_sifre.TabIndex = 6;
            this.lbl_sifre.Text = "Şifre:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ssimge, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scikis, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(288, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 43);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // ssimge
            // 
            this.ssimge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ssimge.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ssimge.ImageOptions.Image = global::Stok_Programı.Properties.Resources.msmge;
            this.ssimge.Location = new System.Drawing.Point(3, 4);
            this.ssimge.Name = "ssimge";
            this.ssimge.Size = new System.Drawing.Size(34, 34);
            this.ssimge.TabIndex = 34;
            this.ssimge.Click += new System.EventHandler(this.ssimge_Click);
            // 
            // scikis
            // 
            this.scikis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scikis.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mcikis;
            this.scikis.Location = new System.Drawing.Point(43, 4);
            this.scikis.Name = "scikis";
            this.scikis.Size = new System.Drawing.Size(34, 34);
            this.scikis.TabIndex = 33;
            this.scikis.Click += new System.EventHandler(this.scikis_Click);
            // 
            // baglanti_kaydet
            // 
            this.baglanti_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.baglanti_kaydet.Appearance.Options.UseFont = true;
            this.baglanti_kaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.baglanti_kaydet.ImageOptions.Image = global::Stok_Programı.Properties.Resources.kaydet;
            this.baglanti_kaydet.Location = new System.Drawing.Point(127, 297);
            this.baglanti_kaydet.Name = "baglanti_kaydet";
            this.baglanti_kaydet.Size = new System.Drawing.Size(141, 49);
            this.baglanti_kaydet.TabIndex = 14;
            this.baglanti_kaydet.Text = "KAYDET";
            this.baglanti_kaydet.Click += new System.EventHandler(this.baglanti_kaydet_Click);
            // 
            // baglanti_kontrol
            // 
            this.baglanti_kontrol.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.baglanti_kontrol.Appearance.Options.UseFont = true;
            this.baglanti_kontrol.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.baglanti_kontrol.ImageOptions.Image = global::Stok_Programı.Properties.Resources.kontrol;
            this.baglanti_kontrol.Location = new System.Drawing.Point(208, 242);
            this.baglanti_kontrol.Name = "baglanti_kontrol";
            this.baglanti_kontrol.Size = new System.Drawing.Size(161, 49);
            this.baglanti_kontrol.TabIndex = 13;
            this.baglanti_kontrol.Text = "BAĞLANTIYI SINA";
            this.baglanti_kontrol.Click += new System.EventHandler(this.baglanti_kontrol_Click);
            // 
            // baglan
            // 
            this.baglan.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.baglan.Appearance.Options.UseFont = true;
            this.baglan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.baglan.ImageOptions.Image = global::Stok_Programı.Properties.Resources.baglan;
            this.baglan.Location = new System.Drawing.Point(32, 242);
            this.baglan.Name = "baglan";
            this.baglan.Size = new System.Drawing.Size(141, 49);
            this.baglan.TabIndex = 12;
            this.baglan.Text = "BAĞLAN";
            this.baglan.Click += new System.EventHandler(this.baglan_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 353);
            this.ControlBox = false;
            this.Controls.Add(this.baglanti_kaydet);
            this.Controls.Add(this.baglanti_kontrol);
            this.Controls.Add(this.baglan);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.lbl_sifre);
            this.Controls.Add(this.txt_kullaniciadi);
            this.Controls.Add(this.lbl_kullaniciadi);
            this.Controls.Add(this.txt_veritabani);
            this.Controls.Add(this.lbl_veritabani);
            this.Controls.Add(this.txt_serverip);
            this.Controls.Add(this.lbl_serverip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Veritabanı Bağlantı Ayarı";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_serverip;
        private System.Windows.Forms.TextBox txt_serverip;
        private System.Windows.Forms.TextBox txt_veritabani;
        private System.Windows.Forms.Label lbl_veritabani;
        private System.Windows.Forms.TextBox txt_kullaniciadi;
        private System.Windows.Forms.Label lbl_kullaniciadi;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton scikis;
        private DevExpress.XtraEditors.SimpleButton ssimge;
        private DevExpress.XtraEditors.SimpleButton baglan;
        private DevExpress.XtraEditors.SimpleButton baglanti_kontrol;
        private DevExpress.XtraEditors.SimpleButton baglanti_kaydet;
    }
}
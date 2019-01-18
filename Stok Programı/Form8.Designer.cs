namespace Stok_Programı
{
    partial class Form8
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.lbl_yazici = new System.Windows.Forms.Label();
            this.cmbx_yazici = new System.Windows.Forms.ComboBox();
            this.btn_yazici_ekle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cikiss = new System.Windows.Forms.Button();
            this.btn_tamekran = new System.Windows.Forms.Button();
            this.btn_simge = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sbtn_giris = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_giris_duzenle = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_satis = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_satis_düzenle = new DevExpress.XtraEditors.SimpleButton();
            this.baslangic_tarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbx_kodlar = new System.Windows.Forms.ComboBox();
            this.bitis_tarihi = new System.Windows.Forms.DateTimePicker();
            this.lbl_baslangic = new System.Windows.Forms.Label();
            this.lbl_bitis = new System.Windows.Forms.Label();
            this.lbl_kod = new System.Windows.Forms.Label();
            this.lbl_sayı = new System.Windows.Forms.Label();
            this.txt_adet = new System.Windows.Forms.TextBox();
            this.ssatis = new DevExpress.XtraEditors.SimpleButton();
            this.S2 = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.S3 = new DevExpress.XtraEditors.SimpleButton();
            this.S4 = new DevExpress.XtraEditors.SimpleButton();
            this.S5 = new DevExpress.XtraEditors.SimpleButton();
            this.S6 = new DevExpress.XtraEditors.SimpleButton();
            this.S7 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_yazici
            // 
            this.lbl_yazici.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_yazici.AutoSize = true;
            this.lbl_yazici.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_yazici.Location = new System.Drawing.Point(169, 402);
            this.lbl_yazici.Name = "lbl_yazici";
            this.lbl_yazici.Size = new System.Drawing.Size(59, 13);
            this.lbl_yazici.TabIndex = 0;
            this.lbl_yazici.Text = "Yazıcılar:";
            // 
            // cmbx_yazici
            // 
            this.cmbx_yazici.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbx_yazici.FormattingEnabled = true;
            this.cmbx_yazici.Location = new System.Drawing.Point(284, 399);
            this.cmbx_yazici.Name = "cmbx_yazici";
            this.cmbx_yazici.Size = new System.Drawing.Size(173, 21);
            this.cmbx_yazici.TabIndex = 1;
            // 
            // btn_yazici_ekle
            // 
            this.btn_yazici_ekle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_yazici_ekle.FlatAppearance.BorderSize = 0;
            this.btn_yazici_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yazici_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yazici_ekle.Location = new System.Drawing.Point(468, 399);
            this.btn_yazici_ekle.Name = "btn_yazici_ekle";
            this.btn_yazici_ekle.Size = new System.Drawing.Size(92, 23);
            this.btn_yazici_ekle.TabIndex = 2;
            this.btn_yazici_ekle.Text = "Yazıcı Ekle";
            this.btn_yazici_ekle.UseVisualStyleBackColor = true;
            this.btn_yazici_ekle.Click += new System.EventHandler(this.btn_yazici_ekle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Controls.Add(this.btn_cikiss, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_tamekran, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_simge, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(496, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 43);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btn_cikiss
            // 
            this.btn_cikiss.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cikiss.FlatAppearance.BorderSize = 0;
            this.btn_cikiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cikiss.Location = new System.Drawing.Point(103, 6);
            this.btn_cikiss.Name = "btn_cikiss";
            this.btn_cikiss.Size = new System.Drawing.Size(30, 30);
            this.btn_cikiss.TabIndex = 6;
            this.btn_cikiss.UseVisualStyleBackColor = true;
            this.btn_cikiss.Click += new System.EventHandler(this.btn_cikiss_Click);
            // 
            // btn_tamekran
            // 
            this.btn_tamekran.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_tamekran.FlatAppearance.BorderSize = 0;
            this.btn_tamekran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tamekran.Location = new System.Drawing.Point(54, 6);
            this.btn_tamekran.Name = "btn_tamekran";
            this.btn_tamekran.Size = new System.Drawing.Size(30, 30);
            this.btn_tamekran.TabIndex = 5;
            this.btn_tamekran.UseVisualStyleBackColor = true;
            this.btn_tamekran.Click += new System.EventHandler(this.btn_tamekran_Click);
            // 
            // btn_simge
            // 
            this.btn_simge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_simge.FlatAppearance.BorderSize = 0;
            this.btn_simge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_simge.Location = new System.Drawing.Point(8, 6);
            this.btn_simge.Name = "btn_simge";
            this.btn_simge.Size = new System.Drawing.Size(30, 30);
            this.btn_simge.TabIndex = 4;
            this.btn_simge.UseVisualStyleBackColor = true;
            this.btn_simge.Click += new System.EventHandler(this.btn_simge_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.raporToolStripMenuItem,
            this.yardımToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            this.anasayfaToolStripMenuItem.Click += new System.EventHandler(this.anasayfaToolStripMenuItem_Click);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.raporToolStripMenuItem.Text = "Rapor";
            this.raporToolStripMenuItem.Click += new System.EventHandler(this.raporToolStripMenuItem_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            this.yardımToolStripMenuItem.Click += new System.EventHandler(this.yardımToolStripMenuItem_Click);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.cikisToolStripMenuItem.Text = "Çıkış";
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.cikisToolStripMenuItem_Click);
            // 
            // sbtn_giris
            // 
            this.sbtn_giris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbtn_giris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtn_giris.ImageOptions.Image")));
            this.sbtn_giris.Location = new System.Drawing.Point(268, 150);
            this.sbtn_giris.Name = "sbtn_giris";
            this.sbtn_giris.Size = new System.Drawing.Size(100, 55);
            this.sbtn_giris.TabIndex = 6;
            this.sbtn_giris.Text = "Giriş Fişi";
            this.sbtn_giris.Click += new System.EventHandler(this.sbtn_giris_Click);
            // 
            // sbtn_giris_duzenle
            // 
            this.sbtn_giris_duzenle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbtn_giris_duzenle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtn_giris_duzenle.ImageOptions.Image")));
            this.sbtn_giris_duzenle.Location = new System.Drawing.Point(403, 150);
            this.sbtn_giris_duzenle.Name = "sbtn_giris_duzenle";
            this.sbtn_giris_duzenle.Size = new System.Drawing.Size(131, 55);
            this.sbtn_giris_duzenle.TabIndex = 7;
            this.sbtn_giris_duzenle.Text = "Giriş Fişi Düzenle";
            this.sbtn_giris_duzenle.Click += new System.EventHandler(this.sbtn_giris_duzenle_Click);
            // 
            // sbtn_satis
            // 
            this.sbtn_satis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbtn_satis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtn_satis.ImageOptions.Image")));
            this.sbtn_satis.Location = new System.Drawing.Point(268, 227);
            this.sbtn_satis.Name = "sbtn_satis";
            this.sbtn_satis.Size = new System.Drawing.Size(100, 55);
            this.sbtn_satis.TabIndex = 8;
            this.sbtn_satis.Text = "Satış Fişi";
            this.sbtn_satis.Click += new System.EventHandler(this.sbtn_satis_Click);
            // 
            // sbtn_satis_düzenle
            // 
            this.sbtn_satis_düzenle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbtn_satis_düzenle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtn_satis_düzenle.ImageOptions.Image")));
            this.sbtn_satis_düzenle.Location = new System.Drawing.Point(403, 227);
            this.sbtn_satis_düzenle.Name = "sbtn_satis_düzenle";
            this.sbtn_satis_düzenle.Size = new System.Drawing.Size(131, 55);
            this.sbtn_satis_düzenle.TabIndex = 9;
            this.sbtn_satis_düzenle.Text = "Satış Fişi Düzenle";
            this.sbtn_satis_düzenle.Click += new System.EventHandler(this.sbtn_satis_düzenle_Click);
            // 
            // baslangic_tarihi
            // 
            this.baslangic_tarihi.CalendarForeColor = System.Drawing.Color.Maroon;
            this.baslangic_tarihi.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.baslangic_tarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslangic_tarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.baslangic_tarihi.Location = new System.Drawing.Point(159, 79);
            this.baslangic_tarihi.Name = "baslangic_tarihi";
            this.baslangic_tarihi.Size = new System.Drawing.Size(161, 20);
            this.baslangic_tarihi.TabIndex = 10;
            this.baslangic_tarihi.Value = new System.DateTime(2019, 1, 16, 0, 0, 0, 0);
            // 
            // cmbx_kodlar
            // 
            this.cmbx_kodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbx_kodlar.FormattingEnabled = true;
            this.cmbx_kodlar.Location = new System.Drawing.Point(159, 168);
            this.cmbx_kodlar.Name = "cmbx_kodlar";
            this.cmbx_kodlar.Size = new System.Drawing.Size(161, 21);
            this.cmbx_kodlar.TabIndex = 11;
            // 
            // bitis_tarihi
            // 
            this.bitis_tarihi.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bitis_tarihi.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.bitis_tarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bitis_tarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bitis_tarihi.Location = new System.Drawing.Point(159, 121);
            this.bitis_tarihi.Name = "bitis_tarihi";
            this.bitis_tarihi.Size = new System.Drawing.Size(161, 20);
            this.bitis_tarihi.TabIndex = 12;
            this.bitis_tarihi.Value = new System.DateTime(2019, 1, 16, 0, 0, 0, 0);
            // 
            // lbl_baslangic
            // 
            this.lbl_baslangic.AutoSize = true;
            this.lbl_baslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_baslangic.Location = new System.Drawing.Point(20, 85);
            this.lbl_baslangic.Name = "lbl_baslangic";
            this.lbl_baslangic.Size = new System.Drawing.Size(102, 13);
            this.lbl_baslangic.TabIndex = 13;
            this.lbl_baslangic.Text = "Başlangıç Tarihi:";
            // 
            // lbl_bitis
            // 
            this.lbl_bitis.AutoSize = true;
            this.lbl_bitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_bitis.Location = new System.Drawing.Point(20, 127);
            this.lbl_bitis.Name = "lbl_bitis";
            this.lbl_bitis.Size = new System.Drawing.Size(71, 13);
            this.lbl_bitis.TabIndex = 14;
            this.lbl_bitis.Text = "Bitiş Tarihi:";
            // 
            // lbl_kod
            // 
            this.lbl_kod.AutoSize = true;
            this.lbl_kod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kod.Location = new System.Drawing.Point(20, 171);
            this.lbl_kod.Name = "lbl_kod";
            this.lbl_kod.Size = new System.Drawing.Size(96, 13);
            this.lbl_kod.TabIndex = 15;
            this.lbl_kod.Text = "Filtrelenen Kod:";
            // 
            // lbl_sayı
            // 
            this.lbl_sayı.AutoSize = true;
            this.lbl_sayı.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sayı.Location = new System.Drawing.Point(20, 219);
            this.lbl_sayı.Name = "lbl_sayı";
            this.lbl_sayı.Size = new System.Drawing.Size(37, 13);
            this.lbl_sayı.TabIndex = 16;
            this.lbl_sayı.Text = "Adet:";
            // 
            // txt_adet
            // 
            this.txt_adet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_adet.Location = new System.Drawing.Point(159, 212);
            this.txt_adet.Name = "txt_adet";
            this.txt_adet.Size = new System.Drawing.Size(161, 20);
            this.txt_adet.TabIndex = 17;
            // 
            // ssatis
            // 
            this.ssatis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ssatis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ssatis.ImageOptions.Image")));
            this.ssatis.Location = new System.Drawing.Point(12, 256);
            this.ssatis.Name = "ssatis";
            this.ssatis.Size = new System.Drawing.Size(100, 55);
            this.ssatis.TabIndex = 18;
            this.ssatis.Text = "1";
            this.ssatis.Click += new System.EventHandler(this.ssatis_Click);
            // 
            // S2
            // 
            this.S2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("S2.ImageOptions.Image")));
            this.S2.Location = new System.Drawing.Point(128, 256);
            this.S2.Name = "S2";
            this.S2.Size = new System.Drawing.Size(100, 55);
            this.S2.TabIndex = 19;
            this.S2.Text = "2";
            this.S2.Click += new System.EventHandler(this.S2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // S3
            // 
            this.S3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("S3.ImageOptions.Image")));
            this.S3.Location = new System.Drawing.Point(12, 332);
            this.S3.Name = "S3";
            this.S3.Size = new System.Drawing.Size(100, 55);
            this.S3.TabIndex = 20;
            this.S3.Text = "3";
            this.S3.Click += new System.EventHandler(this.S3_Click);
            // 
            // S4
            // 
            this.S4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("S4.ImageOptions.Image")));
            this.S4.Location = new System.Drawing.Point(128, 332);
            this.S4.Name = "S4";
            this.S4.Size = new System.Drawing.Size(100, 55);
            this.S4.TabIndex = 21;
            this.S4.Text = "4";
            this.S4.Click += new System.EventHandler(this.S4_Click);
            // 
            // S5
            // 
            this.S5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("S5.ImageOptions.Image")));
            this.S5.Location = new System.Drawing.Point(248, 332);
            this.S5.Name = "S5";
            this.S5.Size = new System.Drawing.Size(100, 55);
            this.S5.TabIndex = 22;
            this.S5.Text = "5";
            this.S5.Click += new System.EventHandler(this.S5_Click);
            // 
            // S6
            // 
            this.S6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("S6.ImageOptions.Image")));
            this.S6.Location = new System.Drawing.Point(357, 332);
            this.S6.Name = "S6";
            this.S6.Size = new System.Drawing.Size(100, 55);
            this.S6.TabIndex = 23;
            this.S6.Text = "6";
            this.S6.Click += new System.EventHandler(this.S6_Click);
            // 
            // S7
            // 
            this.S7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.S7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.S7.Location = new System.Drawing.Point(468, 332);
            this.S7.Name = "S7";
            this.S7.Size = new System.Drawing.Size(100, 55);
            this.S7.TabIndex = 24;
            this.S7.Text = "7";
            this.S7.Click += new System.EventHandler(this.S7_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 452);
            this.ControlBox = false;
            this.Controls.Add(this.S7);
            this.Controls.Add(this.S6);
            this.Controls.Add(this.S5);
            this.Controls.Add(this.S4);
            this.Controls.Add(this.S3);
            this.Controls.Add(this.S2);
            this.Controls.Add(this.ssatis);
            this.Controls.Add(this.txt_adet);
            this.Controls.Add(this.lbl_sayı);
            this.Controls.Add(this.lbl_kod);
            this.Controls.Add(this.lbl_bitis);
            this.Controls.Add(this.lbl_baslangic);
            this.Controls.Add(this.bitis_tarihi);
            this.Controls.Add(this.cmbx_kodlar);
            this.Controls.Add(this.baslangic_tarihi);
            this.Controls.Add(this.sbtn_satis_düzenle);
            this.Controls.Add(this.sbtn_satis);
            this.Controls.Add(this.sbtn_giris_duzenle);
            this.Controls.Add(this.sbtn_giris);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_yazici_ekle);
            this.Controls.Add(this.cmbx_yazici);
            this.Controls.Add(this.lbl_yazici);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form8";
            this.Text = "ARAÇLAR";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_yazici;
        private System.Windows.Forms.ComboBox cmbx_yazici;
        private System.Windows.Forms.Button btn_yazici_ekle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_cikiss;
        private System.Windows.Forms.Button btn_tamekran;
        private System.Windows.Forms.Button btn_simge;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton sbtn_giris;
        private DevExpress.XtraEditors.SimpleButton sbtn_giris_duzenle;
        private DevExpress.XtraEditors.SimpleButton sbtn_satis;
        private DevExpress.XtraEditors.SimpleButton sbtn_satis_düzenle;
        private System.Windows.Forms.DateTimePicker baslangic_tarihi;
        private System.Windows.Forms.ComboBox cmbx_kodlar;
        private System.Windows.Forms.DateTimePicker bitis_tarihi;
        private System.Windows.Forms.Label lbl_baslangic;
        private System.Windows.Forms.Label lbl_bitis;
        private System.Windows.Forms.Label lbl_kod;
        private System.Windows.Forms.Label lbl_sayı;
        private System.Windows.Forms.TextBox txt_adet;
        private DevExpress.XtraEditors.SimpleButton ssatis;
        private DevExpress.XtraEditors.SimpleButton S2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton S3;
        private DevExpress.XtraEditors.SimpleButton S4;
        private DevExpress.XtraEditors.SimpleButton S5;
        private DevExpress.XtraEditors.SimpleButton S6;
        private DevExpress.XtraEditors.SimpleButton S7;
    }
}
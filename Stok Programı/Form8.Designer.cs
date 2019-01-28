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
            this.stam = new DevExpress.XtraEditors.SimpleButton();
            this.scikis = new DevExpress.XtraEditors.SimpleButton();
            this.ssimge = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baslangic_tarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbx_kodlar = new System.Windows.Forms.ComboBox();
            this.bitis_tarihi = new System.Windows.Forms.DateTimePicker();
            this.lbl_baslangic = new System.Windows.Forms.Label();
            this.lbl_bitis = new System.Windows.Forms.Label();
            this.lbl_kod = new System.Windows.Forms.Label();
            this.lbl_firma = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbx_firmaadi = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.temizle = new System.Windows.Forms.Button();
            this.fatura_goruntule = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tarih = new System.Windows.Forms.ToolStripStatusLabel();
            this.saat = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_yazici
            // 
            this.lbl_yazici.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_yazici.AutoSize = true;
            this.lbl_yazici.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_yazici.Location = new System.Drawing.Point(101, 356);
            this.lbl_yazici.Name = "lbl_yazici";
            this.lbl_yazici.Size = new System.Drawing.Size(59, 13);
            this.lbl_yazici.TabIndex = 0;
            this.lbl_yazici.Text = "Yazıcılar:";
            // 
            // cmbx_yazici
            // 
            this.cmbx_yazici.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbx_yazici.FormattingEnabled = true;
            this.cmbx_yazici.Location = new System.Drawing.Point(214, 353);
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
            this.btn_yazici_ekle.Location = new System.Drawing.Point(398, 353);
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
            this.tableLayoutPanel1.Controls.Add(this.stam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.scikis, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ssimge, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(355, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 43);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // stam
            // 
            this.stam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stam.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.stam.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mtamekran;
            this.stam.Location = new System.Drawing.Point(52, 4);
            this.stam.Name = "stam";
            this.stam.Size = new System.Drawing.Size(34, 34);
            this.stam.TabIndex = 34;
            this.stam.Click += new System.EventHandler(this.stam_Click);
            // 
            // scikis
            // 
            this.scikis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scikis.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mcikis;
            this.scikis.Location = new System.Drawing.Point(101, 4);
            this.scikis.Name = "scikis";
            this.scikis.Size = new System.Drawing.Size(34, 34);
            this.scikis.TabIndex = 33;
            this.scikis.Click += new System.EventHandler(this.scikis_Click);
            // 
            // ssimge
            // 
            this.ssimge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ssimge.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ssimge.ImageOptions.Image = global::Stok_Programı.Properties.Resources.msmge;
            this.ssimge.Location = new System.Drawing.Point(6, 4);
            this.ssimge.Name = "ssimge";
            this.ssimge.Size = new System.Drawing.Size(34, 34);
            this.ssimge.TabIndex = 34;
            this.ssimge.Click += new System.EventHandler(this.ssimge_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
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
            // baslangic_tarihi
            // 
            this.baslangic_tarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.baslangic_tarihi.CalendarForeColor = System.Drawing.Color.Maroon;
            this.baslangic_tarihi.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.baslangic_tarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslangic_tarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.baslangic_tarihi.Location = new System.Drawing.Point(194, 12);
            this.baslangic_tarihi.Name = "baslangic_tarihi";
            this.baslangic_tarihi.Size = new System.Drawing.Size(185, 20);
            this.baslangic_tarihi.TabIndex = 10;
            this.baslangic_tarihi.Value = new System.DateTime(2019, 1, 16, 0, 0, 0, 0);
            // 
            // cmbx_kodlar
            // 
            this.cmbx_kodlar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbx_kodlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbx_kodlar.FormattingEnabled = true;
            this.cmbx_kodlar.Location = new System.Drawing.Point(194, 102);
            this.cmbx_kodlar.Name = "cmbx_kodlar";
            this.cmbx_kodlar.Size = new System.Drawing.Size(185, 21);
            this.cmbx_kodlar.TabIndex = 11;
            // 
            // bitis_tarihi
            // 
            this.bitis_tarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bitis_tarihi.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bitis_tarihi.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.bitis_tarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bitis_tarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bitis_tarihi.Location = new System.Drawing.Point(194, 57);
            this.bitis_tarihi.Name = "bitis_tarihi";
            this.bitis_tarihi.Size = new System.Drawing.Size(185, 20);
            this.bitis_tarihi.TabIndex = 12;
            this.bitis_tarihi.Value = new System.DateTime(2019, 1, 16, 0, 0, 0, 0);
            // 
            // lbl_baslangic
            // 
            this.lbl_baslangic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_baslangic.AutoSize = true;
            this.lbl_baslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_baslangic.Location = new System.Drawing.Point(3, 16);
            this.lbl_baslangic.Name = "lbl_baslangic";
            this.lbl_baslangic.Size = new System.Drawing.Size(102, 13);
            this.lbl_baslangic.TabIndex = 13;
            this.lbl_baslangic.Text = "Başlangıç Tarihi:";
            // 
            // lbl_bitis
            // 
            this.lbl_bitis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_bitis.AutoSize = true;
            this.lbl_bitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_bitis.Location = new System.Drawing.Point(3, 61);
            this.lbl_bitis.Name = "lbl_bitis";
            this.lbl_bitis.Size = new System.Drawing.Size(71, 13);
            this.lbl_bitis.TabIndex = 14;
            this.lbl_bitis.Text = "Bitiş Tarihi:";
            // 
            // lbl_kod
            // 
            this.lbl_kod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_kod.AutoSize = true;
            this.lbl_kod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kod.Location = new System.Drawing.Point(3, 106);
            this.lbl_kod.Name = "lbl_kod";
            this.lbl_kod.Size = new System.Drawing.Size(96, 13);
            this.lbl_kod.TabIndex = 15;
            this.lbl_kod.Text = "Filtrelenen Kod:";
            // 
            // lbl_firma
            // 
            this.lbl_firma.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_firma.AutoSize = true;
            this.lbl_firma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_firma.Location = new System.Drawing.Point(3, 151);
            this.lbl_firma.Name = "lbl_firma";
            this.lbl_firma.Size = new System.Drawing.Size(63, 13);
            this.lbl_firma.TabIndex = 16;
            this.lbl_firma.Text = "Firma Adı:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbx_firmaadi
            // 
            this.cmbx_firmaadi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbx_firmaadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbx_firmaadi.FormattingEnabled = true;
            this.cmbx_firmaadi.Location = new System.Drawing.Point(194, 147);
            this.cmbx_firmaadi.Name = "cmbx_firmaadi";
            this.cmbx_firmaadi.Size = new System.Drawing.Size(185, 21);
            this.cmbx_firmaadi.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.temizle, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl_baslangic, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbx_firmaadi, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.baslangic_tarihi, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_bitis, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.bitis_tarihi, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_kod, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbx_kodlar, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_firma, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.fatura_goruntule, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(382, 229);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // temizle
            // 
            this.temizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temizle.FlatAppearance.BorderSize = 0;
            this.temizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.temizle.Location = new System.Drawing.Point(58, 184);
            this.temizle.Name = "temizle";
            this.temizle.Size = new System.Drawing.Size(75, 40);
            this.temizle.TabIndex = 29;
            this.temizle.UseVisualStyleBackColor = true;
            this.temizle.Click += new System.EventHandler(this.temizle_Click);
            // 
            // fatura_goruntule
            // 
            this.fatura_goruntule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fatura_goruntule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fatura_goruntule.ImageOptions.Image")));
            this.fatura_goruntule.Location = new System.Drawing.Point(242, 184);
            this.fatura_goruntule.Name = "fatura_goruntule";
            this.fatura_goruntule.Size = new System.Drawing.Size(89, 40);
            this.fatura_goruntule.TabIndex = 30;
            this.fatura_goruntule.Text = "FATURA";
            this.fatura_goruntule.Click += new System.EventHandler(this.fatura_goruntule_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(24, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 254);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fatura Filtreleme Araçları";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarih,
            this.saat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tarih
            // 
            this.tarih.LinkColor = System.Drawing.Color.White;
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(33, 17);
            this.tarih.Text = "tarih";
            // 
            // saat
            // 
            this.saat.LinkColor = System.Drawing.Color.White;
            this.saat.Name = "saat";
            this.saat.Size = new System.Drawing.Size(29, 17);
            this.saat.Text = "saat";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 406);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_yazici_ekle);
            this.Controls.Add(this.cmbx_yazici);
            this.Controls.Add(this.lbl_yazici);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(528, 445);
            this.Name = "Form8";
            this.Text = "ARAÇLAR";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_yazici;
        private System.Windows.Forms.ComboBox cmbx_yazici;
        private System.Windows.Forms.Button btn_yazici_ekle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker baslangic_tarihi;
        private System.Windows.Forms.ComboBox cmbx_kodlar;
        private System.Windows.Forms.DateTimePicker bitis_tarihi;
        private System.Windows.Forms.Label lbl_baslangic;
        private System.Windows.Forms.Label lbl_bitis;
        private System.Windows.Forms.Label lbl_kod;
        private System.Windows.Forms.Label lbl_firma;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbx_firmaadi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button temizle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tarih;
        private System.Windows.Forms.ToolStripStatusLabel saat;
        private DevExpress.XtraEditors.SimpleButton scikis;
        private DevExpress.XtraEditors.SimpleButton ssimge;
        private DevExpress.XtraEditors.SimpleButton stam;
        private DevExpress.XtraEditors.SimpleButton fatura_goruntule;
    }
}
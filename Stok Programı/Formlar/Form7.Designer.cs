﻿namespace Stok_Programı
{
    partial class Form7
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpbx_bilgi = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_islemm = new System.Windows.Forms.Label();
            this.txt_islem = new System.Windows.Forms.TextBox();
            this.lbl_firmaadi = new System.Windows.Forms.Label();
            this.txt_adet = new System.Windows.Forms.TextBox();
            this.cmbx_firmaadi = new System.Windows.Forms.ComboBox();
            this.lbl_adet = new System.Windows.Forms.Label();
            this.cmbx_urunadi = new System.Windows.Forms.ComboBox();
            this.lbl_giristarihi = new System.Windows.Forms.Label();
            this.lbl_urunkodu = new System.Windows.Forms.Label();
            this.grpbx_islem = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.btn_temizle = new System.Windows.Forms.Button();
            this.pctrbx_resim = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tarih = new System.Windows.Forms.ToolStripStatusLabel();
            this.saat = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cikis = new DevExpress.XtraEditors.SimpleButton();
            this.tamekran = new DevExpress.XtraEditors.SimpleButton();
            this.simge = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip2.SuspendLayout();
            this.grpbx_bilgi.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpbx_islem.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_resim)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.yardımToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(617, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            this.anasayfaToolStripMenuItem.Click += new System.EventHandler(this.anasayfaToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.excelToolStripMenuItem.Text = "Excel Dokümanı";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
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
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // grpbx_bilgi
            // 
            this.grpbx_bilgi.Controls.Add(this.tableLayoutPanel1);
            this.grpbx_bilgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbx_bilgi.Location = new System.Drawing.Point(3, 3);
            this.grpbx_bilgi.Name = "grpbx_bilgi";
            this.grpbx_bilgi.Size = new System.Drawing.Size(344, 295);
            this.grpbx_bilgi.TabIndex = 2;
            this.grpbx_bilgi.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_islemm, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_islem, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_firmaadi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_adet, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbx_firmaadi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_adet, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbx_urunadi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_giristarihi, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_urunkodu, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 276);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 127);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(163, 20);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // lbl_islemm
            // 
            this.lbl_islemm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_islemm.AutoSize = true;
            this.lbl_islemm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_islemm.Location = new System.Drawing.Point(3, 241);
            this.lbl_islemm.Name = "lbl_islemm";
            this.lbl_islemm.Size = new System.Drawing.Size(163, 13);
            this.lbl_islemm.TabIndex = 7;
            this.lbl_islemm.Text = "İşlem:";
            // 
            // txt_islem
            // 
            this.txt_islem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_islem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_islem.Location = new System.Drawing.Point(172, 238);
            this.txt_islem.Name = "txt_islem";
            this.txt_islem.Size = new System.Drawing.Size(163, 20);
            this.txt_islem.TabIndex = 4;
            this.txt_islem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_firmaadi
            // 
            this.lbl_firmaadi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_firmaadi.AutoSize = true;
            this.lbl_firmaadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_firmaadi.Location = new System.Drawing.Point(3, 21);
            this.lbl_firmaadi.Name = "lbl_firmaadi";
            this.lbl_firmaadi.Size = new System.Drawing.Size(163, 13);
            this.lbl_firmaadi.TabIndex = 11;
            this.lbl_firmaadi.Text = "Firma Adi:";
            // 
            // txt_adet
            // 
            this.txt_adet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_adet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_adet.Location = new System.Drawing.Point(172, 182);
            this.txt_adet.Name = "txt_adet";
            this.txt_adet.Size = new System.Drawing.Size(163, 20);
            this.txt_adet.TabIndex = 3;
            this.txt_adet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_adet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_adet_KeyPress);
            // 
            // cmbx_firmaadi
            // 
            this.cmbx_firmaadi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbx_firmaadi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_firmaadi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbx_firmaadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbx_firmaadi.FormattingEnabled = true;
            this.cmbx_firmaadi.Location = new System.Drawing.Point(172, 17);
            this.cmbx_firmaadi.Name = "cmbx_firmaadi";
            this.cmbx_firmaadi.Size = new System.Drawing.Size(163, 21);
            this.cmbx_firmaadi.TabIndex = 0;
            this.cmbx_firmaadi.SelectedIndexChanged += new System.EventHandler(this.cmbx_firmaadi_SelectedIndexChanged);
            // 
            // lbl_adet
            // 
            this.lbl_adet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_adet.AutoSize = true;
            this.lbl_adet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_adet.Location = new System.Drawing.Point(3, 186);
            this.lbl_adet.Name = "lbl_adet";
            this.lbl_adet.Size = new System.Drawing.Size(163, 13);
            this.lbl_adet.TabIndex = 8;
            this.lbl_adet.Text = "Ürün Adet:";
            // 
            // cmbx_urunadi
            // 
            this.cmbx_urunadi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbx_urunadi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_urunadi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbx_urunadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbx_urunadi.FormattingEnabled = true;
            this.cmbx_urunadi.Location = new System.Drawing.Point(172, 72);
            this.cmbx_urunadi.Name = "cmbx_urunadi";
            this.cmbx_urunadi.Size = new System.Drawing.Size(163, 21);
            this.cmbx_urunadi.TabIndex = 1;
            this.cmbx_urunadi.SelectedIndexChanged += new System.EventHandler(this.cmbx_urunadi_SelectedIndexChanged);
            // 
            // lbl_giristarihi
            // 
            this.lbl_giristarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_giristarihi.AutoSize = true;
            this.lbl_giristarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_giristarihi.Location = new System.Drawing.Point(3, 131);
            this.lbl_giristarihi.Name = "lbl_giristarihi";
            this.lbl_giristarihi.Size = new System.Drawing.Size(163, 13);
            this.lbl_giristarihi.TabIndex = 9;
            this.lbl_giristarihi.Text = "Giriş Tarihi:";
            // 
            // lbl_urunkodu
            // 
            this.lbl_urunkodu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_urunkodu.AutoSize = true;
            this.lbl_urunkodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_urunkodu.Location = new System.Drawing.Point(3, 76);
            this.lbl_urunkodu.Name = "lbl_urunkodu";
            this.lbl_urunkodu.Size = new System.Drawing.Size(163, 13);
            this.lbl_urunkodu.TabIndex = 10;
            this.lbl_urunkodu.Text = "Ürün Kodu:";
            // 
            // grpbx_islem
            // 
            this.grpbx_islem.Controls.Add(this.tableLayoutPanel2);
            this.grpbx_islem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbx_islem.Location = new System.Drawing.Point(3, 310);
            this.grpbx_islem.Name = "grpbx_islem";
            this.grpbx_islem.Size = new System.Drawing.Size(467, 66);
            this.grpbx_islem.TabIndex = 18;
            this.grpbx_islem.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_kaydet, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_temizle, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(461, 47);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_kaydet.FlatAppearance.BorderSize = 0;
            this.btn_kaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kaydet.Location = new System.Drawing.Point(308, 3);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(75, 40);
            this.btn_kaydet.TabIndex = 6;
            this.btn_kaydet.UseVisualStyleBackColor = true;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // btn_temizle
            // 
            this.btn_temizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_temizle.FlatAppearance.BorderSize = 0;
            this.btn_temizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_temizle.Location = new System.Drawing.Point(77, 3);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(75, 40);
            this.btn_temizle.TabIndex = 5;
            this.btn_temizle.UseVisualStyleBackColor = true;
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // pctrbx_resim
            // 
            this.pctrbx_resim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctrbx_resim.Location = new System.Drawing.Point(358, 100);
            this.pctrbx_resim.Name = "pctrbx_resim";
            this.pctrbx_resim.Size = new System.Drawing.Size(100, 100);
            this.pctrbx_resim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrbx_resim.TabIndex = 4;
            this.pctrbx_resim.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarih,
            this.saat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(617, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tarih
            // 
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(33, 17);
            this.tarih.Text = "tarih";
            // 
            // saat
            // 
            this.saat.Name = "saat";
            this.saat.Size = new System.Drawing.Size(29, 17);
            this.saat.Text = "saat";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.grpbx_islem, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(72, 72);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.15501F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.84498F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(473, 379);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.1606F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.8394F));
            this.tableLayoutPanel4.Controls.Add(this.grpbx_bilgi, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pctrbx_resim, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(467, 301);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.Controls.Add(this.cikis, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tamekran, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.simge, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(479, 28);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(138, 41);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // cikis
            // 
            this.cikis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cikis.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mcikis;
            this.cikis.Location = new System.Drawing.Point(98, 6);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(34, 33);
            this.cikis.TabIndex = 17;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // tamekran
            // 
            this.tamekran.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tamekran.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tamekran.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mtamekran;
            this.tamekran.Location = new System.Drawing.Point(52, 6);
            this.tamekran.Name = "tamekran";
            this.tamekran.Size = new System.Drawing.Size(34, 33);
            this.tamekran.TabIndex = 16;
            this.tamekran.Click += new System.EventHandler(this.tamekran_Click);
            // 
            // simge
            // 
            this.simge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simge.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simge.ImageOptions.Image = global::Stok_Programı.Properties.Resources.msmge;
            this.simge.Location = new System.Drawing.Point(6, 6);
            this.simge.Name = "simge";
            this.simge.Size = new System.Drawing.Size(34, 33);
            this.simge.TabIndex = 15;
            this.simge.Click += new System.EventHandler(this.simge_Click);
            // 
            // Form7
            // 
            this.AcceptButton = this.btn_kaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 500);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MinimumSize = new System.Drawing.Size(489, 467);
            this.Name = "Form7";
            this.Text = "ÜRETİM GİRİŞ";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.grpbx_bilgi.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpbx_islem.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_resim)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.GroupBox grpbx_bilgi;
        private System.Windows.Forms.TextBox txt_islem;
        private System.Windows.Forms.TextBox txt_adet;
        private System.Windows.Forms.ComboBox cmbx_urunadi;
        private System.Windows.Forms.ComboBox cmbx_firmaadi;
        private System.Windows.Forms.GroupBox grpbx_islem;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.Button btn_temizle;
        private System.Windows.Forms.PictureBox pctrbx_resim;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tarih;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        public System.Windows.Forms.Label lbl_islemm;
        public System.Windows.Forms.Label lbl_adet;
        public System.Windows.Forms.Label lbl_giristarihi;
        public System.Windows.Forms.Label lbl_urunkodu;
        public System.Windows.Forms.Label lbl_firmaadi;
        public System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripStatusLabel saat;
        private DevExpress.XtraEditors.SimpleButton simge;
        private DevExpress.XtraEditors.SimpleButton tamekran;
        private DevExpress.XtraEditors.SimpleButton cikis;
    }
}
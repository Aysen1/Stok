namespace Stok_Programı
{
    partial class Form6
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
            this.btn_urun = new System.Windows.Forms.Button();
            this.btn_firma = new System.Windows.Forms.Button();
            this.btn_giris = new System.Windows.Forms.Button();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tarih = new System.Windows.Forms.ToolStripStatusLabel();
            this.saat = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ayarlar = new System.Windows.Forms.Button();
            this.btn_stok = new System.Windows.Forms.Button();
            this.btn_araclar = new System.Windows.Forms.Button();
            this.pctrbx_logo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cikis = new DevExpress.XtraEditors.SimpleButton();
            this.tamekran = new DevExpress.XtraEditors.SimpleButton();
            this.simge = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_logo)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_urun
            // 
            this.btn_urun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_urun.FlatAppearance.BorderSize = 0;
            this.btn_urun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_urun.Location = new System.Drawing.Point(3, 5);
            this.btn_urun.Name = "btn_urun";
            this.btn_urun.Size = new System.Drawing.Size(143, 84);
            this.btn_urun.TabIndex = 0;
            this.btn_urun.UseVisualStyleBackColor = true;
            this.btn_urun.Click += new System.EventHandler(this.btn_urun_Click);
            // 
            // btn_firma
            // 
            this.btn_firma.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_firma.FlatAppearance.BorderSize = 0;
            this.btn_firma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_firma.Location = new System.Drawing.Point(3, 30);
            this.btn_firma.Name = "btn_firma";
            this.btn_firma.Size = new System.Drawing.Size(105, 84);
            this.btn_firma.TabIndex = 1;
            this.btn_firma.UseVisualStyleBackColor = true;
            this.btn_firma.Click += new System.EventHandler(this.btn_firma_Click);
            // 
            // btn_giris
            // 
            this.btn_giris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_giris.FlatAppearance.BorderSize = 0;
            this.btn_giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_giris.Location = new System.Drawing.Point(155, 5);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(143, 84);
            this.btn_giris.TabIndex = 2;
            this.btn_giris.UseVisualStyleBackColor = true;
            this.btn_giris.Click += new System.EventHandler(this.btn_giris_Click);
            // 
            // btn_cikis
            // 
            this.btn_cikis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_cikis.FlatAppearance.BorderSize = 0;
            this.btn_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cikis.Location = new System.Drawing.Point(307, 5);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(143, 84);
            this.btn_cikis.TabIndex = 3;
            this.btn_cikis.UseVisualStyleBackColor = true;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarih,
            this.saat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tarih
            // 
            this.tarih.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 513F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 108);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(467, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 250);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableLayoutPanel2.Controls.Add(this.btn_urun, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_giris, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_cikis, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(507, 94);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel3.Controls.Add(this.btn_firma, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_ayarlar, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_stok, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_araclar, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(507, 144);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btn_ayarlar
            // 
            this.btn_ayarlar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ayarlar.FlatAppearance.BorderSize = 0;
            this.btn_ayarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ayarlar.Location = new System.Drawing.Point(346, 30);
            this.btn_ayarlar.Name = "btn_ayarlar";
            this.btn_ayarlar.Size = new System.Drawing.Size(105, 84);
            this.btn_ayarlar.TabIndex = 4;
            this.btn_ayarlar.UseVisualStyleBackColor = true;
            this.btn_ayarlar.Click += new System.EventHandler(this.btn_ayarlar_Click);
            // 
            // btn_stok
            // 
            this.btn_stok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_stok.FlatAppearance.BorderSize = 0;
            this.btn_stok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stok.Location = new System.Drawing.Point(118, 30);
            this.btn_stok.Name = "btn_stok";
            this.btn_stok.Size = new System.Drawing.Size(105, 84);
            this.btn_stok.TabIndex = 5;
            this.btn_stok.UseVisualStyleBackColor = true;
            this.btn_stok.Click += new System.EventHandler(this.btn_stok_Click);
            // 
            // btn_araclar
            // 
            this.btn_araclar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_araclar.FlatAppearance.BorderSize = 0;
            this.btn_araclar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_araclar.Location = new System.Drawing.Point(233, 30);
            this.btn_araclar.Name = "btn_araclar";
            this.btn_araclar.Size = new System.Drawing.Size(105, 84);
            this.btn_araclar.TabIndex = 6;
            this.btn_araclar.UseVisualStyleBackColor = true;
            this.btn_araclar.Click += new System.EventHandler(this.btn_araclar_Click);
            // 
            // pctrbx_logo
            // 
            this.pctrbx_logo.Location = new System.Drawing.Point(3, 3);
            this.pctrbx_logo.Name = "pctrbx_logo";
            this.pctrbx_logo.Size = new System.Drawing.Size(248, 33);
            this.pctrbx_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrbx_logo.TabIndex = 7;
            this.pctrbx_logo.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel4.Controls.Add(this.cikis, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.tamekran, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.simge, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.pctrbx_logo, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(27, 12);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(569, 39);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // cikis
            // 
            this.cikis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cikis.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mcikis;
            this.cikis.Location = new System.Drawing.Point(529, 3);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(34, 33);
            this.cikis.TabIndex = 14;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // tamekran
            // 
            this.tamekran.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tamekran.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tamekran.ImageOptions.Image = global::Stok_Programı.Properties.Resources.mtamekran;
            this.tamekran.Location = new System.Drawing.Point(483, 3);
            this.tamekran.Name = "tamekran";
            this.tamekran.Size = new System.Drawing.Size(34, 33);
            this.tamekran.TabIndex = 13;
            this.tamekran.Click += new System.EventHandler(this.tamekran_Click);
            // 
            // simge
            // 
            this.simge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simge.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simge.ImageOptions.Image = global::Stok_Programı.Properties.Resources.msmge;
            this.simge.Location = new System.Drawing.Point(437, 3);
            this.simge.Name = "simge";
            this.simge.Size = new System.Drawing.Size(34, 33);
            this.simge.TabIndex = 12;
            this.simge.Click += new System.EventHandler(this.simge_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(605, 470);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(522, 358);
            this.Name = "Form6";
            this.Text = "ANA İŞLEM PANELİ";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form6_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrbx_logo)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_urun;
        private System.Windows.Forms.Button btn_firma;
        private System.Windows.Forms.Button btn_giris;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tarih;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_ayarlar;
        private System.Windows.Forms.Button btn_stok;
        private System.Windows.Forms.PictureBox pctrbx_logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_araclar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripStatusLabel saat;
        private DevExpress.XtraEditors.SimpleButton simge;
        private DevExpress.XtraEditors.SimpleButton tamekran;
        private DevExpress.XtraEditors.SimpleButton cikis;
    }
}
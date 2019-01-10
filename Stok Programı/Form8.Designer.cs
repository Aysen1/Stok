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
            this.lbl_yazici = new System.Windows.Forms.Label();
            this.cmbx_yazici = new System.Windows.Forms.ComboBox();
            this.btn_yazici_ekle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cikiss = new System.Windows.Forms.Button();
            this.btn_tamekran = new System.Windows.Forms.Button();
            this.btn_simge = new System.Windows.Forms.Button();
            this.btn_bilgi_fisi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_yazici
            // 
            this.lbl_yazici.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_yazici.AutoSize = true;
            this.lbl_yazici.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_yazici.Location = new System.Drawing.Point(36, 84);
            this.lbl_yazici.Name = "lbl_yazici";
            this.lbl_yazici.Size = new System.Drawing.Size(59, 13);
            this.lbl_yazici.TabIndex = 0;
            this.lbl_yazici.Text = "Yazıcılar:";
            // 
            // cmbx_yazici
            // 
            this.cmbx_yazici.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbx_yazici.FormattingEnabled = true;
            this.cmbx_yazici.Location = new System.Drawing.Point(176, 76);
            this.cmbx_yazici.Name = "cmbx_yazici";
            this.cmbx_yazici.Size = new System.Drawing.Size(173, 21);
            this.cmbx_yazici.TabIndex = 1;
            // 
            // btn_yazici_ekle
            // 
            this.btn_yazici_ekle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_yazici_ekle.FlatAppearance.BorderSize = 0;
            this.btn_yazici_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yazici_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yazici_ekle.Location = new System.Drawing.Point(399, 74);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(380, 27);
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
            // btn_bilgi_fisi
            // 
            this.btn_bilgi_fisi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_bilgi_fisi.FlatAppearance.BorderSize = 0;
            this.btn_bilgi_fisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bilgi_fisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_bilgi_fisi.Location = new System.Drawing.Point(212, 155);
            this.btn_bilgi_fisi.Name = "btn_bilgi_fisi";
            this.btn_bilgi_fisi.Size = new System.Drawing.Size(173, 23);
            this.btn_bilgi_fisi.TabIndex = 4;
            this.btn_bilgi_fisi.Text = "Bilgi Fişi ";
            this.btn_bilgi_fisi.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.yardımToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
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
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 402);
            this.ControlBox = false;
            this.Controls.Add(this.btn_bilgi_fisi);
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
        private System.Windows.Forms.Button btn_bilgi_fisi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
    }
}
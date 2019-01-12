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
            this.btn_baglan = new System.Windows.Forms.Button();
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
            this.txt_serverip.Location = new System.Drawing.Point(171, 80);
            this.txt_serverip.Name = "txt_serverip";
            this.txt_serverip.Size = new System.Drawing.Size(100, 20);
            this.txt_serverip.TabIndex = 1;
            // 
            // txt_veritabani
            // 
            this.txt_veritabani.Location = new System.Drawing.Point(171, 122);
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
            this.txt_kullaniciadi.Location = new System.Drawing.Point(171, 168);
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
            this.txt_sifre.Location = new System.Drawing.Point(171, 212);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(100, 20);
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
            // btn_baglan
            // 
            this.btn_baglan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_baglan.Location = new System.Drawing.Point(137, 255);
            this.btn_baglan.Name = "btn_baglan";
            this.btn_baglan.Size = new System.Drawing.Size(79, 29);
            this.btn_baglan.TabIndex = 8;
            this.btn_baglan.Text = "Bağlan";
            this.btn_baglan.UseVisualStyleBackColor = true;
            this.btn_baglan.Click += new System.EventHandler(this.btn_baglan_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 327);
            this.Controls.Add(this.btn_baglan);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.lbl_sifre);
            this.Controls.Add(this.txt_kullaniciadi);
            this.Controls.Add(this.lbl_kullaniciadi);
            this.Controls.Add(this.txt_veritabani);
            this.Controls.Add(this.lbl_veritabani);
            this.Controls.Add(this.txt_serverip);
            this.Controls.Add(this.lbl_serverip);
            this.Name = "Form2";
            this.Text = "Veritabanı Bağlantı Ayarı";
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
        private System.Windows.Forms.Button btn_baglan;
    }
}
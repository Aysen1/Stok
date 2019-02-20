using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stok_Programı.Faturalar;
using System.Data.SqlClient;
namespace Stok_Programı.Formlar
{
    public partial class SigortamWebb : Form
    {
        public SigortamWebb()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();
        SqlCommand komut;
        private void sbelge_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.ClientSize.Width / 2, this.ClientSize.Height / 2 - panel1.ClientSize.Height / 2);
            panel2.Location = new Point(this.ClientSize.Width / 5 - panel2.ClientSize.Width / 5, this.ClientSize.Height / 2 - panel2.ClientSize.Height / 2);
            panel1.Visible = true;
            panel2.Visible = true;
            kod_cekme();
            panel3.Visible = false;
            d_veriler.Visible = true;
            txt_akod.Text = "";
            txt_isim.Text = "";
            txt_adres.Text = "";
            txtdaire.Text = "";
            txtvno.Text = "";
            txtbolge.Text = "";
        }
        private void btn_ara2_Click(object sender, EventArgs e)
        {
            Sweb yeni = new Sweb();
            yeni.ara(cmbx_kod.Text, d_veriler);
        }

        private void SigortamWebb_Load(object sender, EventArgs e)
        {
            timer1.Start();
            tarih.BackColor = Color.White;
            saat.BackColor = Color.White;
            this.WindowState = FormWindowState.Maximized;
           /* bitis.Properties.Mask.EditMask = "MM-dd-yyyy";
            bitis.Properties.Mask.UseMaskAsDisplayFormat = true;
            baslangic.Properties.Mask.EditMask = "MM-dd-yyyy";
            baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;*/
            spolice_kayit.Appearance.BackColor = ColorTranslator.FromHtml("#56aaff");
            skayit.Appearance.BackColor = ColorTranslator.FromHtml("#56aaff");
            stemizle.Appearance.BackColor = ColorTranslator.FromHtml("#f2b826");
            s_police_gor.Appearance.BackColor = ColorTranslator.FromHtml("#cce54e");
            s_temizle.Appearance.BackColor = ColorTranslator.FromHtml("#f2b826");
            btn_ara2.Appearance.BackColor = ColorTranslator.FromHtml("#ced65e");
        }

        private void s_kayit_Click(object sender, EventArgs e)
        {
            panel3.Location = new Point(this.ClientSize.Width / 2 - panel3.ClientSize.Width / 2, this.ClientSize.Height / 2 - panel3.ClientSize.Height / 2);
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            d_veriler.Visible = false;

            d_veriler.DataSource = "";
            cmbx_kod.Text = "";
            txt_aciklama.Text = "";
            txt_iptalk.Text = "";
            txt_istihsalk.Text = "";
            baslangic.Text = "";
            bitis.Text = "";
        }

        private void ssimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void stam_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void scikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
        private void skayit_Click(object sender, EventArgs e)
        {
            database.Baglanti();
            if (txt_akod.Text != "" & txt_isim.Text != "" & txt_adres.Text != "" & txtdaire.Text != "" & txtvno.Text != "" & txtbolge.Text != "")
            {
                database.BaglantiAc();
                komut = new SqlCommand(@"insert into CariBilgileri (AcenteKodu,Bolge,Unvan,Adres,VergiDairesi,VergiNo,Bakiye) VALUES ('" + txt_akod.Text + "','" + txtbolge.Text + "','" + txt_isim.Text + "','" + txt_adres.Text + "','"+txtdaire.Text+"','"+txtvno.Text+"','"+0+"')", database.baglanti);
                komut.ExecuteNonQuery();
                database.BaglantiKapat();
                MessageBox.Show("Kayıt Başarılı..", "Bilgilendirme Penceresi");
            }
            else
            {
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Lütfen gerekli alanları doldurunuz..", "Bilgilendirme Penceresi");
                database.BaglantiKapat();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtarih.Text = DateTime.Now.ToString();
            tarih.Text = DateTime.Today.ToLongDateString();
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void kod_cekme()
        {
            cmbx_kod.Items.Clear();
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand(@"SELECT AcenteKodu FROM CariBilgileri",database.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
                cmbx_kod.Items.Add(dr["AcenteKodu"]);
            database.BaglantiKapat();
        }

        private void spolice_kayit_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet("Tablo");
            Sweb yeni = new Sweb();
            yeni.police_kaydet(ds1, cmbx_kod.Text, txt_aciklama.Text, txt_iptalk.Text, txt_istihsalk.Text, dtarih.Text, baslangic.Text, bitis.Text);
           // yeni.police_kaydet(ds1, cmbx_kod.Text, txt_aciklama.Text, maskedTextBox1.Text, txt_istihsalk.Text,dtarih.Text,baslangic.Text,bitis.Text);
        }
        private void s_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void stemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {
            if (panel1.Visible == true & panel2.Visible == true & d_veriler.Visible == true)
            {
                d_veriler.DataSource = "";
                cmbx_kod.Text = "";
                txt_aciklama.Text = "";
                txt_iptalk.Text = "";
                txt_istihsalk.Text = "";
                baslangic.Text = "";
                bitis.Text = "";
            }
            else if (panel3.Visible == true)
            {
                txt_akod.Text = "";
                txt_isim.Text = "";
                txt_adres.Text = "";
                txtdaire.Text = "";
                txtvno.Text = "";
                txtbolge.Text = "";
            }
            else
                MessageBox.Show("Beklenmeyen bir hata oluştu..Lütfen yeniden deneyin..", "Bilgilendirme Penceresi");
        }

        private void s_police_yazdir_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet("Tablo");
            Sweb yeni = new Sweb();
            yeni.belge_goster(ds1, cmbx_kod.Text, txt_aciklama.Text, txt_iptalk.Text, txt_istihsalk.Text, dtarih.Text);
        }
        private void d_veriler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Sweb yeni = new Sweb();
            Properties.Settings.Default.belgesirano = d_veriler.CurrentRow.Cells["BelgeSiraNo"].Value.ToString();
            Properties.Settings.Default.Save();     
        }
    }
}

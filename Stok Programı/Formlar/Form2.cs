using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Stok_Programı
{
    public partial class Form2 : Form
    {
        DatabaseConnection database;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            database = new DatabaseConnection();
            txt_serverip.Text = Properties.Settings.Default.serverip;
            txt_veritabani.Text = Properties.Settings.Default.veritabani;
            txt_kullaniciadi.Text = Properties.Settings.Default.kullaniciisim;
            txt_sifre.Text = Properties.Settings.Default.kullanicisifre;
            if(Properties.Settings.Default.dil=="İngilizce")
                Localization.Culture = new CultureInfo("en-US");
            this.Text = Localization.form2;
            lbl_kullaniciadi.Text = Localization.lbl_kullanici_adi;
            lbl_serverip.Text = Localization.ip;
            lbl_sifre.Text = Localization.lbl_sifre;
            lbl_veritabani.Text = Localization.veritabani;
            baglan.Text = Localization.baglan;
            baglanti_kaydet.Text = Localization.kaydet;
            baglanti_kontrol.Text = Localization.kontrol;
        }
        private void ssimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void scikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baglan_Click(object sender, EventArgs e)
        {
            //txt_serverip.Text == "NFM-1\\MSSQLSERVER01"
            if ((txt_serverip.Text == "192.168.1.33" || txt_serverip.Text=="localhost\\SQLEXPRESS" || txt_serverip.Text == "SIGORTAM") & txt_veritabani.Text == "StokTakip" & txt_kullaniciadi.Text == "nfm" & txt_sifre.Text == "NFM")
            {
                Properties.Settings.Default.serverip = txt_serverip.Text;
                Properties.Settings.Default.veritabani = txt_veritabani.Text;
                Properties.Settings.Default.kullaniciisim = txt_kullaniciadi.Text;
                Properties.Settings.Default.kullanicisifre = txt_sifre.Text;
                database.Baglanti();
            }
            else
                MessageBox.Show("Hatalı Bilgi Girişi Yapıldı. Lütfen bilgileri kontrol edip yeniden girmeyi deneyiniz.", "Bilgi Penceresi");
        }
        private void baglanti_kontrol_Click(object sender, EventArgs e)
        {
            if (database.baglanti == null)
                MessageBox.Show("Bağlantı durumunu kontrol edebilmeniz için önce BAĞLAN butonuna tıklamanız gerekmektedir.","Bilgilendirme Penceresi");
            else
            {
                if (database.baglanti.State != ConnectionState.Open)
                {
                    database.BaglantiAc();
                    MessageBox.Show("Veritabanına bağlantı sağlandı.", "Bilgilendirme Penceresi");
                }
                else
                    MessageBox.Show("Veritabanına Bağlanırken Hata Oluştu. Lütfen yeniden deneyiniz.");
            }
        }
        private void baglanti_kaydet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.serverip = txt_serverip.Text;
            Properties.Settings.Default.veritabani = txt_veritabani.Text;
            Properties.Settings.Default.kullaniciisim = txt_kullaniciadi.Text;
            Properties.Settings.Default.kullanicisifre = txt_sifre.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Bilgiler varsayılan olarak kaydedildi. Şimdi Uygulamayı Yeniden Başlatın.", "Bilgilendirme Penceresi");
        }
    }
}
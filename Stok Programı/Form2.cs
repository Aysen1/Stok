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

namespace Stok_Programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_baglan_Click(object sender, EventArgs e)
        {
            if (txt_serverip.Text == "NFM-1\\MSSQLSERVER01" && txt_veritabani.Text=="StokTakip")
            {
                Properties.Settings.Default.serverip = txt_serverip.Text;
                Properties.Settings.Default.veritabani = txt_veritabani.Text;
                Properties.Settings.Default.kullaniciadi = txt_kullaniciadi.Text;
                Properties.Settings.Default.sifre = txt_sifre.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show(txt_serverip.Text);
            }
            else if (txt_serverip.Text != "NFM-1\\MSSQLSERVER01" & txt_veritabani.Text != "StokTakip")
                MessageBox.Show(txt_serverip.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txt_serverip.Text = Properties.Settings.Default.serverip;
            txt_veritabani.Text = Properties.Settings.Default.veritabani;
            txt_kullaniciadi.Text = Properties.Settings.Default.kullaniciadi;
            txt_sifre.Text = Properties.Settings.Default.sifre;
            if(Properties.Settings.Default.dil=="İngilizce")
            {
                Localization.Culture = new CultureInfo("en-US");
                lbl_kullaniciadi.Text = Localization.lbl_kullanici_adi;
                lbl_serverip.Text = Localization.ip;
                lbl_sifre.Text = Localization.lbl_sifre;
                lbl_veritabani.Text = Localization.veritabani;
            }
        }
    }
}

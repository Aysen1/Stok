using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Drawing.Imaging;

namespace Stok_Programı
{
    public partial class Form1 : Form
    {
        SqlCommand komut;
        DatabaseConnection database;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand( "select * from KullaniciBilgileri where convert(Varchar, KullaniciAdi)='"+ txt_kullanici_isim.Text +"' and convert(Varchar, KullaniciSifre)='"+ txt_kullanici_sifre.Text +"'");
            komut.Connection = database.baglanti;
            SqlDataReader data = komut.ExecuteReader();
            if (data.Read())
            {
                Properties.Settings.Default.kullaniciadi = txt_kullanici_isim.Text;
                Properties.Settings.Default.sifre = txt_kullanici_sifre.Text;
                Form6 form6 = new Form6();
                form6.Show();
                this.Hide();             
            }
            else
                MessageBox.Show( "Girilen Bilgiler Hatalıdır!Tekrar Deneyiniz.");
            database.BaglantiKapat();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            database = new DatabaseConnection();
            txt_kullanici_isim.Text=Properties.Settings.Default.kullaniciadi;
            txt_kullanici_sifre.Text = Properties.Settings.Default.sifre;
           // Properties.Settings.Default.dil = "Türkçe";
            this.WindowState = FormWindowState.Maximized;
          //  baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            lbl_versiyon.Text = Application.ProductVersion;
            lbl_nfm.Text = "NFM AJANS SAN. VE TIC. LTD. STI";
            lbl_destek.Text = "Destek Hattı: 0 (236) 231 40 10";
            btn_0.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b0.fw.png");
            btn_1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b1.fw.png");
            btn_2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b2.fw.png");
            btn_3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b3.fw.png");
            btn_4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b4.fw.png");
            btn_5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b5.fw.png");
            btn_6.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b6.fw.png");
            btn_7.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b7.fw.png");
            btn_8.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b8.fw.png");
            btn_9.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\b9.fw.png");
            pctrbx_logo.Image = Image.FromFile(Application.StartupPath + "\\image\\logo.jpeg");
            lbl_versiyon.Text = "Versiyon " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (Properties.Settings.Default.dil == "İngilizce")
            {
                Localization.Culture = new CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");                
                btn_giris.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bgirisK.fw.png");
                btn_kapat.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\biptalK.fw.png");
                btn_sil.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bsilK.fw.png");
                lbl_versiyon.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                Localization.Culture = new CultureInfo("");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                btn_sil.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bsil.fw.png");
                btn_giris.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bgiris.fw.png");
                btn_kapat.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\biptal.fw.png");
                lbl_versiyon.Text = "Versiyon " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            metin();
            this.BackColor=Properties.Settings.Default.tema;
            tableLayoutPanel4.BackColor = Properties.Settings.Default.tema;
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.ClientSize.Width / 2, this.ClientSize.Height / 2 - panel1.ClientSize.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }
        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "0";
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "1";
        }
        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "2";
        }
        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "3";
        }
        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "4";
        }
        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "5";
        }
        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "6";
        }
        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "7";
        }
        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "8";
        }
        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = txt_kullanici_sifre.Text + "9";
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            txt_kullanici_sifre.Text = "";
        }
        private void metin()
        {
            lbl_kullanici_adi.Text = Localization.lbl_kullanici_adi;
            this.Text = Localization.form1;
            lbl_kullanicigiris.Text = Localization.lbl_kullanicigiris;
            lbl_sifre.Text = Localization.lbl_sifre;
            lbl_destek.Text = Localization.lbl_destek;
        }   
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_destek.Text = DateTime.Now.ToString();
            timer1.Start();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
                txt_kullanici_isim.Focus();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }
        private void simge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void tamekran_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            txt_kullanici_isim.Text = "";
            txt_kullanici_sifre.Text = "";
        }
    }
}
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
        SqlConnection baglanti;
        SqlCommand komut;
        string resimpath;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand( "select * from KullaniciBilgileri where convert(Varchar, KullaniciAdi)='"+ txt_kullanici_isim.Text +"' and convert(Varchar, KullaniciSifre)='"+ txt_kullanici_sifre.Text +"'");
            komut.Connection = baglanti;
            SqlDataReader data = komut.ExecuteReader();
            if (data.Read())
            {
                Properties.Settings.Default.kullaniciadi = txt_kullanici_isim.Text;
                Properties.Settings.Default.serverip = "NFM-1";
                Properties.Settings.Default.sifre = txt_kullanici_sifre.Text;
                Properties.Settings.Default.veritabani = "StokTakip";
                Form6 form6 = new Form6();
                form6.Show();
                this.Hide();
                
            }
            else
                MessageBox.Show( "Girilen Bilgiler Hatalıdır!Tekrar Deneyiniz.");
            baglanti.Close();
        }
        System.Diagnostics.Process a = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_kullanici_isim.Text=Properties.Settings.Default.kullaniciadi;
            Properties.Settings.Default.serverip = "NFM-1";
            txt_kullanici_sifre.Text = Properties.Settings.Default.sifre;
            Properties.Settings.Default.veritabani = "StokTakip";

            this.WindowState = FormWindowState.Maximized;
            baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
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
            btn_simge.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\simge.fw.png");
            btn_tamekran.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\tamekran.fw.png");
            btn_cikiss.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\cikis.fw.png");
            pctrbx_logo.Image = Image.FromFile(Application.StartupPath + "\\image\\logo.jpeg");

            GraphicsPath gp1 = new GraphicsPath();
            gp1.AddEllipse(0, 0, btn_simge.Width - 1, btn_simge.Height - 1);
            Region rg1 = new Region(gp1);
            btn_simge.Region = rg1; 

            GraphicsPath gp2 = new GraphicsPath();
            gp2.AddEllipse(0, 0, btn_tamekran.Width - 1, btn_tamekran.Height - 1);
            Region rg2 = new Region(gp2);
            btn_tamekran.Region = rg2;

            GraphicsPath gp3 = new GraphicsPath();
            gp3.AddEllipse(0, 0, btn_cikiss.Width - 1, btn_cikiss.Height - 1);
            Region rg3 = new Region(gp3);
            btn_cikiss.Region = rg3;

            if (Properties.Settings.Default.dil == "İngilizce")
            {
                Localization.Culture = new CultureInfo("en-US");
                btn_giris.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bgirisK.fw.png");
                btn_kapat.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\biptalK.fw.png");
                btn_sil.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bsilK.fw.png");
                lbl_versiyon.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                Localization.Culture = new CultureInfo("");
                btn_sil.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bsil.fw.png");
                btn_giris.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\bgiris.fw.png");
                btn_kapat.BackgroundImage = Image.FromFile(Application.StartupPath + "\\image\\biptal.fw.png");
                lbl_versiyon.Text = "Versiyon " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            metin();
            this.BackColor=Properties.Settings.Default.tema;
            tableLayoutPanel4.BackColor = Properties.Settings.Default.tema;
            //this.BackColor = Color.White;
            //tableLayoutPanel4.BackColor = Color.White;
            panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.ClientSize.Width / 2, this.ClientSize.Height / 2 - panel1.ClientSize.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btn_simge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_tamekran_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_cikiss_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();
        }
        private void metin()
        {
            lbl_kullanici_adi.Text = Localization.lbl_kullanici_adi;
            this.Text = Localization.form1;
            lbl_kullanicigiris.Text = Localization.lbl_kullanicigiris;
            lbl_sifre.Text = Localization.lbl_sifre;
            lbl_destek.Text = Localization.lbl_destek;
        }
        private GraphicsPath RoundedRectangle(RectangleF rect, float xradius, float yradius,bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();
            if (round_ul)
            {
                RectangleF corner = new RectangleF(rect.X, rect.Y, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X, rect.Y);
            }
            else
                point1 = new PointF(rect.X, rect.Y);

            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right,rect.Y);
            path.AddLine(point1, point2);

            if (round_ur)
            {
                RectangleF corner = new RectangleF(rect.Right - 2 * xradius, rect.Y, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else
                point1 = new PointF(rect.Right,rect.Y);
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            if (round_lr)
            {
                RectangleF corner = new RectangleF(rect.Right - 2 * xradius, rect.Bottom - 2 * yradius, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else
                point1 = new PointF(rect.Right, rect.Bottom);

            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X,rect.Bottom);
            path.AddLine(point1, point2);

            if (round_ll)
            {
                RectangleF corner = new RectangleF(rect.X, rect.Bottom - 2 * yradius, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else
                point1 = new PointF(rect.X,rect.Bottom);

            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1,point2);

            path.CloseFigure();
            return path;
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
    }

}

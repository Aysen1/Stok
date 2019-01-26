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
using System.IO;
using System.Drawing.Drawing2D;
using System.Globalization;
namespace Stok_Programı
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti;
        SqlConnectionStringBuilder baglan = new SqlConnectionStringBuilder();
        SqlCommand komut;
        string resimpath;
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }      
        private void Form3_Load(object sender, EventArgs e)
        {
            tarih.Text = DateTime.Today.ToLongDateString();
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            baglan.DataSource = Properties.Settings.Default.serverip;
            baglan.InitialCatalog = Properties.Settings.Default.veritabani;
            baglan.IntegratedSecurity = true;
            baglanti = new SqlConnection(baglan.ConnectionString);
            firma_listele();
            pctrbx_urunresim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");

            if (Properties.Settings.Default.dil == "İngilizce")
            { 
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");                
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydetK.fw.png");
                btn_resim_yukle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\yukleK.fw.png");
                btn_resim_sil.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\sillK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            { 
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydet.fw.png");
                btn_resim_yukle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\yukle.fw.png");
                btn_resim_sil.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\sill.fw.png");
            }
            metin();
            this.BackColor = Properties.Settings.Default.tema;
            tarih.BackColor = Color.White;
            saat.BackColor = Color.White;
        }
        private void firma_listele()
        {
            komut = new SqlCommand("select * from FirmaKayit",baglanti);
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbbx_firma_adi.Items.Add(dr["FirmaAdi"]);
            }
            baglanti.Close();
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            cmbbx_firma_adi.Text = "";
            txt_urun_kodu.Text = "";
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            if (cmbbx_firma_adi.Text != "" && txt_urun_kodu.Text != "")
            {
                urunkod_kontrol();     
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Lütfen Bilgileri Tam Giriniz.");
            }     
        }
        private void urun_kayit()
        {
            FileStream fs = new FileStream(resimpath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] resim = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = baglanti;
            baglanti.Open();
            komut2.CommandText = "insert into UrunKayit1(FirmaAdi, UrunKodu, KayitTarihi, UrunResim, ToplamAdet, Personel) values ('" + cmbbx_firma_adi.Text + "','" + txt_urun_kodu.Text + "','" + dateTimePicker1.Text + "',@image,0, @personel)";
            komut2.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
            komut2.Parameters.AddWithValue("@personel", Properties.Settings.Default.kullaniciadi);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Başarılı.");
            baglanti.Close(); 
        }
        private void btn_resim_yukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd1 = new OpenFileDialog();
            opfd1.Filter = "Png Dosyası (*.png)|*.png";
            if(opfd1.ShowDialog()==DialogResult.OK)
            {
                pctrbx_urunresim.Image = Image.FromFile(opfd1.FileName);
                resimpath = opfd1.FileName.ToString();
            }
        }
        private void btn_resim_sil_Click(object sender, EventArgs e)
        {
            pctrbx_urunresim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");
        }
        private void anaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Dispose();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            saat.Text = DateTime.Now.ToLongTimeString(); ;
            timer1.Start();
        }
        private void urunkod_kontrol()
        {
            baglanti.Open();
            int kontrol = 0;
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from UrunKayit1 where UrunKodu=@kod ";
            komut.Parameters.AddWithValue("@kod", txt_urun_kodu.Text);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (txt_urun_kodu.Text == dr["UrunKodu"].ToString())
                {
                    kontrol++;
                }
            }
            baglanti.Close(); 
            if (kontrol == 0)
                urun_kayit();
            else
                MessageBox.Show("Bu Kodda Bir Ürün Bulunmaktadır.");
        }
        private void Form3_Shown(object sender, EventArgs e)
        {
            txt_urun_kodu.Focus();
        }
        private void metin()
        {
            anaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            this.Text = Localization.form3;
            lbl_FirmaAdi.Text = Localization.lbl_firmaadi;
            lbl_urun_kodu.Text = Localization.lbl_urunkodu;
            lbl_kayıt_tarihi.Text = Localization.lbl_kayit;
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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Management;
using System.Globalization;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.IO;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraExport;
using Stok_Programı.Faturalar;
namespace Stok_Programı
{
    public partial class Form8 : Form
    {      
        public Form8()
        {
            InitializeComponent();
        }
        DataSet ds;
        SqlDataAdapter da;
        SqlCommand komut;
        DatabaseConnection database;
        Fatura1 deneme1 = new Fatura1();
        Fatura2 deneme2=new Fatura2();
        Fatura3 deneme3 = new Fatura3();
        Fatura4 deneme4 = new Fatura4();
        Fatura5 deneme5 = new Fatura5();
        Fatura6 deneme6 = new Fatura6();
        Fatura7 deneme7 = new Fatura7();
        Rapor rapor1 = new Rapor();
        bool t1 = false;
        bool t2 = false;
        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
            database = new DatabaseConnection();
            database.Baglanti();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Properties.Settings.Default.tema;
            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                cmbx_yazici.Items.Add(yazici);
            }
            PrintDocument pd = new PrintDocument();
            string defaultPrinter = pd.PrinterSettings.PrinterName;
            cmbx_yazici.Text = defaultPrinter;
          
            if (Properties.Settings.Default.dil == "İngilizce")
            {
                temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            }
            metin();
            SqlDataReader dr;
            database.BaglantiAc();
            komut = new SqlCommand("select FirmaAdi from FirmaKayit", database.baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
                cmbx_firmaadi.Items.Add(dr["FirmaAdi"]);
            database.BaglantiKapat();
            baslangic_tarihi.Text = DateTime.Now.ToString();
            bitis_tarihi.Text = DateTime.Now.ToString();
            baslangic_tarihi.ShowCheckBox = true;
            baslangic_tarihi.Checked = false;
            bitis_tarihi.ShowCheckBox = true;
            bitis_tarihi.Checked = false;
            saat.BackColor = Color.White;
            tarih.BackColor = Color.White;
            tarih1.ShowCheckBox = true;
            tarih1.Checked = false;
            tarih2.ShowCheckBox = true;
            tarih2.Checked = false;
        }
        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }
        private void metin()
        {
            this.Text = Localization.form8;
            lbl_yazici.Text = Localization.yazici;
            anasayfaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            raporToolStripMenuItem.Text = Localization.rapor;
            lbl_baslangic.Text = Localization.tarih1;
            lbl_bitis.Text = Localization.tarih2;
            lbl_firma.Text = Localization.lbl_firmaadi;
            groupBox1.Text = Localization.filtre_araclari;
            fatura_goruntule.Text = Localization.fatura;
        }
        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.InitialDirectory = Application.StartupPath + "\\faturalar";
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.fatura = Path.GetFileName(opfd.FileName);
                Properties.Settings.Default.Save();
            }
        }
        private void girisF(DataSet ds)
        {
            if (baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1  ORDER BY GirisTarihi", database.baglanti);
            }
            else if (baslangic_tarihi.Checked==true & bitis_tarihi.Checked==true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 WHERE (GirisTarihi >= @baslangic AND GirisTarihi < @bitis) ORDER BY GirisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (baslangic_tarihi.Checked ==true  & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 WHERE (GirisTarihi >= @baslangic AND GirisTarihi < @bitis) ORDER BY GirisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if(baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 ORDER BY GirisTarihi", database.baglanti); 
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            database.BaglantiKapat();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                uretimgiris rapor = new uretimgiris();
                rapor.DataAdapter = da;
                rapor.DataSource = ds;
                rapor.xr_urunkodu.DataBindings.Add("Text", ds, "UrunKodu");
                rapor.xr_firmaadi.DataBindings.Add("Text", ds, "FirmaAdi");
                rapor.xr_urun_adet.DataBindings.Add("Text", ds, "UrunAdet");
                rapor.xr_personel_adi.DataBindings.Add("Text", ds, "Personel");
                rapor.xr_giris.DataBindings.Add("Text", ds, "GirisTarihi");
                rapor.DataMember = ((DataSet)rapor.DataSource).Tables[0].TableName;
               // rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimgirisS.repx");
                rapor.ShowPreview();
            }         
        }
        private void satisF(DataSet ds)
        {
            if (baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (CikisTarihi >= @baslangic AND CikisTarihi < @bitis)  ORDER BY CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (CikisTarihi >= @baslangic AND CikisTarihi < @bitis) ORDER BY CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis ORDER BY CikisTarihi", database.baglanti);
            }
            else if (baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis ORDER BY CikisTarihi", database.baglanti);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgi";
            database.BaglantiKapat();
            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                uretimcikis rapor2 = new uretimcikis();
                rapor2.DataAdapter = da;
                rapor2.DataSource = ds;
                rapor2.xr_kod.DataBindings.Add("Text", ds, "UrunKodu");
                rapor2.xr_firma.DataBindings.Add("Text", ds, "FirmaAdi");
                rapor2.xr_miktar.DataBindings.Add("Text", ds, "UrunAdet");
                rapor2.xr_satis.DataBindings.Add("Text", ds, "CikisTarihi");
                rapor2.xr_personel_adi.DataBindings.Add("Text", ds, "Personel");
                rapor2.DataMember = ((DataSet)rapor2.DataSource).Tables[0].TableName;
                //rapor2.LoadLayout(Application.StartupPath + "\\rapor\\uretimcikisS.repx");
                rapor2.ShowPreview();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tarih.Text = DateTime.Today.ToLongDateString();
            saat.Text = DateTime.Now.ToLongTimeString();
            düzenlenme.Text = DateTime.Now.ToString();
            timer1.Start();
        }
        private void temizle_Click(object sender, EventArgs e)
        {
            cmbx_firmaadi.Text = "";
            faturano.Text="";
            baslangic_tarihi.Checked = false;
            bitis_tarihi.Checked = false;
        }
        private void ssimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void scikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void stam_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void checkbox()
        {
            if(tarih1.Checked==false & tarih2.Checked==false)
            {
                t1 = false; t2 = false;
            }
            else if(tarih1.Checked==true & tarih2.Checked==false)
            {
                t1 = true; t2 = false;
            }
            else if (tarih1.Checked==false & tarih2.Checked==true)
            {
                t1 = false; t2 = true;
            }
            else
            {
                t1 = true; t2 = true;
            }
        }
        private void fatura_goruntule_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            switch (Properties.Settings.Default.fatura)
            {
                case "fatura.repx":
                    deneme1.sql(ds, cmbx_firmaadi.Text, faturano.Text);
                    break;
                case "tasarim7.repx":
                    deneme7.sql(ds, cmbx_firmaadi.Text, faturano.Text);
                    break;
                case "tasarim6.repx":
                    deneme6.sql(ds,cmbx_firmaadi.Text,faturano.Text);
                    break;
                case "tasarim4.repx":
                    deneme2.sablon(ds,cmbx_firmaadi.Text,faturano.Text);
                    break;
                case "tasarim3.repx":
                    deneme3.sql(ds,cmbx_firmaadi.Text,faturano.Text);
                    break;
                case "tasarim2.repx":
                    deneme4.sql(ds,cmbx_firmaadi.Text,faturano.Text);
                    break;
                case "tasarim1.repx":
                    deneme5.sql(ds,cmbx_firmaadi.Text,faturano.Text);
                    break;
                case "uretimgirisS.repx":
                    girisF(ds);
                    break;
                case "uretimcikisF":
                    satisF(ds);
                    break;
                default:
                    MessageBox.Show("Bir hata oluştu. Lütfen bir fatura şablonu seçip yeniden deneyin.","Bilgilendirme Penceresi");
                    break;
            }            
        }
        private void satisFaturası_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            database.BaglantiAc();
            komut = new SqlCommand("select FirmaAdi from FirmaKayit", database.baglanti);
           SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
                firmaadi.Items.Add(dr["FirmaAdi"]);
            database.BaglantiKapat();
            t_fno.Text = Properties.Settings.Default.faturano.ToString();
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            satisFaturasi yeni = new satisFaturasi();
            yeni.kayıt_ekle(firmaadi.Text,satistarihi.Text,düzenlenme.Text);
        }
        private void cmbx_firmaadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_firmaadi.SelectedIndex != -1)
            {
                faturano.Items.Clear();
                faturano.Text = "";
                database.Baglanti();
                database.BaglantiAc();
                komut = new SqlCommand("select * from Fatura where (FirmaAdi=@firma)", database.baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    faturano.Items.Add(dr["FaturaNo"]);
                }
                database.BaglantiKapat();
            }
        }
        private void s_goruntule_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            checkbox();
            if (Properties.Settings.Default.fatura == "rapor.repx")
                rapor1.sql(ds,tarih1.Text,tarih2.Text,t1,t2);
            else
                MessageBox.Show("Raporu Görüntüleyebilmeniz İçin Lütfen Önce Rapor Şablonunu Seçin.", "Bilgilendirme Penceresi");
        }
    }
}
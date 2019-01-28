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
        SqlConnection baglanti;
        SqlConnectionStringBuilder baglan = new SqlConnectionStringBuilder();
        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
            baglan.DataSource = Properties.Settings.Default.serverip;
            baglan.InitialCatalog = Properties.Settings.Default.veritabani;
            baglan.IntegratedSecurity = true;
            baglanti = new SqlConnection(baglan.ConnectionString);
            //baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
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

            baglanti.Open();
            SqlDataReader dr;
            SqlCommand komut = new SqlCommand("select UrunKodu from UrunKayit1", baglanti);
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                  cmbx_kodlar.Items.Add(dr["UrunKodu"]);
            }
            baglanti.Close();
            baglanti.Open();
            komut = new SqlCommand("select FirmaAdi from FirmaKayit", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
                cmbx_firmaadi.Items.Add(dr["FirmaAdi"]);
            baglanti.Close();
            baslangic_tarihi.Text = DateTime.Now.ToString();
            bitis_tarihi.Text = DateTime.Now.ToString();
            baslangic_tarihi.ShowCheckBox = true;
            baslangic_tarihi.Checked = false;
            bitis_tarihi.ShowCheckBox = true;
            bitis_tarihi.Checked = false;
            groupBox1.Location = new Point(this.ClientSize.Width / 2 - groupBox1.ClientSize.Width / 2, this.ClientSize.Height / 2 - groupBox1.ClientSize.Height / 2);
            groupBox1.Anchor = AnchorStyles.None;
            saat.BackColor = Color.White;
            tarih.BackColor = Color.White;
        }
        private static ManagementScope oManagementScope = null;              
        public static bool yazici_ekle(string sPrinterName)
        {
            try
            {
                oManagementScope = new ManagementScope(ManagementPath.DefaultPath);
                oManagementScope.Connect();
                ManagementClass oPrinterClass = new ManagementClass(new ManagementPath("Win32_Printer"), null);
                ManagementBaseObject oInputParameters = oPrinterClass.GetMethodParameters("AddPrinterConnection");
                oInputParameters.SetPropertyValue("Name", sPrinterName);
                oPrinterClass.InvokeMethod("AddPrinterConnection", oInputParameters, null);
                MessageBox.Show("başarılı");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private void btn_yazici_ekle_Click(object sender, EventArgs e)
        {
            string sPrinterName="abc";
            yazici_ekle(sPrinterName);
            cmbx_yazici.Items.Clear();
            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                cmbx_yazici.Items.Add(yazici);
            }
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
            lbl_kod.Text = Localization.filtrekod;
            groupBox1.Text = Localization.filtre_araclari;
            btn_yazici_ekle.Text = Localization.y_ekle;
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
            if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 WHERE (UrunKodu=@kod)  ORDER BY GirisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            else if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked==true & bitis_tarihi.Checked==true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 WHERE (GirisTarihi >= @baslangic AND GirisTarihi < @bitis) ORDER BY GirisTarihi", baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked ==true  & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 WHERE (UrunKodu=@kod) AND (GirisTarihi >= @baslangic AND GirisTarihi < @bitis) ORDER BY GirisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if(cmbx_kodlar.Text=="" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 ORDER BY GirisTarihi", baglanti); 
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

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
            if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (UrunKodu=@kod) AND (CikisTarihi >= @baslangic AND CikisTarihi < @bitis)  ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (CikisTarihi >= @baslangic AND CikisTarihi < @bitis) ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (UrunKodu=@kod) ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            else if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis ORDER BY CikisTarihi", baglanti);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgi";
            baglanti.Close();
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
        private void tasarim1_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.Personel,FirmaKayit.Sehir,FirmaKayit.ilce,
                FirmaKayit.Adres,FirmaKayit.SorumluAdi,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=@firma)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim1(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.Personel,FirmaKayit.Sehir,FirmaKayit.ilce,
                FirmaKayit.Adres,FirmaKayit.SorumluAdi,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim1(ds);
            }      
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarih filtrelemesi yapılmamaktadır, filtreleme yapılabilmesi için Firma Adı alanını boş bırakmamalısınız. Kontrol edip yeniden deneyiniz..",
                    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim1(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal a = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.","Bilgilendirme Penceresi");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[10]);
                }
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                tasarim fatura = new tasarim();
                fatura.DataAdapter = da;
                fatura.DataSource = ds;
                fatura.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura.invoiceDate.Text = DateTime.Now.ToString();
                fatura.ilce.DataBindings.Add("Text", ds, "ilce");
                fatura.sehir.DataBindings.Add("Text", ds, "Sehir");
                fatura.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura.total.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura.invoiceNumber.Text = Properties.Settings.Default.faturano.ToString();
                fatura.customerContactName.DataBindings.Add("Text", ds, "SorumluAdi");
                fatura.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                fatura.DataMember = ((DataSet)fatura.DataSource).Tables[0].TableName;
                fatura.ShowPreview();
            }  
        }
        private void tasarim2_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text!="" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)
                AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim2(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false) 
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)
                AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim2(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarihe göre filtreleme yapılmamaktadır. Filtrelemenin doğru bir şekilde yapılabilmesi için Firma Adı alanını boş bırakmayınız.",
                    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim2(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal fiyat = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    fiyat += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                //Properties.Settings.Default.faturano = 0;
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                tasarim2 fatura2 = new tasarim2();
                fatura2.DataAdapter = da;
                fatura2.DataSource = ds;
                fatura2.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura2.invoiceDate.Text = DateTime.Now.ToString();
                //fatura2.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura2.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura2.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura2.invoiceNumber.Text = Properties.Settings.Default.faturano.ToString();
                fatura2.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura2.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura2.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura2.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura2.DataMember = ((DataSet)fatura2.DataSource).Tables[0].TableName;
                fatura2.ShowPreview();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tarih.Text = DateTime.Today.ToLongDateString();
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void tasarim3_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text!="" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)
                AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim3(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit 
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim3(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                tasarim3(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                tasarim3(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde işlem yapabilmek için Firma Adı alanı boş bırakılmamalıdır, tarihe göre filtreleme yapılmak isteniyorsa Başlangıç Tarihi ve Bitiş Tarihi alanları aynı anda işaretlenmelidir.",
    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim3(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal fiyat = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    fiyat += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                tasarim3 fatura3 = new tasarim3();
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura3.DataAdapter = da;
                fatura3.DataSource = ds;
                fatura3.invoiceDate.Text = DateTime.Now.ToString();
                fatura3.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura3.total2.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura3.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura3.unitPrice.DataBindings.Add("Text",ds,"BirimFiyati");
                fatura3.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura3.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura3.firmail.DataBindings.Add("Text", ds, "Sehir");
                fatura3.firmailce.DataBindings.Add("Text", ds, "ilce");
                fatura3.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura3.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura3.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura3.invoiceNumber.Text = Properties.Settings.Default.faturano.ToString();
                fatura3.DataMember = ((DataSet)fatura3.DataSource).Tables[0].TableName;
                fatura3.ShowPreview();
            }
        }
        private void tasarim4_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text!="")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit 
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim4(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text!="")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo,UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim4(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarihe göre filtreleme yapılmamaktadır. Filtrelemenin doğru bir şekilde yapılabilmesi için Firma Adı alanını boş bırakmayınız.",
                    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim4(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal fiyat = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    fiyat += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                tasarim4 fatura4 = new tasarim4();
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura4.DataAdapter = da;
                fatura4.DataSource = ds;
                fatura4.productDescription.DataBindings.Add("Text", ds, "UrunKodu");
                fatura4.invoiceDate.Text = DateTime.Now.ToShortDateString();
                fatura4.saat.Text = DateTime.Now.ToShortTimeString();
                fatura4.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura4.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura4.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura4.customerTown.DataBindings.Add("Text", ds, "ilce");
                fatura4.customerCity.DataBindings.Add("Text", ds, "Sehir");
                fatura4.customerTel.DataBindings.Add("Text", ds, "TelefonNo");
                fatura4.total2.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura4.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura4.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura4.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura4.invoiceNumber.Text = Properties.Settings.Default.faturano.ToString();
                fatura4.DataMember = ((DataSet)fatura4.DataSource).Tables[0].TableName;
              //  fatura4.LoadLayout(Application.StartupPath + "\\faturalar\\tasarim4.repx");
                fatura4.ShowPreview();
                //fatura4.ShowDesigner();
                //fatura4.SaveLayout(Application.StartupPath + "\\faturalar");
            }
        }
        private void tasarim6_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text!="" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.ilce,FirmaKayit.Sehir,UrunCikis.BirimFiyati   
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim6(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.ilce,FirmaKayit.Sehir,UrunCikis.BirimFiyati   
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                tasarim6(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.ilce,FirmaKayit.Sehir,UrunCikis.BirimFiyati   
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                tasarim6(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.ilce,FirmaKayit.Sehir,UrunCikis.BirimFiyati   
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis) AND (UrunCikis.UrunKodu=@kod)", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                tasarim6(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde işlem yapabilmek için Firma Adı alanı boş bırakılmamalıdır, tarihe göre filtreleme yapılmak isteniyorsa Başlangıç Tarihi ve Bitiş Tarihi alanları aynı anda işaretlenmelidir.",
                    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim6(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal a = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                tasarim6 fatura5 = new tasarim6();
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura5.DataAdapter = da;
                fatura5.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 1)
                    fatura5.invoiceDueDateRow.Visible = true;
                else
                    fatura5.invoiceDueDateRow.Visible = false;
                fatura5.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura5.invoiceDate.Text = DateTime.Now.ToString();
                fatura5.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura5.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura5.productDescription.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura5.ilce.DataBindings.Add("Text", ds, "ilce");
                fatura5.sehir.DataBindings.Add("Text",ds,"Sehir");
                fatura5.unitPrice.DataBindings.Add("Text",ds,"BirimFiyati");
                fatura5.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura5.total.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura5.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura5.invoiceNumber.Text = Properties.Settings.Default.faturano.ToString();
                fatura5.DataMember = ((DataSet)fatura5.DataSource).Tables[0].TableName;
                fatura5.ShowPreview();
            }
        }
        private void tasarim7_F(DataSet ds)
        {
            if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text!="" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo, UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi<@bitis)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                tasarim7(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo, UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                tasarim7(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo, UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi>@baslangic)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                tasarim7(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo, UrunCikis.BirimFiyati 
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma)
                AND (UrunCikis.CikisTarihi<@bitis)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                tasarim7(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde işlem yapabilmek için Firma Adı ve tarih alanı boş bırakılmamalıdır, tarihe göre filtreleme yapılması için Başlangıç Tarihi ve Bitiş Tarihi alanları aynı anda işaretlenmemelidir.",
    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim7(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal fiyat = 0;
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for(int i=0; i<ds.Tables[0].Rows.Count;i++)
                {
                    fiyat+=Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                tasarim7 fatura5 = new tasarim7();
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura5.DataAdapter = da;
                fatura5.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 1)
                    fatura5.invoiceDueDateRow.Visible = true;
                else
                    fatura5.invoiceDueDateRow.Visible = false;
                fatura5.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura5.invoiceDate.Text = DateTime.Now.ToString();
                fatura5.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura5.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura5.productDescription.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura5.customerTown.DataBindings.Add("Text", ds, "ilce");
                fatura5.customerCity.DataBindings.Add("Text", ds, "Sehir");
                fatura5.customerPhone.DataBindings.Add("Text", ds, "TelefonNo");
                fatura5.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura5.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura5.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura5.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura5.faturano.Text = Properties.Settings.Default.faturano.ToString();
                fatura5.DataMember = ((DataSet)fatura5.DataSource).Tables[0].TableName;
                fatura5.ShowPreview(); ;
            }
        }
        private void fatura1(DataSet ds)
        {
            if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.UrunKodu=@kod) ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.UrunKodu=@kod) 
                AND (UrunCikis.CikisTarihi>@baslangic)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.CikisTarihi>@baslangic)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.CikisTarihi<@bitis)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.CikisTarihi<@bitis) AND (UrunCikis.UrunKodu=@kod)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text == "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                fatura_olustur(ds);
            }
            else if (cmbx_kodlar.Text != "" & cmbx_firmaadi.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat
                FROM UrunCikis,FirmaKayit
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.UrunKodu=@kod) AND (UrunCikis.CikisTarihi>@baslangic) AND (UrunCikis.CikisTarihi<@bitis)
                ORDER BY UrunCikis.CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                fatura_olustur(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Filtreleme yapabilmeniz için Firma Adı seçimi yapmanız gerekmektedir..Gerekli alanları kontrol edip tekrar deneyiniz..", "Bilgilendirme Penceresi");
            }
        }
        private void fatura_olustur(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();
            decimal a = 0;
            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[11]);
                }
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura fatura1 = new fatura();
                fatura1.DataAdapter = da;
                fatura1.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 1)
                    fatura1.invoiceduedaterow.Visible = true;
                else
                    fatura1.invoiceduedaterow.Visible = false;
                fatura1.faturano.Text = Properties.Settings.Default.faturano.ToString();
                fatura1.faturatarih.Text = DateTime.Now.ToString();
                fatura1.satistarih.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura1.firmaadi.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura1.firmaadres.DataBindings.Add("Text", ds, "Adres");
                fatura1.firmail.DataBindings.Add("Text", ds, "Sehir");
                fatura1.firmailce.DataBindings.Add("Text", ds, "ilce");
                fatura1.urunadi.DataBindings.Add("Text", ds, "UrunKodu");
                fatura1.miktar.DataBindings.Add("Text", ds, "UrunAdet");
                fatura1.vergi.DataBindings.Add("Text", ds, "VergiDairesiAdi");
                fatura1.mersis.DataBindings.Add("Text", ds, "MersisNo");
                fatura1.birimfiyat.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura1.tutar.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura1.toplam.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura1.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura1.DataMember = ((DataSet)fatura1.DataSource).Tables[0].TableName;
               // fatura1.LoadLayout(Application.StartupPath + "\\faturalar\\fatura2.prnx");
                fatura1.ShowPreview();
            }
        }
        private void rapor(DataSet ds)
        {
            if(cmbx_firmaadi.Text=="" & cmbx_kodlar.Text=="" & baslangic_tarihi.Checked==false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis ORDER BY FirmaAdi", baglanti);
                rapor_olustur(ds);
            }
            else if(cmbx_firmaadi.Text=="" & cmbx_kodlar.Text=="" & baslangic_tarihi.Checked==true & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE CikisTarihi>@baslangic ORDER BY FirmaAdi", baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                rapor_olustur(ds);
            }
            else if (cmbx_firmaadi.Text == "" & cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE CikisTarihi<@bitis ORDER BY FirmaAdi", baglanti);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                rapor_olustur(ds);
            }
            else if (cmbx_firmaadi.Text == "" & cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE (CikisTarihi>@baslangic) AND (CikisTarihi<@bitis) ORDER BY FirmaAdi", baglanti);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                rapor_olustur(ds);
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Ürünlerin satış raporunu görüntülenmek için Firma Adı alanı ve Filtrelenen Kod alanı boş bırakılmalıdır. Kontrol edip yeniden deneyiniz.", "Bilgilendirme Penceresi");
            }
        }
        private void rapor_olustur(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();
            decimal a = 0;
            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[9]);
                }
                Properties.Settings.Default.raporno++;
                Properties.Settings.Default.Save();
                fatura fatura1 = new fatura();
                fatura1.DataAdapter = da;
                fatura1.DataSource = ds;
                fatura1.faturano.Text = Properties.Settings.Default.raporno.ToString();
                fatura1.faturatarih.Text = DateTime.Now.ToString();
                fatura1.urunadi.DataBindings.Add("Text", ds, "UrunKodu");
                fatura1.miktar.DataBindings.Add("Text", ds, "UrunAdet");
                fatura1.firma.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura1.xrTable3.Visible = false;
                fatura1.xrTable4.Visible = false;
                fatura1.invoiceduedaterow.Visible = false;
                fatura1.islembicimi.Text = "SATIŞ RAPORU";
                fatura1.islemno.Text = "RAPOR NO#";
                fatura1.xrTableCell23.Visible = false;
                fatura1.xrTableCell25.Visible = false;
                fatura1.xrTableCell27.Visible = false;
                fatura1.xrTableCell21.Text = "DÜZENLEYEN PERSONEL";
                fatura1.birimfiyat.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura1.tutar.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura1.toplam.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura1.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura1.DataMember = ((DataSet)fatura1.DataSource).Tables[0].TableName;
                fatura1.ShowPreview();
            }
        }
        private void temizle_Click(object sender, EventArgs e)
        {
            cmbx_firmaadi.Text = "";
            cmbx_kodlar.Text = "";
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
        private void fatura_goruntule_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            switch (Properties.Settings.Default.fatura)
            {
                case "fatura.repx":
                    fatura1(ds);
                    break;
                case "rapor.repx":
                    rapor(ds);
                    break;
                case "tasarim7.repx":
                    tasarim7_F(ds);
                    break;
                case "tasarim6.repx":
                    tasarim6_F(ds);
                    break;
                case "tasarim4.repx":
                    tasarim4_F(ds);
                    break;
                case "tasarim3.repx":
                    tasarim3_F(ds);
                    break;
                case "tasarim2.repx":
                    tasarim2_F(ds);
                    break;
                case "tasarim1.repx":
                    tasarim1_F(ds);
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
    }
}
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
        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
            baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Properties.Settings.Default.tema;
            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                cmbx_yazici.Items.Add(yazici);
            }
            PrintDocument pd = new PrintDocument();
            string defaultPrinter = pd.PrinterSettings.PrinterName;
            cmbx_yazici.Text = defaultPrinter;

            btn_simge.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\simge.fw.png");
            btn_tamekran.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\tamekran.fw.png");
            btn_cikiss.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\cikis.fw.png");

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
                Localization.Culture = new CultureInfo("en-US");
            else if (Properties.Settings.Default.dil == "Türkçe")
                Localization.Culture = new CultureInfo("");
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
            baslangic_tarihi.ShowCheckBox = true;
            baslangic_tarihi.Checked = false;

            bitis_tarihi.ShowCheckBox = true;
            bitis_tarihi.Checked = false;
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
            Application.Exit();
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
        }
        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private DataSet uruncikis()
        {
            DataSet veri = new DataSet();
          
            baglanti.Open();

            //SqlCommand komut = new SqlCommand("select FirmaAdi,UrunKodu,CikisTarihi,UrunAdet from UretimCikis where UrunKodu=@kod",baglanti);
           // komut.Parameters.AddWithValue("@kod", txt_kod.Text);
              //komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
              //komut.Parameters.AddWithValue("@tarih1", dateTimePicker2.Text);

            da = new SqlDataAdapter("SELECT FirmaAdi,UrunKodu,CikisTarihi,UrunAdet from UretimCikis WHERE UrunKodu='" + cmbx_yazici.Text + "' ", baglanti);
            da.Fill(veri);
            baglanti.Close();
            
            return veri;            
        }

        private void sbtn_giris_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo_alanlari");
            baglanti.Open();
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
                cmbx_kodlar.Text = "";
                rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimgirisS.repx");
                rapor.ShowPreview();
            }
          
        }
        private void sbtn_giris_duzenle_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo_alanlari");
            baglanti.Open();
            if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked==false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi,Personel FROM UrunGiris1 ORDER BY GirisTarihi", baglanti);
                da = new SqlDataAdapter(komut);
                da.Fill(ds);
                ds.Tables[0].TableName = "bilgiler";
                baglanti.Close();

                uretimgiris rapor = new uretimgiris();
                rapor.DataAdapter = da;
                rapor.DataSource = ds;
                rapor.xr_urunkodu.DataBindings.Add("Text", ds, "UrunKodu");
                rapor.xr_firmaadi.DataBindings.Add("Text", ds, "FirmaAdi");
                rapor.xr_urun_adet.DataBindings.Add("Text", ds, "UrunAdet");
                rapor.xr_personel_adi.DataBindings.Add("Text", ds, "Personel");
                rapor.xr_giris.DataBindings.Add("Text", ds, "GirisTarihi");
                rapor.DataMember = ((DataSet)rapor.DataSource).Tables[0].TableName;
                rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimgirisS.repx");
                cmbx_kodlar.Text = "";
                rapor.ShowDesigner();
            }
            else
                MessageBox.Show("Rapor şablonunda değişiklik yapabilmeniz için gerekli alanların boş olması gerekmektedir.");
        }
        private void sbtn_satis_Click(object sender, EventArgs e)
        {
            ds = new DataSet("tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (UrunKodu=@kod) AND (CikisTarihi >= @baslangic AND CikisTarihi < @bitis)  ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked==true & bitis_tarihi.Checked==true )
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis WHERE (CikisTarihi >= @baslangic AND CikisTarihi < @bitis) ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                //komut.Parameters.AddWithValue("@adet", int.Parse(txt_adet.Text));
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
                cmbx_kodlar.Text = "";
                rapor2.LoadLayout(Application.StartupPath + "\\rapor\\uretimcikisS.repx");
                rapor2.ShowPreview();
            }

        }
        private void sbtn_satis_düzenle_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text == "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi,Personel FROM UrunCikis ORDER BY CikisTarihi", baglanti);
                da = new SqlDataAdapter(komut);
                da.Fill(ds);
                ds.Tables[0].TableName = "bilgi";
                baglanti.Close();

                uretimcikis rapor2 = new uretimcikis();
                rapor2.DataAdapter = da;
                rapor2.DataSource = ds;
                rapor2.xr_kod.DataBindings.Add("Text", ds, "UrunKodu");
                rapor2.xr_firma.DataBindings.Add("Text", ds, "FirmaAdi");
                rapor2.xr_miktar.DataBindings.Add("Text", ds, "UrunAdet");
                rapor2.xr_satis.DataBindings.Add("Text", ds, "CikisTarihi");
                rapor2.xr_personel_adi.DataBindings.Add("Text", ds, "Personel");
                rapor2.DataMember = ((DataSet)rapor2.DataSource).Tables[0].TableName;
                cmbx_kodlar.Text = "";
                rapor2.LoadLayout(Application.StartupPath + "\\rapor\\uretimcikisS.repx");
                rapor2.ShowDesigner();
            }
            else
                MessageBox.Show("Rapor şablonunda değişiklik yapabilmeniz için gerekli alanların boş olması gerekmektedir.");
        }

        private void ssatis_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked == true & bitis_tarihi.Checked == true)
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.Personel,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.Adres,FirmaKayit.SorumluAdi FROM UrunCikis,FirmaKayit WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.CikisTarihi>=@baslangic and UrunCikis.CikisTarihi<@bitis)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
                // komut.Parameters.AddWithValue("@ad", xrLabel1.Text);
            }
                da = new SqlDataAdapter(komut);
                da.Fill(ds);
                ds.Tables[0].TableName = "bilgiler";
                baglanti.Close();

                if (ds.Tables[0].Rows.Count == 0)
                    MessageBox.Show("Ürün Bulunmamaktadır.");
                else
                {
                    tasarim fatura = new tasarim();
                    fatura.DataAdapter = da;
                    fatura.DataSource = ds;
                    fatura.productName.Text = cmbx_kodlar.Text;
                    //  fatura.xrpersonel.DataBindings.Add("Text", ds, "Personel");
                    fatura.invoiceDate.DataBindings.Add("Text", ds, "CikisTarihi");
                    fatura.customerCity.DataBindings.Add("Text", ds, "Sehir");
                    // fatura.xr_firmailce.DataBindings.Add("Text", ds, "ilce");
                    fatura.customerAddress.DataBindings.Add("Text", ds, "Adres");
                    fatura.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                    fatura.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                    fatura.customerContactName.DataBindings.Add("Text", ds, "SorumluAdi");
                    fatura.DataMember = ((DataSet)fatura.DataSource).Tables[0].TableName;
                    //fatura.ShowDesigner();
                    fatura.ShowPreview();
                }

            
        }

        private void S2_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "" & baslangic_tarihi.Checked == false & bitis_tarihi.Checked == false)
            {
                komut = new SqlCommand(@"SELECT FirmaAdi,UrunAdet,CikisTarihi FROM UrunCikis WHERE UrunKodu=@kod", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                tasarim2 fatura2 = new tasarim2();
                fatura2.DataAdapter = da;
                fatura2.DataSource = ds;
                fatura2.productName.Text = cmbx_kodlar.Text;
                fatura2.invoiceDate.Text = DateTime.Now.ToString();
                fatura2.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura2.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura2.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura2.DataMember = ((DataSet)fatura2.DataSource).Tables[0].TableName;
                //fatura.ShowDesigner();
                fatura2.ShowPreview();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void S3_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres FROM UrunCikis,FirmaKayit WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            else if (cmbx_kodlar.Text=="")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres FROM UrunCikis,FirmaKayit WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                tasarim3 fatura3 = new tasarim3();
                fatura3.DataAdapter = da;
                fatura3.DataSource = ds;
                fatura3.productDescription.DataBindings.Add("Text", ds, "UrunKodu");
                fatura3.invoiceDate.Text = DateTime.Now.ToString();
                fatura3.invoiceDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura3.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura3.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura3.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura3.DataMember = ((DataSet)fatura3.DataSource).Tables[0].TableName;
                //fatura.ShowDesigner();
                fatura3.ShowPreview();
            }

        }

        private void S4_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo FROM UrunCikis,FirmaKayit WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            else if (cmbx_kodlar.Text == "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo FROM UrunCikis,FirmaKayit WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                tasarim4 fatura4 = new tasarim4();
                fatura4.DataAdapter = da;
                fatura4.DataSource = ds;
                fatura4.productDescription.DataBindings.Add("Text", ds, "UrunKodu");
                fatura4.invoiceDate.Text = DateTime.Now.ToString();
                fatura4.invoiceDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura4.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura4.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura4.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura4.customerTown.DataBindings.Add("Text",ds,"ilce");
                fatura4.customerCity.DataBindings.Add("Text", ds, "Sehir");
                fatura4.customerTel.DataBindings.Add("Text", ds, "TelefonNo");
                fatura4.DataMember = ((DataSet)fatura4.DataSource).Tables[0].TableName;
                //fatura4.ShowDesigner();
                fatura4.ShowPreview();
            }
        }

        private void S5_Click(object sender, EventArgs e)
        {
            ds = new DataSet("Tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi FROM UrunCikis,FirmaKayit WHERE (UrunCikis.UrunKodu=@kod) AND (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            }
            else if (cmbx_kodlar.Text == "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo FROM UrunCikis,FirmaKayit WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi)", baglanti);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                tasarim5 fatura5 = new tasarim5();
                fatura5.DataAdapter = da;
                fatura5.DataSource = ds;
                fatura5.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura5.invoiceDate.Text = DateTime.Now.ToString();
                fatura5.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura5.productDescription.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.DataMember = ((DataSet)fatura5.DataSource).Tables[0].TableName;
                fatura5.ShowPreview();
            }
        }
    }
}

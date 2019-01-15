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
        private void Form8_Load(object sender, EventArgs e)
        {
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
            SqlCommand komut = new SqlCommand("select UrunKodu from UrunGiris", baglanti);
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                  cmbx_kodlar.Items.Add(dr["UrunKodu"]);
            }
            baglanti.Close();
            baslangic_tarihi.Value = DateTime.Now;
           // bitis_tarihi.Text = DateTime.Now.ToString();
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
        private XtraReport1 rapor = new XtraReport1();

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rapor.LoadLayout(Application.StartupPath + "\\uruncikis.repx");
            //rapor.DataSource = uruncikis();
           // rapor.ShowDesigner();
           uretimcikis rapor1 = new uretimcikis();
            rapor1.ShowPreview();
           
        }
        SqlConnection baglanti;
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
            if(cmbx_kodlar.Text!="")
          {
            komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi FROM UrunGiris1 WHERE (UrunKodu=@kod) AND (GirisTarihi >= @baslangic AND GirisTarihi < @bitis)", baglanti);
            komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
            komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
            komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if(cmbx_kodlar.Text=="")
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,GirisTarihi FROM UrunGiris1 WHERE (GirisTarihi >= @baslangic AND GirisTarihi < @bitis)", baglanti);
               // komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            baglanti.Close();           

            uretimgiris rapor = new uretimgiris();
            rapor.DataAdapter = da;
            rapor.DataSource = ds;
            rapor.DataMember = ((DataSet)rapor.DataSource).Tables[0].TableName;
            //rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimgiris.repx");
            cmbx_kodlar.Text = "";
            rapor.ShowPreview();
          
        }

        private void sbtn_giris_duzenle_Click(object sender, EventArgs e)
        {
            uretimgiris rapor = new uretimgiris();
          
           // rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimgiris.repx");
            rapor.ShowDesigner();
        }

        private void sbtn_satis_Click(object sender, EventArgs e)
        {
            ds = new DataSet("tablo");
            baglanti.Open();
            if (cmbx_kodlar.Text != "")
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi FROM UrunCikis WHERE (UrunKodu=@kod) AND (CikisTarihi >= @baslangic AND CikisTarihi < @bitis)", baglanti);
                komut.Parameters.AddWithValue("@kod", cmbx_kodlar.Text);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            else if(cmbx_kodlar.Text=="")
            {
                komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,UrunAdet,CikisTarihi FROM UrunCikis WHERE (CikisTarihi >= @baslangic AND CikisTarihi < @bitis) ORDER BY CikisTarihi", baglanti);
                komut.Parameters.AddWithValue("@baslangic", baslangic_tarihi.Value);
                komut.Parameters.AddWithValue("@bitis", bitis_tarihi.Value);
            }
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgi";
            baglanti.Close();

            uretimcikis rapor2 = new uretimcikis();
            rapor2.DataAdapter = da;
            rapor2.DataSource = ds;
            rapor2.DataMember = ((DataSet)rapor2.DataSource).Tables[0].TableName;
            cmbx_kodlar.Text = "";
          //  rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimcikis.repx");
            rapor2.ShowPreview();
        }

        private void sbtn_satis_düzenle_Click(object sender, EventArgs e)
        {
            uretimcikis rapor = new uretimcikis();
         //   rapor.LoadLayout(Application.StartupPath + "\\rapor\\uretimcikis.repx");
            rapor.ShowDesigner();
        }
    }
}

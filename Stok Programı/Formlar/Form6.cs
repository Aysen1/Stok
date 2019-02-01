using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Management;

namespace Stok_Programı
{
    public partial class Form6 : Form
    {
        DatabaseConnection database;
        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            database = new DatabaseConnection();
            database.Baglanti();
            this.BackColor = Properties.Settings.Default.tema;
            Properties.Settings.Default.Save();
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            pctrbx_logo.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\logo.jpeg");

            tarih.Text = DateTime.Today.ToLongDateString();
            if (Properties.Settings.Default.dil == "İngilizce")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                btn_giris.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\urungirisK.fw.png");
                btn_cikis.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\uruncikisK.fw.png");
                btn_urun.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\ukayitK.fw.png");
                btn_firma.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\firmaK.fw.png");
                btn_stok.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\stokK.fw.png");
                btn_araclar.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\araclarK.fw.png");
                btn_ayarlar.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\ayarlarK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                btn_giris.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\urungiris.fw.png");
                btn_cikis.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\uruncikis.fw.png");
                btn_urun.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\ukayit.fw.png");
                btn_firma.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\firma.fw.png");
                btn_stok.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\stok.fw.png");
                btn_araclar.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\araclar.fw.png");
                btn_ayarlar.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\ayarlar.fw.png");
            }
            metin();
            tarih.BackColor = Color.White;
            saat.BackColor = Color.White;
        }
        private void btn_urun_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        private void btn_firma_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();       
        }
        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
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
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void btn_araclar_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
        private void btn_stok_Click(object sender, EventArgs e)
        {
            database.BaglantiAc();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunID,FirmaAdi,UrunKodu,KayitTarihi,UrunResim,ToplamAdet,Personel,FORMAT(BirimFiyati,'n2')+space(1)+NCHAR(8378) from UrunKayit1", database.baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string data = null;

            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
            wb = xl.Workbooks.Add(System.Windows.Forms.Application.StartupPath + "\\exceldosyalari\\stok.xls");
            Microsoft.Office.Interop.Excel.Worksheet ws = default(Microsoft.Office.Interop.Excel.Worksheet);
            ws = wb.Worksheets.get_Item(1);

            for (int i = 2; i <= ds.Tables[0].Rows.Count +1; i++)
            {
                for (int j = 2; j <= ds.Tables[0].Columns.Count+1 ; j++)
                {
                    data = ds.Tables[0].Rows[i-2].ItemArray[j-2].ToString();
                    ws.Cells[i , j -1] = data;
                    ws.Cells[i, j - 1].ColumnWidth = 20;
                }
            }
            database.BaglantiKapat();
            xl.Visible = true;
        }
        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }
        private void metin()
        {
            this.Text = Localization.form6; 
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
            Form1 form1 = new Form1();
            form1.Show();
            this.Dispose();
            //System.Windows.Forms.Application.Exit();
        }
    }
}
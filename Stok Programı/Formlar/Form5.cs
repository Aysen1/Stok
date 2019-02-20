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
    public partial class Form5 : Form
    {
        SqlCommand komut;
        SqlDataReader dr;
        DatabaseConnection database;
        public Form5()
        {
            InitializeComponent();
        }
        private void firma_listele()
        {
            database.BaglantiAc();
            komut = new SqlCommand();
            komut.Connection = database.baglanti;       
            komut.CommandText = "select * from FirmaKayit";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbx_firmaadi.Items.Add(dr["FirmaAdi"]);
            }
            database.BaglantiKapat();
        }
        private void urun_listele()
        {
            database.BaglantiAc();
            komut = new SqlCommand();
            komut.Connection = database.baglanti; 
            komut.CommandText = "select * from UrunKayit1";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbx_urunadi.Items.Add(dr["UrunKodu"]);
            }
            database.BaglantiKapat();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            database = new DatabaseConnection();
            database.Baglanti();
            this.BackColor = Properties.Settings.Default.tema;
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            tarih.Text = DateTime.Today.ToLongDateString();

            //baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            firma_listele();
            urun_listele();
            pctrbx_resim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");

            if (Properties.Settings.Default.dil == "İngilizce")
            {
              //  Localization.Culture = new CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydetK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
               // Localization.Culture = new CultureInfo("");
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydet.fw.png");
            }
            metin();
            tarih.BackColor = Color.White;
            saat.BackColor = Color.White;            
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            cmbx_firmaadi.Text = "";
            cmbx_urunadi.Text = "";
            txt_adet.Text = "";
            pctrbx_resim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");
        }
        private void cmbx_urunadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            database.BaglantiAc();
            komut = new SqlCommand();
            komut.Connection = database.baglanti;
            komut.CommandText = "SELECT UrunKayit1.UrunResim,UrunCikis.BirimFiyati FROM UrunKayit1,UrunCikis WHERE (UrunKayit1.UrunKodu=@kod) AND (UrunCikis.UrunID=UrunKayit1.UrunID)";
            komut.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Stream stream = dr.GetStream(0);
                pctrbx_resim.Image = Image.FromStream(stream);
                txt_birim_fiyati.Text = string.Format("{0:###,###.00}", dr["BirimFiyati"]); //Textboxa gelen değeri varsayılan para birimine dönüştürerek yazıyor.
            }
            database.BaglantiKapat(); 
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (cmbx_firmaadi.Text != "" & cmbx_urunadi.Text != "" & txt_adet.Text != "" & txt_birim_fiyati.Text!="")
            {
                database.BaglantiAc();
                string UrunID=null;
                decimal fiyat=0;
                int adet=int.Parse(txt_adet.Text);
                SqlCommand komut3 = new SqlCommand("select * from UrunKayit1 where UrunKodu=@kod", database.baglanti);
                komut3.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
                dr = komut3.ExecuteReader();
                if (dr.Read())
                {
                    if (int.Parse(txt_adet.Text) <= int.Parse(dr[5].ToString()) & int.Parse(dr[5].ToString()) != 0)
                    {
                        UrunID = dr["UrunID"].ToString();
                       // fiyat=Convert.ToDecimal(dr["BirimFiyati"]);
                        fiyat=Convert.ToDecimal(txt_birim_fiyati.Text);
                        database.BaglantiKapat();

                        database.BaglantiAc();
                        komut = new SqlCommand();
                        komut.Connection = database.baglanti;
                        komut.CommandText = "insert into UrunCikis (UrunID, FirmaAdi, UrunKodu, CikisTarihi, UrunAdet, Personel, BirimFiyati, ToplamFiyat) VALUES ('"+UrunID+"','" + cmbx_firmaadi.Text + "','" + cmbx_urunadi.Text + "','" + dateTimePicker1.Text+ "','" + txt_adet.Text + "',@personel,@birimfiyat,@toplam)";
                        komut.Parameters.AddWithValue("@personel", Properties.Settings.Default.kullaniciadi);
                        komut.Parameters.AddWithValue("@birimfiyat", fiyat);
                        komut.Parameters.AddWithValue("@toplam", fiyat * adet);
                         komut.ExecuteNonQuery();
                        database.BaglantiKapat();

                        database.BaglantiAc();
                        SqlCommand komut2 = new SqlCommand();
                        komut2.Connection = database.baglanti;
                        komut2.CommandText = "update UrunKayit1 set ToplamAdet=ToplamAdet-@miktar where UrunKodu=@kod";
                        komut2.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
                        komut2.Parameters.AddWithValue("@miktar", int.Parse(txt_adet.Text));
                        komut2.ExecuteNonQuery();
                        database.BaglantiKapat();
                        
                        MessageBox.Show("Kayıt Başarılı.");
                    }
                    else
                    { 
                        MessageBox.Show("Stokta yeterli ürün yok!");
                        database.BaglantiKapat();
                    }
                }
            }
            else
            {
                MessageBox.Show("Kayıt Gerçekleştirilemedi.Tekrar Deneyiniz.");
            }
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Close();
            form6.Show();
        }
        private void Form5_Shown(object sender, EventArgs e)
        {
            cmbx_firmaadi.Focus();
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database.BaglantiAc();
            SqlDataAdapter da = new SqlDataAdapter("Select CikisID,UrunID,FirmaAdi,UrunKodu,CikisTarihi,UrunAdet,Personel,FORMAT(BirimFiyati,'n2')+space(1)+NCHAR(8378),FORMAT(ToplamFiyat,'n2')+space(1)+NCHAR(8378) from UrunCikis", database.baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string data = null;

            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
            wb = xl.Workbooks.Add(Application.StartupPath+"\\exceldosyalari\\uruncikis.xls");
            Microsoft.Office.Interop.Excel.Worksheet ws = default(Microsoft.Office.Interop.Excel.Worksheet);
            ws = wb.Worksheets.get_Item(1);

            for (int i = 2; i <= ds.Tables[0].Rows.Count + 1; i++)
            {
                for (int j = 2; j <= ds.Tables[0].Columns.Count + 1; j++)
                {
                    data = ds.Tables[0].Rows[i - 2].ItemArray[j - 2].ToString();
                    ws.Cells[i, j - 1] = data;
                    ws.Cells[i, j - 1].ColumnWidth = 20;
                }
            }
            database.BaglantiKapat();
            xl.Visible = true;
        }
        private void metin()
        {
            this.Text = Localization.form5;
            anasayfaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            excelToolStripMenuItem.Text = Localization.excel_dokumani;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            lbl_firmaadi.Text = Localization.lbl_firmaadi;
            lbl_urunkodu.Text = Localization.lbl_urunkodu;
            lbl_giristarihi.Text = Localization.cikis; ;
            lbl_adet.Text = Localization.adet;
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
        private void txt_birim_fiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        private void txt_birim_fiyati_Leave(object sender, EventArgs e)
        {
            decimal donusum;
            donusum = decimal.Parse(txt_birim_fiyati.Text);
            txt_birim_fiyati.Text = donusum.ToString("N");
        }
        private void txt_adet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
    }
}
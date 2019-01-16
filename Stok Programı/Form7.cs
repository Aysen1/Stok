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
    public partial class Form7 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataReader dr;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.tema;
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            firma_listele();
            pctrbx_resim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");
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
            Form9 form9 = new Form9();
            if (Properties.Settings.Default.dil == "İngilizce")
            {
                Localization.Culture = new CultureInfo("en-US");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydetK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            { 
                Localization.Culture = new CultureInfo("");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydet.fw.png");
            }
            metinler();
            toolStripStatusLabel1.BackColor = Color.White;            
        }
        private void firma_listele()
        {
            komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = "select * from FirmaKayit";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbx_firmaadi.Items.Add(dr["FirmaAdi"]);
            }
            baglanti.Close();
        }
        private void urun_listele()
        {
            cmbx_urunadi.Items.Clear(); //yazılmadığı zaman cmbx_urunadi elemanları kademeli olarak artmaktadır.
            komut = new SqlCommand();
            komut.Connection = baglanti;
            baglanti.Open();
            komut.CommandText = "select * from UrunKayit1 where FirmaAdi=@firma";
            komut.Parameters.AddWithValue("@firma", cmbx_firmaadi.Text);
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                cmbx_urunadi.Items.Add(dr["UrunKodu"]);
            }
            baglanti.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            timer1.Start();
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
            txt_islem.Text = "";
            pctrbx_resim.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\barkod.png");
        }

        private void cmbx_urunadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from UrunKayit1 where UrunKodu=@kod ";
            komut.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Stream stream = dr.GetStream(4);
                pctrbx_resim.Image = Image.FromStream(stream);
              
            }
            baglanti.Close();  
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            
            if (cmbx_firmaadi.Text != "" && cmbx_urunadi.Text != "" && txt_adet.Text != "" && txt_islem.Text != "")
            {
                string UrunID="";
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand();
                komut1.Connection = baglanti;
                komut1.CommandText = "select UrunID from UrunKayit1 where UrunKodu=@kod";
                komut1.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
                dr = komut1.ExecuteReader();
                while (dr.Read())
                    UrunID = dr["UrunID"].ToString();
                baglanti.Close();

                baglanti.Open();
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "insert into UrunGiris1(UrunID, FirmaAdi, UrunKodu, GirisTarihi, UrunAdet, İslem, Personel) values ('"+UrunID+"','" + cmbx_firmaadi.Text + "','" + cmbx_urunadi.Text + "','" + dateTimePicker1.Text + "','" + txt_adet.Text + "','" + txt_islem.Text + "',@personel)";
                komut.Parameters.AddWithValue("@personel",Properties.Settings.Default.kullaniciadi);
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand();
                komut2.Connection = baglanti;
                komut2.CommandText = "update UrunKayit1 set ToplamAdet=ToplamAdet+@miktar where UrunKodu=@kod";
                komut2.Parameters.AddWithValue("@kod", cmbx_urunadi.Text);
                komut2.Parameters.AddWithValue("@miktar", int.Parse(txt_adet.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kayıt Başarılı.");
            }

            else
                MessageBox.Show("Kayıt Gerçekleştirilemedi.Tekrar Deneyiniz.");
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void cmbx_firmaadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_firmaadi.SelectedIndex != -1)
            {
                urun_listele();
            }
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Close();
            form6.Show();
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

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from UrunGiris1", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string data = null;

            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
            wb = xl.Workbooks.Add(Application.StartupPath+"\\exceldosyalari\\urungiris.xls");
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
            baglanti.Close();
            xl.Visible = true;
        }
        private void metinler()
        {
            this.Text = Localization.form7;
            anasayfaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            excelToolStripMenuItem.Text = Localization.excel_dokumani;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            lbl_firmaadi.Text = Localization.lbl_firmaadi;
            lbl_urunkodu.Text = Localization.lbl_urunkodu;
            lbl_giristarihi.Text = Localization.giris;
            lbl_adet.Text = Localization.adet;
            lbl_islemm.Text = Localization.islem;
        }
    }
}

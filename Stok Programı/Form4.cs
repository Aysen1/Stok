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


namespace Stok_Programı
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti;
        SqlConnectionStringBuilder baglan = new SqlConnectionStringBuilder();
        SqlCommand komut;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            baglan.DataSource = Properties.Settings.Default.serverip;
            baglan.InitialCatalog = Properties.Settings.Default.veritabani;
            baglan.IntegratedSecurity = true;
            baglanti = new SqlConnection(baglan.ConnectionString);
           // baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            btn_simge.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\simge.fw.png");
            btn_tamekran.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\tamekran.fw.png");
            btn_cikiss.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\cikis.fw.png");
            il_listele();

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
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydetK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                Localization.Culture = new CultureInfo("");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydet.fw.png");
            }
            metin();
            this.BackColor = Properties.Settings.Default.tema;
            toolStripStatusLabel1.BackColor = Color.White;            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_firmaadi.Text = "";
            txt_sorumlu.Text = "";
            txt_telno.Text = "";
            txt_vergidaire.Text = "";
            txt_vergino.Text = "";
            cmbx_il.Text = "";
            cmbx_ilce.Text = "";
            txt_adres.Text = "";
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            if(txt_adres.Text != " " && txt_firmaadi.Text!="" && cmbx_il.Text!="" && cmbx_ilce.Text!="" && txt_sorumlu.Text!=""  && txt_vergidaire.Text!="" && txt_vergino.Text!="" && txt_mersis.Text!="")
            {
                if (txt_telno.Text.Length == 11)
                {
                    komut.CommandText = "insert into FirmaKayit(FirmaAdi, SorumluAdi, TelefonNo, VergiDairesiAdi, VergiNo, KayitTarihi, Sehir, ilce, Adres, MersisNo) values ('" + txt_firmaadi.Text + "','" + txt_sorumlu.Text + "','" + txt_telno.Text + "','" + txt_vergidaire.Text + "','" + txt_vergino.Text + "','" + dateTimePicker1.Text + "','" + cmbx_il.Text + "','" + cmbx_ilce.Text + "','" + txt_adres.Text + "','" + txt_mersis.Text + "')";
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else
                    MessageBox.Show("Lütfen geçerli bir telefon numarası giriniz.");
                
            }
            else
                MessageBox.Show("Lütfen gerekli tüm alanları doldurun.");
            
            baglanti.Close();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Close();
            form6.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            timer1.Start();
        }
        private void il_listele()
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC", baglanti);
            da.Fill(dt);
            cmbx_il.ValueMember = "id";
            cmbx_il.DisplayMember = "sehir";
            cmbx_il.DataSource = dt;
            baglanti.Close();
        }


        private void cmbx_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_il.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir=" + cmbx_il.SelectedValue, baglanti);
                da.Fill(dt);
                cmbx_ilce.DisplayMember = "ilce";
                cmbx_ilce.DataSource = dt;
            }
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
            SqlDataAdapter da = new SqlDataAdapter("Select * from FirmaKayit", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string data = null;

            Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
            wb = xl.Workbooks.Add(Application.StartupPath+"\\exceldosyalari\\firmakayit.xls");
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
        private void metin()
        {
            this.Text = Localization.form4;
            anasayfaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            excelToolStripMenuItem.Text = Localization.excel_dokumani;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            lbl_firmaadi.Text = Localization.lbl_firmaadi;
            lbl_sorumlu.Text = Localization.sorumlu;
            lbl_telno.Text = Localization.telefon;
            lbl_vergidaire.Text = Localization.vergi;
            lbl_vergino.Text = Localization.vergi_no;
            lbl_mersis.Text = Localization.mersis;
            lbl_il.Text = Localization.il;
            lbl_ilce.Text = Localization.ilce;
            lbl_adres.Text = Localization.adres;
            lbl_kayit_tarihi.Text = Localization.lbl_kayit;
        }
    }
}

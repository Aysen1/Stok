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
using System.Text.RegularExpressions;
namespace Stok_Programı
{
    public partial class Form4 : Form
    {
        SqlCommand komut;
        DatabaseConnection database;
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            database = new DatabaseConnection();
            database.Baglanti();
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            il_listele();
            tarih.Text = DateTime.Today.ToLongDateString();

            if (Properties.Settings.Default.dil == "İngilizce")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizleK.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydetK.fw.png");
            }
            else if (Properties.Settings.Default.dil == "Türkçe")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                btn_temizle.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\temizle.fw.png");
                btn_kaydet.BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\image\\kaydet.fw.png");
            }
            metin();
            this.BackColor = Properties.Settings.Default.tema;
            tarih.BackColor = Color.White;
            saat.BackColor = Color.White;           
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
            database.BaglantiAc();
            komut = new SqlCommand();
            komut.Connection = database.baglanti;
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
            database.BaglantiKapat();
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
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void il_listele()
        {
            database.BaglantiAc();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from iller ORDER BY id ASC", database.baglanti);
            da.Fill(dt);
            cmbx_il.ValueMember = "id";
            cmbx_il.DisplayMember = "sehir";
            cmbx_il.DataSource = dt;
            database.BaglantiKapat();
        }
        private void cmbx_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_il.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from ilceler where sehir=" + cmbx_il.SelectedValue, database.baglanti);
                da.Fill(dt);
                cmbx_ilce.DisplayMember = "ilce";
                cmbx_ilce.DataSource = dt;
            }
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SqlConnection baglanti = new SqlConnection("Data Source=NFM-1\\MSSQLSERVER01; Integrated Security=TRUE; Initial Catalog=StokTakip");
            database.BaglantiAc();
            SqlDataAdapter da = new SqlDataAdapter("Select * from FirmaKayit", database.baglanti);
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
            database.BaglantiKapat();
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
        private void txt_vergino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        private void txt_mersis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        public static bool TelefonNoKontrol(string TelefonNo)
        {
            string RegexDesen = @"^(0(\d{3})-(\d{3})-(\d{2})-(\d{2}))";
            Match Eslesme = Regex.Match(TelefonNo, RegexDesen, RegexOptions.IgnoreCase);
            return Eslesme.Success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool TlfnKntrol = TelefonNoKontrol(textBox1.Text);
            if(TlfnKntrol==true)
                MessageBox.Show("Başarılı..");
            else
                MessageBox.Show("Telefon numarası hatalıdır. Lütfen kontrol ediniz.");
        }
    }
}
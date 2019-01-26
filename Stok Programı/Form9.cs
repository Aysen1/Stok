using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Stok_Programı
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            if (Properties.Settings.Default.dil == "İngilizce")
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            else if(Properties.Settings.Default.dil=="Türkçe")
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            metin();
            this.BackColor = Properties.Settings.Default.tema;
            tarih.Text = DateTime.Today.ToLongDateString();
            saat.BackColor = Color.White;
            tarih.BackColor = Color.White;
        }
        private void ingilizceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("en-US");
            Properties.Settings.Default.dil = "İngilizce";
            Properties.Settings.Default.Save();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            metin();
        }
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }
        public void metin()
        {
            this.Text = Localization.ayarlar;
            anasayfaToolStripMenuItem.Text = Localization.lbl_anasayfa;
            dilTercihiToolStripMenuItem.Text = Localization.dil;
            türkçeToolStripMenuItem.Text = Localization.türkçe;
            ingilizceToolStripMenuItem.Text = Localization.ingilizce;
            yardımToolStripMenuItem.Text = Localization.lbl_yardim;
            cikisToolStripMenuItem.Text = Localization.lbl_cikis;
            temaToolStripMenuItem.Text = Localization.tema;
            tarih.Text = DateTime.Today.ToLongDateString();
            saat.Text = DateTime.Now.ToLongTimeString();
        }
        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("");
            Properties.Settings.Default.dil = "Türkçe";
            Properties.Settings.Default.Save();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            metin();
        }
        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nfmajans.com/iletisim.html");
        }
        private void temaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kontrol;
            ColorDialog renk = new ColorDialog();
            kontrol = renk.ShowDialog();
            if (kontrol == DialogResult.OK)
            {
                this.BackColor = renk.Color;
                Properties.Settings.Default.tema = renk.Color;
                Properties.Settings.Default.Save();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            saat.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
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
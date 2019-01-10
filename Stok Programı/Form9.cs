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
        string a="";
        public Form9()
        {
            InitializeComponent();
        }
        string secilen;
        private void Form9_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
            else if(Properties.Settings.Default.dil=="Türkçe")
                Localization.Culture = new CultureInfo("");
            metin();
            this.BackColor = Properties.Settings.Default.tema;
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

        private void ingilizceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("en-US");
            Properties.Settings.Default.dil = "İngilizce";
            Properties.Settings.Default.Save();
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
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("");
            Properties.Settings.Default.dil = "Türkçe";
            Properties.Settings.Default.Save();
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

        private void btn_tema_Click(object sender, EventArgs e)
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

    }
}

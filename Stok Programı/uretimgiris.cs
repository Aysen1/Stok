using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Stok_Programı
{
    public partial class uretimgiris : DevExpress.XtraReports.UI.XtraReport
    {
        public uretimgiris()
        {
            InitializeComponent();
            xr_personel_adi.Text = Properties.Settings.Default.kullaniciadi;
        }

    }
}

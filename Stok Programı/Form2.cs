using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_baglan_Click(object sender, EventArgs e)
        {
            if(txt_serverip.Text==Environment.MachineName)
            {
                Form6 form6 = new Form6();
                form6.Show();
                this.Dispose();
            }
        }
    }
}

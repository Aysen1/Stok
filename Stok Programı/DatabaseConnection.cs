using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stok_Programı
{
    class DatabaseConnection
    {
        public SqlConnection baglanti;
        public SqlConnection Baglanti()
        {
                if(this.baglanti==null)
                {
                    baglanti = new SqlConnection();
                    baglanti.ConnectionString = GetConnectionString();
                }
                return baglanti;      
        }
        public void BaglantiAc()
        {
            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Hata: SQL Bağlantısı Açılamadı.");
                }
            }
        }
        public void BaglantiKapat()
        {
            if(baglanti.State==System.Data.ConnectionState.Open)
            {
                try
                {
                    baglanti.Close();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Hata: SQL Bağlantısı Kapatılamadı.");
                }
            }
        }
        string GetConnectionString()
        {
            SqlConnectionStringBuilder baglan = new SqlConnectionStringBuilder();
            baglan.DataSource = Properties.Settings.Default.serverip;
            baglan.UserID = Properties.Settings.Default.kullaniciisim;
            baglan.Password = Properties.Settings.Default.kullanicisifre;
            baglan.InitialCatalog = Properties.Settings.Default.veritabani;
            baglan.IntegratedSecurity = true;
            return baglan.ToString();
        }
    }
}

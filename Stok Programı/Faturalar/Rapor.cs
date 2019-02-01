using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace Stok_Programı.Faturalar
{
    class Rapor
    {
        SqlCommand komut;
        SqlDataAdapter da;
        DatabaseConnection database = new DatabaseConnection();
        public void sql(DataSet ds,string tarih1, string tarih2, bool t1, bool t2)
        {
            database.Baglanti();
            if (t1 == false & t2 == false)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis ORDER BY FirmaAdi", database.baglanti);
                rapor_olustur(ds);
            }
            else if (t1 == true & t2 == false)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE CikisTarihi>@baslangic ORDER BY FirmaAdi", database.baglanti);
                komut.Parameters.AddWithValue("@baslangic", tarih1);
                rapor_olustur(ds);
            }
            else if (t1 == false & t2 == true)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE CikisTarihi<@bitis ORDER BY FirmaAdi", database.baglanti);
                komut.Parameters.AddWithValue("@bitis", tarih2);
                rapor_olustur(ds);
            }
            else if (t1 == true & t2== true)
            {
                komut = new SqlCommand(@"SELECT * FROM UrunCikis WHERE (CikisTarihi>@baslangic) AND (CikisTarihi<@bitis) ORDER BY FirmaAdi", database.baglanti);
                komut.Parameters.AddWithValue("@bitis", tarih2);
                komut.Parameters.AddWithValue("@baslangic", tarih1);
                rapor_olustur(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi.Lütfen Yeniden Deneyiniz.", "Bilgilendirme Penceresi");
            }
        }
        private void rapor_olustur(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            ds.Tables[0].TableName = "bilgiler";
            database.BaglantiKapat();
            decimal a = 0;
            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[9]);
                }
                Properties.Settings.Default.raporno++;
                Properties.Settings.Default.Save();
                fatura fatura1 = new fatura();
                fatura1.DataAdapter = da;
                fatura1.DataSource = ds;
                fatura1.faturano.Text = Properties.Settings.Default.raporno.ToString();
                fatura1.faturatarih.Text = DateTime.Now.ToString();
                fatura1.urunadi.DataBindings.Add("Text", ds, "UrunKodu");
                fatura1.miktar.DataBindings.Add("Text", ds, "UrunAdet");
                fatura1.firma.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura1.xrTable3.Visible = false;
                fatura1.xrTable4.Visible = false;
                fatura1.invoiceduedaterow.Visible = false;
                fatura1.islembicimi.Text = "SATIŞ RAPORU";
                fatura1.islemno.Text = "RAPOR NO#";
                fatura1.xrTableCell23.Visible = false;
                fatura1.xrTableCell25.Visible = false;
                fatura1.xrTableCell27.Visible = false;
                fatura1.xrTableCell21.Text = "DÜZENLEYEN PERSONEL";
                fatura1.birimfiyat.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura1.tutar.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura1.toplam.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura1.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura1.DataMember = ((DataSet)fatura1.DataSource).Tables[0].TableName;
                // fatura1.LoadLayout(Application.StartupPath + "\\faturalar\\rapor.repx");
                fatura1.ShowPreview();
            }
        }
    }
}

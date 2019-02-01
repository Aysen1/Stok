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
    class Fatura4
    {
        SqlCommand komut;
        SqlDataAdapter da;
        DatabaseConnection database = new DatabaseConnection();

        public void sql(DataSet ds,string cmbx_firmaadi,string faturano)
        {
            database.Baglanti();
            if (cmbx_firmaadi != "" & faturano != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,UrunCikis.UrunKodu,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,UrunCikis.BirimFiyati,UrunCikis.FaturaNo,Fatura.FaturaTarih 
                FROM UrunCikis,FirmaKayit,Fatura
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FaturaNo=@faturano) AND (Fatura.FaturaNo=UrunCikis.FaturaNo)
                AND (UrunCikis.FirmaAdi=@firma)", database.baglanti);
                komut.Parameters.AddWithValue("@faturano", faturano);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                sablon(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarihe göre filtreleme yapılmamaktadır. Filtrelemenin doğru bir şekilde yapılabilmesi için Firma Adı alanını boş bırakmayınız.",
                    "Bilgilendirme Penceresi");
            }
        }
        private void sablon(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal fiyat = 0;
            ds.Tables[0].TableName = "bilgiler";
            database.BaglantiKapat();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    fiyat += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[4]);
                }
                tasarim2 fatura2 = new tasarim2();
                fatura2.DataAdapter = da;
                fatura2.DataSource = ds;
                fatura2.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura2.invoiceDate.DataBindings.Add("Text", ds, "FaturaTarih");
                //fatura2.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura2.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura2.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura2.invoiceNumber.DataBindings.Add("Text", ds, "FaturaNo");
                fatura2.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura2.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura2.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura2.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura2.DataMember = ((DataSet)fatura2.DataSource).Tables[0].TableName;
                fatura2.ShowPreview();
            }
        }
    }
}

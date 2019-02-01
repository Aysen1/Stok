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
    class Fatura3
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
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.FaturaNo=@faturano) AND (UrunCikis.FaturaNo=Fatura.FaturaNo)", database.baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                komut.Parameters.AddWithValue("@faturano", faturano);
                tasarim3(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde işlem yapabilmek için Firma Adı alanı boş bırakılmamalıdır, tarihe göre filtreleme yapılmak isteniyorsa Başlangıç Tarihi ve Bitiş Tarihi alanları aynı anda işaretlenmelidir.",
    "Bilgilendirme Penceresi");
            }
        }
        private void tasarim3(DataSet ds)
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
                tasarim3 fatura3 = new tasarim3();
                fatura3.DataAdapter = da;
                fatura3.DataSource = ds;
                fatura3.invoiceDate.DataBindings.Add("Text", ds, "FaturaTarih");
                fatura3.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura3.total2.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura3.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura3.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura3.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura3.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura3.firmail.DataBindings.Add("Text", ds, "Sehir");
                fatura3.firmailce.DataBindings.Add("Text", ds, "ilce");
                fatura3.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura3.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura3.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura3.invoiceNumber.DataBindings.Add("Text", ds, "FaturaNo");
                fatura3.DataMember = ((DataSet)fatura3.DataSource).Tables[0].TableName;
                fatura3.ShowPreview();
            }
        }
    }
}

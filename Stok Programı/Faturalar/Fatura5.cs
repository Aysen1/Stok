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
    class Fatura5
    {
        SqlCommand komut;
        SqlDataAdapter da;
        DatabaseConnection database = new DatabaseConnection();
        public void sql(DataSet ds,string cmbx_firmaadi,string faturano)
        {
            database.Baglanti();
            if (cmbx_firmaadi != "" & faturano != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.Personel,FirmaKayit.Sehir,FirmaKayit.ilce,
                FirmaKayit.Adres,FirmaKayit.SorumluAdi,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat,UrunCikis.FaturaNo,Fatura.FaturaTarih
                FROM UrunCikis,FirmaKayit,Fatura
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.FaturaNo=@faturano) AND (Fatura.FaturaNo=UrunCikis.FaturaNo)
                ORDER BY UrunCikis.CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@faturano", faturano);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                sablon(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarih filtrelemesi yapılmamaktadır, filtreleme yapılabilmesi için Firma Adı alanını boş bırakmamalısınız. Kontrol edip yeniden deneyiniz..",
                    "Bilgilendirme Penceresi");
            }
        }
        private void sablon(DataSet ds)
        {
            da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal a = 0;
            ds.Tables[0].TableName = "bilgiler";
            database.BaglantiKapat();

            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Ürün Bulunmamaktadır.", "Bilgilendirme Penceresi");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[10]);
                }
                tasarim fatura = new tasarim();
                fatura.DataAdapter = da;
                fatura.DataSource = ds;
                fatura.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura.invoiceDate.DataBindings.Add("Text", ds, "FaturaTarih");
                fatura.ilce.DataBindings.Add("Text", ds, "ilce");
                fatura.sehir.DataBindings.Add("Text", ds, "Sehir");
                fatura.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura.total.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura.invoiceNumber.DataBindings.Add("Text", ds, "FaturaNo");
                fatura.customerContactName.DataBindings.Add("Text", ds, "SorumluAdi");
                fatura.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                fatura.DataMember = ((DataSet)fatura.DataSource).Tables[0].TableName;
                fatura.ShowPreview();
            }
        }
    }
}

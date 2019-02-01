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
    class Fatura2
    {
        SqlCommand komut;
        SqlDataAdapter da;
        DatabaseConnection database = new DatabaseConnection();
        public void sablon(DataSet ds,string cmbx_firmaadi, string faturano)
        {
            database.Baglanti();
            if (cmbx_firmaadi != "" & faturano!= "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo,UrunCikis.BirimFiyati,UrunCikis.FaturaNo,Fatura.FaturaTarih 
                FROM UrunCikis,FirmaKayit,Fatura
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.FaturaNo=@faturano) AND (Fatura.FaturaNo=UrunCikis.FaturaNo)
                ORDER BY UrunCikis.CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@faturano", faturano);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                tasarim4(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde tarihe göre filtreleme yapılmamaktadır. Filtrelemenin doğru bir şekilde yapılabilmesi için Firma Adı ve FaturaNo alanlarını boş bırakmayınız.",
                    "Bilgilendirme Penceresi");
            }
        }
        public void tasarim4(DataSet ds)
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
                tasarim4 fatura4 = new tasarim4();
                fatura4.DataAdapter = da;
                fatura4.DataSource = ds;
                fatura4.productDescription.DataBindings.Add("Text", ds, "UrunKodu");
                fatura4.invoiceDate.DataBindings.Add("Text", ds, "FaturaTarih");
                fatura4.saat.DataBindings.Add("Text", ds, "FaturaTarih");
                fatura4.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura4.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura4.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura4.customerTown.DataBindings.Add("Text", ds, "ilce");
                fatura4.customerCity.DataBindings.Add("Text", ds, "Sehir");
                fatura4.customerTel.DataBindings.Add("Text", ds, "TelefonNo");
                fatura4.total2.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura4.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura4.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura4.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura4.invoiceNumber.DataBindings.Add("Text", ds, "FaturaNo");
                fatura4.DataMember = ((DataSet)fatura4.DataSource).Tables[0].TableName;
                //  fatura4.LoadLayout(Application.StartupPath + "\\faturalar\\tasarim4.repx");
                fatura4.ShowPreview();
                //fatura4.ShowDesigner();
                //fatura4.SaveLayout(Application.StartupPath + "\\faturalar");
            }
        }
    }
}

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
    class Fatura7
    {
        SqlCommand komut;
        SqlDataAdapter da;
        DatabaseConnection database = new DatabaseConnection();
        public void sql(DataSet ds,string cmbx_firmaadi,string faturano)
        {
            database.Baglanti();
            if (cmbx_firmaadi != "" & faturano!="")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunAdet,UrunCikis.UrunKodu,UrunCikis.CikisTarihi,UrunCikis.ToplamFiyat,
                FirmaKayit.Adres,FirmaKayit.Sehir,FirmaKayit.ilce,FirmaKayit.TelefonNo, UrunCikis.BirimFiyati,UrunCikis.FaturaNo,Fatura.FaturaTarih 
                FROM UrunCikis,FirmaKayit,Fatura
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.FaturaNo=@faturano) AND (Fatura.FaturaNo=UrunCikis.FaturaNo)
                ORDER BY UrunCikis.CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                komut.Parameters.AddWithValue("@faturano", faturano);
                sablon(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Bu fatura modelinde işlem yapabilmek için Firma Adı ve tarih alanı boş bırakılmamalıdır, tarihe göre filtreleme yapılması için Başlangıç Tarihi ve Bitiş Tarihi alanları aynı anda işaretlenmemelidir.",
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
                tasarim7 fatura5 = new tasarim7();
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
                fatura5.DataAdapter = da;
                fatura5.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 1)
                    fatura5.invoiceDueDateRow.Visible = true;
                else
                    fatura5.invoiceDueDateRow.Visible = false;
                fatura5.productName.DataBindings.Add("Text", ds, "UrunKodu");
                fatura5.invoiceDate.Text = DateTime.Now.ToString();
                fatura5.invoiceDueDate.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura5.quantity.DataBindings.Add("Text", ds, "UrunAdet");
                fatura5.productDescription.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerName.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura5.customerAddress.DataBindings.Add("Text", ds, "Adres");
                fatura5.customerTown.DataBindings.Add("Text", ds, "ilce");
                fatura5.customerCity.DataBindings.Add("Text", ds, "Sehir");
                fatura5.customerPhone.DataBindings.Add("Text", ds, "TelefonNo");
                fatura5.unitPrice.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura5.lineTotal.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura5.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura5.total.Text = string.Format("{0:#,##.00 ₺}", fiyat);
                fatura5.faturano.Text = Properties.Settings.Default.faturano.ToString();
                fatura5.DataMember = ((DataSet)fatura5.DataSource).Tables[0].TableName;
                fatura5.ShowPreview(); ;
            }
        }
    }
}

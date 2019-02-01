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
    class Fatura1
    {
        SqlCommand komut;
        DatabaseConnection database = new DatabaseConnection();
        SqlDataAdapter da;
        public void sql(DataSet ds,string cmbx_firmaadi,string faturano)
        {
              database.Baglanti();
            if (cmbx_firmaadi != "" & faturano != "")
            {
                komut = new SqlCommand(@"SELECT UrunCikis.FirmaAdi,UrunCikis.UrunKodu,UrunCikis.UrunAdet,UrunCikis.CikisTarihi,FirmaKayit.Adres,FirmaKayit.Sehir,
                FirmaKayit.ilce,FirmaKayit.TelefonNo,FirmaKayit.VergiDairesiAdi,FirmaKayit.MersisNo,UrunCikis.BirimFiyati,UrunCikis.ToplamFiyat,UrunCikis.FaturaNo,Fatura.FaturaTarih
                FROM UrunCikis,FirmaKayit,Fatura
                WHERE (UrunCikis.FirmaAdi=FirmaKayit.FirmaAdi) AND (UrunCikis.FirmaAdi=@firma) AND (UrunCikis.FaturaNo=@faturano) AND (UrunCikis.FaturaNo=Fatura.FaturaNo)
                ORDER BY UrunCikis.CikisTarihi", database.baglanti);
                komut.Parameters.AddWithValue("@firma", cmbx_firmaadi);
                komut.Parameters.AddWithValue("@faturano", faturano);
                sablon(ds);
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi. Filtreleme yapabilmeniz için Firma Adı seçimi yapmanız gerekmektedir..Gerekli alanları kontrol edip tekrar deneyiniz..", "Bilgilendirme Penceresi");
            }
        }
        public void sablon(DataSet ds)
        {
            database.Baglanti();
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
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[11]);
                }
               // Properties.Settings.Default.faturano++;
                //Properties.Settings.Default.Save();
                fatura fatura1 = new fatura();
                fatura1.DataAdapter = da;
                fatura1.DataSource = ds;
                if (ds.Tables[0].Rows.Count == 1)
                    fatura1.invoiceduedaterow.Visible = true;
                else
                    fatura1.invoiceduedaterow.Visible = false;
                fatura1.faturano.DataBindings.Add("Text", ds, "FaturaNo");
                fatura1.faturatarih.DataBindings.Add("Text", ds, "FaturaTarih"); 
                fatura1.satistarih.DataBindings.Add("Text", ds, "CikisTarihi");
                fatura1.firmaadi.DataBindings.Add("Text", ds, "FirmaAdi");
                fatura1.firmaadres.DataBindings.Add("Text", ds, "Adres");
                fatura1.firmail.DataBindings.Add("Text", ds, "Sehir");
                fatura1.firmailce.DataBindings.Add("Text", ds, "ilce");
                fatura1.urunadi.DataBindings.Add("Text", ds, "UrunKodu");
                fatura1.miktar.DataBindings.Add("Text", ds, "UrunAdet");
                fatura1.vergi.DataBindings.Add("Text", ds, "VergiDairesiAdi");
                fatura1.mersis.DataBindings.Add("Text", ds, "MersisNo");
                fatura1.birimfiyat.DataBindings.Add("Text", ds, "BirimFiyati");
                fatura1.tutar.DataBindings.Add("Text", ds, "ToplamFiyat");
                fatura1.toplam.Text = string.Format("{0:#,##.00 ₺}", a);
                fatura1.personel.Text = Properties.Settings.Default.kullaniciadi;
                fatura1.DataMember = ((DataSet)fatura1.DataSource).Tables[0].TableName;
                //  fatura1.LoadLayout(Application.StartupPath + "\\faturalar\\fatura.repx");
                fatura1.ShowPreview();
            }
        }
    }
}

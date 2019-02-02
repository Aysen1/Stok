using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Stok_Programı.Faturalar
{
    class satisFaturasi
    {
        DatabaseConnection database=new DatabaseConnection();
        SqlCommand komut;
        public void kayıt_ekle(string ad, string satis_tarih,string fatura_tarih,string tip)
        {
            database.Baglanti();
            database.BaglantiAc();
            komut= new SqlCommand(@"SELECT FirmaAdi,CikisTarihi,FaturaNo FROM UrunCikis WHERE (FirmaAdi=@firma) AND (CikisTarihi>=@tarih) AND (FaturaNo IS NULL)", database.baglanti);
            komut.Parameters.AddWithValue("@firma", ad);
            komut.Parameters.AddWithValue("@tarih", satis_tarih);
            SqlDataReader dr=komut.ExecuteReader();
            if(dr.Read())
            {
                database.BaglantiKapat();
                database.BaglantiAc();
                SqlCommand komut2 = new SqlCommand(@"insert into Fatura (FaturaNo,FaturaTarih,FirmaAdi,FaturaTip) VALUES ('" + Properties.Settings.Default.faturano + "','" + fatura_tarih + "','" + ad + "','"+tip+"')", database.baglanti);
                komut2.ExecuteNonQuery();
                database.BaglantiKapat();

                database.BaglantiAc();
                SqlCommand komut3 = new SqlCommand("UPDATE UrunCikis SET FaturaNo=@numara WHERE (FirmaAdi=@isim) AND (CikisTarihi>=@tarih) AND (FaturaNo IS NULL) ", database.baglanti);
                komut3.Parameters.AddWithValue("@isim", ad);
                komut3.Parameters.AddWithValue("@tarih", satis_tarih);
                komut3.Parameters.AddWithValue("@numara", Properties.Settings.Default.faturano);
                komut3.ExecuteNonQuery();
                database.BaglantiKapat();
                MessageBox.Show("Kayıt Başarılı.", "Bilgi Penceresi");
                Properties.Settings.Default.faturano++;
                Properties.Settings.Default.Save();
            }
            else 
                    MessageBox.Show("Üzgünüz Aradığınız Aralıkta Satışı Yapılan Ürün Bulunmamaktadır.", "Bilgi Penceresi");
        }
        public void FaturaYazdir(string ad, string no)
        {
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand("",database.baglanti);
        }
    }
}
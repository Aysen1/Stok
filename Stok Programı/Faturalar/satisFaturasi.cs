using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
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
            {
                MessageBox.Show("Üzgünüz Aradığınız Aralıkta Satışı Yapılan Ürün Bulunmamaktadır.", "Bilgi Penceresi");
                database.BaglantiKapat();
            }   
        }
        public void FaturaYazdir(string ad, string no)
        {
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand("",database.baglanti);
        }
        public void ara(string ad, string tarih, DataGridView veriler)
        {
            veriler.ReadOnly = true;
            veriler.RowHeadersVisible = false;
            veriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand(@"SELECT UrunKodu,FirmaAdi,CikisTarihi,UrunAdet,Personel,BirimFiyati,ToplamFiyat FROM UrunCikis WHERE (FirmaAdi=@firma) AND (CikisTarihi>=@tarih) AND (FaturaNo IS NULL)", database.baglanti);
            komut.Parameters.AddWithValue("@firma", ad);
            komut.Parameters.AddWithValue("@tarih", tarih);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                dr.Close();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                veriler.DataSource = dt;
                veriler.Columns[0].HeaderText = "Ürün Kodu";
                veriler.Columns[1].HeaderText = "Firma Adı";
                veriler.Columns[2].HeaderText = "Satış Tarihi";
                veriler.Columns[3].HeaderText = "Satılan Adet";
                veriler.Columns[4].HeaderText = "Satış Yapan Personel";
                veriler.Columns[5].HeaderText = "Birim Fiyat";
                veriler.Columns[6].HeaderText = "Toplam Fiyat";
                veriler.EnableHeadersVisualStyles = false;
                veriler.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
                veriler.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                database.BaglantiKapat();
            }
            else
            {
                MessageBox.Show("Üzgünüz Aradığınız Aralıkta Satışı Yapılan Ürün Bulunmamaktadır.", "Bilgi Penceresi");
                database.BaglantiKapat();
                dr.Close();
            }
        }
    }
}
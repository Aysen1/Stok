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
using Stok_Programı.Tasarımlar;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace Stok_Programı.Faturalar
{
    class Sweb
    {
        DatabaseConnection database = new DatabaseConnection();
        SqlCommand komut;
        public void ara(string kod, DataGridView d_veriler)
        {
            d_veriler.ReadOnly = true;
            d_veriler.RowHeadersVisible = false;
            d_veriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            database.Baglanti();
            database.BaglantiAc();
            komut = new SqlCommand(@"SELECT CariBilgileri.AcenteKodu,CariBilgileri.Unvan,
            Cari_islem.Aciklama,Cari_islem.BelgeSiraNo,Cari_islem.IptalK,Cari_islem.IstihsalK,CariBilgileri.Bakiye
            FROM CariBilgileri,Cari_islem WHERE (CariBilgileri.AcenteKodu=@kod) AND (CariBilgileri.AcenteKodu=Cari_islem.AcenteKod)", database.baglanti);
            komut.Parameters.AddWithValue("@kod", kod);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                d_veriler.DataSource = dt;
                d_veriler.Columns[0].HeaderText = "Acente Kodu";
                d_veriler.Columns[1].HeaderText = "İsim-Ünvan";
                d_veriler.Columns[2].HeaderText = "Açıklama";
                d_veriler.Columns[3].HeaderText = "BelgeSiraNo";
                d_veriler.Columns[4].HeaderText = "İptal Komisyonu";
                d_veriler.Columns[5].HeaderText = "İstihsal Komisyonu";
                d_veriler.Columns[6].HeaderText = "Bakiyesi";
                d_veriler.EnableHeadersVisualStyles = false;
                d_veriler.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
                d_veriler.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                database.BaglantiKapat();
            }
            else
            {
                MessageBox.Show("Üzgünüz Aradığınız Kriterde Acente Bilgisi Bulunmamaktadır..", "Bilgi Penceresi");
                database.BaglantiKapat();
                dr.Close();
            }
        }
        public void belge_goster(DataSet ds, string kod, string aciklama, string iptalk, string istihsalk, string tarih)
        {
            decimal? x_iptalk = CustomParse(iptalk);
            decimal? x_istihsalk = CustomParse(istihsalk);
            DateTime x_tarih = Convert.ToDateTime(tarih);
            int x_kod = Convert.ToInt32(kod);
            database.Baglanti();
            database.BaglantiAc();
            if (kod != "" & aciklama != "" & iptalk != "" & istihsalk != "")
            {
                komut = new SqlCommand(@"SELECT CariBilgileri.AcenteKodu,CariBilgileri.Bolge,CariBilgileri.Unvan,CariBilgileri.Adres,CariBilgileri.VergiDairesi,CariBilgileri.VergiNo,
                Cari_islem.Aciklama,Cari_islem.IptalK,Cari_islem.IstihsalK,Cari_islem.HizmetBedeli,CariBilgileri.Bakiye,Cari_islem.Tarih,Cari_islem.BelgeSiraNo,Cari_islem.Donembslngc,Cari_islem.Donembts
                FROM CariBilgileri,Cari_islem
                WHERE (CariBilgileri.AcenteKodu=@kod) AND (CariBilgileri.AcenteKodu=Cari_islem.AcenteKod) AND (Cari_islem.Aciklama=@aciklama) AND ((Cari_islem.IptalK=@iptal) OR (Cari_islem.IstihsalK=@istihsal)) 
                ", database.baglanti);
                decimal bakiye = 0;
                komut.Parameters.AddWithValue("@kod", x_kod);
                komut.Parameters.AddWithValue("@aciklama", aciklama);
                komut.Parameters.AddWithValue("@iptal", x_iptalk);
                komut.Parameters.AddWithValue("@istihsal", x_istihsalk);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds1=new DataSet();
                da.Fill(ds1);
                ds1.Tables[0].TableName = "bakiye";
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        bakiye = Convert.ToDecimal(ds1.Tables[0].Rows[i].ItemArray[10]);
                        x_iptalk = Convert.ToDecimal(ds1.Tables[0].Rows[i].ItemArray[7]);
                    }
                    Properties.Settings.Default.hbedel = Convert.ToDecimal(dr["HizmetBedeli"]);
                    Properties.Settings.Default.Save();
                }

                database.BaglantiAc();
                dr.Close();
                SqlCommand komut3 = new SqlCommand(@"UPDATE CariBilgileri SET Bakiye=@bakiye WHERE AcenteKodu=@kod", database.baglanti);
                komut3.Parameters.AddWithValue("@kod", kod);
                decimal sonuc = bakiye - Properties.Settings.Default.hbedel;
                komut3.Parameters.AddWithValue("@bakiye", sonuc);
                komut3.ExecuteNonQuery();
                database.BaglantiKapat();
                belge_sablon(ds, aciklama, x_iptalk.ToString(), istihsalk, tarih);
            }
            else if (kod != "" & aciklama == "" & (iptalk == "" || iptalk == "0.00") & (istihsalk == "" || istihsalk == "0.00"))
            {
                komut = new SqlCommand(@"SELECT CariBilgileri.AcenteKodu,CariBilgileri.Bolge,CariBilgileri.Unvan,CariBilgileri.Adres,CariBilgileri.VergiDairesi,CariBilgileri.VergiNo,
                Cari_islem.Aciklama,Cari_islem.IptalK,Cari_islem.IstihsalK,Cari_islem.HizmetBedeli,CariBilgileri.Bakiye,Cari_islem.Tarih,Cari_islem.BelgeSiraNo,Cari_islem.Donembslngc,Cari_islem.Donembts
                FROM CariBilgileri,Cari_islem
                WHERE (Cari_islem.BelgeSiraNo=@no) AND (CariBilgileri.AcenteKodu=Cari_islem.AcenteKod)
                ", database.baglanti);
                decimal bakiye = 0;
                komut.Parameters.AddWithValue("@no", Properties.Settings.Default.belgesirano);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                ds1.Tables[0].TableName = "bakiye";
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        bakiye = Convert.ToDecimal(ds1.Tables[0].Rows[i].ItemArray[10]);
                        x_iptalk = Convert.ToDecimal(ds1.Tables[0].Rows[i].ItemArray[7]);
                    }
                   // MessageBox.Show(x_iptalk.ToString());
                    Properties.Settings.Default.hbedel = Convert.ToDecimal(dr["HizmetBedeli"]);
                    Properties.Settings.Default.Save();
                }

                database.BaglantiAc();
                dr.Close();
                SqlCommand komut3 = new SqlCommand(@"UPDATE CariBilgileri SET Bakiye=@bakiye WHERE AcenteKodu=@kod", database.baglanti);
                komut3.Parameters.AddWithValue("@kod", kod);
                decimal sonuc = bakiye - Properties.Settings.Default.hbedel;
                komut3.Parameters.AddWithValue("@bakiye", sonuc);
                komut3.ExecuteNonQuery();
                database.BaglantiKapat();
                belge_sablon(ds, "", x_iptalk.ToString(), "", "");
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Üzgünüz işleminiz gerçekleştirilemedi.", "Bilgilendirme Penceresi");
            }
        }
        public void belge_sablon(DataSet ds, string aciklama, string iptalk, string istihsalk, string tarih)
        {
            database.Baglanti();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(ds);
            decimal a = 0;
            ds.Tables[0].TableName = "bilgiler";
            database.BaglantiKapat();
            if (ds.Tables[0].Rows.Count == 0)
                MessageBox.Show("Bilgi Bulunmamaktadır.");
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    a += Convert.ToDecimal(ds.Tables[0].Rows[i].ItemArray[9]);
                }
                sigortamweb sw = new sigortamweb();
                sw.DataAdapter = da;
                sw.DataSource = ds;
                sw.xrkod.DataBindings.Add("Text", ds, "AcenteKodu");
                sw.xrunvan.DataBindings.Add("Text", ds, "Unvan");
                sw.xradres.DataBindings.Add("Text", ds, "Adres");
                sw.xrdaire.DataBindings.Add("Text", ds, "VergiDairesi");
                sw.xrno.DataBindings.Add("Text", ds, "VergiNo");
                sw.xrbolge.DataBindings.Add("Text", ds, "Bolge");
                sw.xrtarih.DataBindings.Add("Text", ds, "Tarih");
                sw.xrdonem.DataBindings.Add("Text", ds, "Donembslngc");
                sw.xrdnm.DataBindings.Add("Text", ds, "Donembts");

                sw.xraciklama.DataBindings.Add("Text", ds, "Aciklama");
                if (iptalk != "0,00")
                {
                    sw.xriptal.DataBindings.Add("Text", ds, "IptalK");
                    sw.xriptal2.DataBindings.Add("Text", ds, "IptalK");
                }
                else
                {
                    sw.xriptal.Text = "0,00 ₺";
                    sw.xriptal2.Text = "0,00 ₺";
                }
                //sw.xriptal.Text = iptalk;
                sw.xristihsal.DataBindings.Add("Text", ds, "IstihsalK");
                sw.xrhbedel.DataBindings.Add("Text", ds, "HizmetBedeli");

                sw.xrkod2.DataBindings.Add("Text", ds, "AcenteKodu");
                sw.xrunvan2.DataBindings.Add("Text", ds, "Unvan");
                sw.xradres2.DataBindings.Add("Text", ds, "Adres");
                sw.xrdaire2.DataBindings.Add("Text", ds, "VergiDairesi");
                sw.xrno2.DataBindings.Add("Text", ds, "VergiNo");
                sw.xrbolge2.DataBindings.Add("Text", ds, "Bolge");
                sw.xrtarih2.DataBindings.Add("Text", ds, "Tarih");

                sw.xraciklama2.DataBindings.Add("Text", ds, "Aciklama");
                sw.xristihsal2.DataBindings.Add("Text", ds, "IstihsalK");
                sw.xrhbedel2.DataBindings.Add("Text", ds, "HizmetBedeli");
 
                sw.xrdnm2.DataBindings.Add("Text", ds, "Donembts");
                sw.xrdonem2.DataBindings.Add("Text", ds, "Donembslngc");
                sw.DataMember = ((DataSet)sw.DataSource).Tables[0].TableName;
                sw.PrintDialog();
                //sw.ShowPreview();
            }
        }

        public decimal? CustomParse(string incomingValue)
        {
            decimal val;
            if (!decimal.TryParse(incomingValue.Replace(",", "").Replace(".", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))
                return null;
            return val / 100;
        }

        public void police_kaydet(DataSet ds, string kod, string aciklama, string iptalk, string istihsalk, string tarih, string baslangic, string bitis)
        {
            database.Baglanti();
            database.BaglantiAc();
            decimal? x_iptalk = CustomParse(iptalk);
            decimal? x_istihsalk = CustomParse(istihsalk);
            DateTime x_tarih = Convert.ToDateTime(tarih);
            DateTime x_baslangic = Convert.ToDateTime(baslangic);
            DateTime x_bitis = Convert.ToDateTime(bitis);
            int x_kod = Convert.ToInt32(kod);
            if (kod != "" & aciklama != "" & (iptalk != "" & iptalk!="0.00")& istihsalk != "" & baslangic != "" & bitis != "")
            {
                komut = new SqlCommand(@"SELECT AcenteKodu,Bolge,Unvan,Adres,VergiDairesi,VergiNo
                FROM CariBilgileri
                WHERE AcenteKodu=@kod", database.baglanti);
                komut.Parameters.AddWithValue("@kod", kod);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    decimal? hbedel = 0;
                    int x_siraNo = Convert.ToInt32(Properties.Settings.Default.sigorta_sira);
                    hbedel = x_iptalk - x_istihsalk;
                    database.BaglantiKapat();
                    database.BaglantiAc();
                    SqlCommand komut2 = new SqlCommand(@"INSERT INTO Cari_islem (AcenteKod,Aciklama,IptalK,IstihsalK,HizmetBedeli,Tarih,BelgeSiraNo,Donembslngc,Donembts)" 
                    + "VALUES(@AcenteKod,@Aciklama,@IptalK,@IstihsalK,@HizmetBedeli,@Tarih,@BelgeSiraNo,@Donembslngc,@Donembts)"
                        , database.baglanti);
                    komut2.Parameters.AddWithValue("@AcenteKod", x_kod);
                    komut2.Parameters.AddWithValue("@Aciklama", aciklama);
                    komut2.Parameters.AddWithValue("@IptalK", x_iptalk);
                    komut2.Parameters.AddWithValue("@IstihsalK", x_istihsalk);
                    komut2.Parameters.AddWithValue("@HizmetBedeli", hbedel);
                    komut2.Parameters.AddWithValue("@Tarih", tarih);
                    komut2.Parameters.AddWithValue("@BelgeSiraNo", x_siraNo);
                    komut2.Parameters.AddWithValue("@Donembslngc", x_baslangic);
                    komut2.Parameters.AddWithValue("@Donembts", x_bitis);

                    komut2.ExecuteNonQuery();
                    database.BaglantiKapat();

                    database.BaglantiAc();
                    SqlCommand komut3 = new SqlCommand(@"UPDATE CariBilgileri SET Bakiye=Bakiye+@bedel WHERE AcenteKodu=@kod", database.baglanti);
                    komut3.Parameters.AddWithValue("@kod", kod);
                    komut3.Parameters.AddWithValue("@bedel", hbedel);
                    komut3.ExecuteNonQuery();
                    database.BaglantiKapat();
                    MessageBox.Show("Bilgiler başarıyla kaydedildi.", "Bilgilendirme Penceresi");
                    Properties.Settings.Default.sigorta_sira++;
                    Properties.Settings.Default.Save();
                }
            }
            else if (kod != "" & aciklama != "" &  (iptalk == "" || iptalk == "0.00") & istihsalk != "" & baslangic != "" & bitis != "")
            {
                decimal x_iptalk1 = 0;
                //decimal x_istihsalk1 = 0;
                komut = new SqlCommand(@"SELECT AcenteKodu,Bolge,Unvan,Adres,VergiDairesi,VergiNo
                FROM CariBilgileri
                WHERE AcenteKodu=@kod", database.baglanti);
                komut.Parameters.AddWithValue("@kod", kod);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    decimal? hbedel = 0;
                    int x_siraNo = Convert.ToInt32(Properties.Settings.Default.sigorta_sira);
                    hbedel =  x_istihsalk;
                    database.BaglantiKapat();
                    database.BaglantiAc();
                    SqlCommand komut2 = new SqlCommand(@"INSERT INTO Cari_islem (AcenteKod,Aciklama,IptalK,IstihsalK,HizmetBedeli,Tarih,BelgeSiraNo,Donembslngc,Donembts)"
                    + "VALUES(@AcenteKod,@Aciklama,@IptalK,@IstihsalK,@HizmetBedeli,@Tarih,@BelgeSiraNo,@Donembslngc,@Donembts)"
                        , database.baglanti);
                    komut2.Parameters.AddWithValue("@AcenteKod", x_kod);
                    komut2.Parameters.AddWithValue("@Aciklama", aciklama);
                    komut2.Parameters.AddWithValue("@IptalK", x_iptalk1);
                    komut2.Parameters.AddWithValue("@IstihsalK", x_istihsalk);
                    komut2.Parameters.AddWithValue("@HizmetBedeli", hbedel);
                    komut2.Parameters.AddWithValue("@Tarih", tarih);
                    komut2.Parameters.AddWithValue("@BelgeSiraNo", x_siraNo);
                    komut2.Parameters.AddWithValue("@Donembslngc", x_baslangic);
                    komut2.Parameters.AddWithValue("@Donembts", x_bitis);

                    komut2.ExecuteNonQuery();
                    database.BaglantiKapat();

                    database.BaglantiAc();
                    SqlCommand komut3 = new SqlCommand(@"UPDATE CariBilgileri SET Bakiye=Bakiye+@bedel WHERE AcenteKodu=@kod", database.baglanti);
                    komut3.Parameters.AddWithValue("@kod", kod);
                    komut3.Parameters.AddWithValue("@bedel", hbedel);
                    komut3.ExecuteNonQuery();
                    database.BaglantiKapat();
                    MessageBox.Show("Bilgiler başarıyla kaydedildi.", "Bilgilendirme Penceresi");
                    Properties.Settings.Default.sigorta_sira++;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                database.BaglantiKapat();
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz.", "Bilgilendirme Penceresi");
            }
        }
    }
}
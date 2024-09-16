using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static KararDestekSistemi.Form1;

namespace KararDestekSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
       
        public void Normalizeetme()
        {
            double fiyat, ram, kapasite, boyut, agırlık, EKH, İnesli, garanti, islemcihizi, pil,lisans;
            double maxStarRating;
            double maxReviewCount, maxSCCount, maxFavoriteCount;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {
                connection.Open();

                string getMaxValuesQuery = "SELECT MIN(Fiyat) AS fiyat,MAX(Ram) AS ram,MAX([SSD Kapasitesi]) AS kapasite,MIN(Lisans) AS lisans,MIN([Ekran Boyutu]) AS boyut,MIN([Cihaz Ağırlığı]) AS agırlık,MAX([Ekran Kartı Hafızası]) AS EKH,MAX([İşlemci Nesli]) AS İnesli,MAX([Garanti Süresi]) AS garanti,MAX([Temel İşlemci Hızı (GHz)]) AS islemcihizi,MAX([Şarjlı Kullanım Süresi]) AS pil,MAX([Yıldız Puanı]) AS MaxStarRating, MAX([Değerlendirme Sayısı]) AS MaxReviewCount, MAX([SC Sayısı]) AS MaxSCCount, MAX([Favori Sayısı]) AS MaxFavoriteCount FROM verilerim";
                using (SqlCommand getMaxValuesCommand = new SqlCommand(getMaxValuesQuery, connection))
                {
                    using (SqlDataReader reader = getMaxValuesCommand.ExecuteReader())
                    {
                        reader.Read();
                        fiyat = (double)reader["fiyat"];
                        ram = (double)reader["ram"];
                        kapasite = (double)reader["kapasite"];
                        boyut = (double)reader["boyut"];

                        agırlık = (double)reader["agırlık"];
                        EKH = (double)reader["EKH"];
                        lisans = (double)reader["Lisans"];

                        İnesli = (double)reader["İnesli"];
                        garanti = (double)reader["garanti"];

                        islemcihizi = (double)reader["islemcihizi"];
                        pil = (double)reader["pil"];


                        maxStarRating = (double)reader["MaxStarRating"];
                        maxReviewCount = (double)reader["MaxReviewCount"];
                        maxSCCount = (double)reader["MaxSCCount"];
                        maxFavoriteCount = (double)reader["MaxFavoriteCount"];



                    }
                }

                string selectQuery = "SELECT ID,Fiyat,Ram,[SSD Kapasitesi],Lisans,[Ekran Boyutu],[Cihaz Ağırlığı],[Ekran Kartı Hafızası],[İşlemci Nesli],[Garanti Süresi],[Temel İşlemci Hızı (GHz)],[Şarjlı Kullanım Süresi],[Yıldız Puanı], [Değerlendirme Sayısı], [SC Sayısı], [Favori Sayısı] FROM verilerim";
                string insertQuery = "INSERT INTO yeniverilerim (ID,Fiyat,Ram,[SSD Kapasitesi],Lisans,[Ekran Boyutu],[Cihaz Ağırlığı],[Ekran Kartı Hafızası],[İşlemci Nesli],[Garanti Süresi],[Temel İşlemci Hızı (GHz)],[Şarjlı Kullanım Süresi],[Yıldız Puanı], [Değerlendirme Sayısı], [SC Sayısı], [Favori Sayısı]) " +
                                      "VALUES (@ID,@fiyat,@ram,@kapasite,@lisans,@boyut,@agırlık,@EKH,@İnesli,@garanti,@islemcihizi,@pil,@normalizedStarRating, @normalizedReviewCount, @normalizedSCCount, @normalizedFavoriteCount)";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader selectReader = selectCommand.ExecuteReader())
                    {
                        while (selectReader.Read())
                        {
                            int ID = (int)selectReader["ID"];
                            double fiyatdeger = (double)selectReader["Fiyat"];
                            double ramdeger = (double)selectReader["Ram"];
                            double kapasitedeger = (double)selectReader["SSD Kapasitesi"];
                            double boyutdeger = (double)selectReader["Ekran Boyutu"];

                            double agırlıkdeger = (double)selectReader["Cihaz Ağırlığı"];
                            double EKHdeger = (double)selectReader["Ekran Kartı Hafızası"];
                            double lisansdeger = (double)selectReader["Lisans"];

                            double İneslideger = (double)selectReader["İşlemci Nesli"];
                            double garantideger = (double)selectReader["Garanti Süresi"];

                            double islemcihizideger = (double)selectReader["Temel İşlemci Hızı (GHz)"];
                            double pildeger = (double)selectReader["Şarjlı Kullanım Süresi"];


                            double reviewCount = (double)selectReader["Değerlendirme Sayısı"];
                            double scCount = (double)selectReader["SC Sayısı"];
                            double favoriteCount = (double)selectReader["Favori Sayısı"];

                            double starRatingObject = (double)selectReader["Yıldız Puanı"];




                            double normalizefiyat = fiyatdeger;
                            double normalizeram = (ramdeger / ram);
                            double normalizekapasite = (kapasitedeger / kapasite);
                            double normalizeboyut = boyutdeger;

                            double normalizeagırlık = agırlıkdeger;

                            double normalizeEKH = (EKHdeger / EKH);
                            double normalizelisans = lisansdeger;
                            double normalizeİnesli = (İneslideger / İnesli);
                            double normalizegaranti = (garantideger / garanti);
                            double normalizeislemci = (islemcihizideger / islemcihizi);
                            double normalizepil = (pildeger / pil);
                            double normalizedStarRating = starRatingObject / maxStarRating;
                            double normalizedReviewCount = (reviewCount / maxReviewCount);
                            double normalizedSCCount = (scCount / maxSCCount);
                            double normalizedFavoriteCount = (favoriteCount / maxFavoriteCount);



                            using (SqlConnection insertConnection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
                            {
                                insertConnection.Open();
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, insertConnection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ID", ID);

                                    insertCommand.Parameters.AddWithValue("@fiyat", normalizefiyat);
                                    insertCommand.Parameters.AddWithValue("@ram", normalizeram);
                                    insertCommand.Parameters.AddWithValue("@kapasite", normalizekapasite);
                                    insertCommand.Parameters.AddWithValue("@boyut", normalizeboyut);

                                    insertCommand.Parameters.AddWithValue("@agırlık", normalizeagırlık);
                                    insertCommand.Parameters.AddWithValue("@EKH", normalizeEKH);
                                    insertCommand.Parameters.AddWithValue("@İnesli", normalizeİnesli);
                                    insertCommand.Parameters.AddWithValue("@lisans", normalizelisans);

                                    insertCommand.Parameters.AddWithValue("@garanti", normalizegaranti);

                                    insertCommand.Parameters.AddWithValue("@islemcihizi", normalizeislemci);
                                    insertCommand.Parameters.AddWithValue("@pil", normalizepil);

                                    insertCommand.Parameters.AddWithValue("@normalizedStarRating", normalizedStarRating);
                                    insertCommand.Parameters.AddWithValue("@normalizedReviewCount", normalizedReviewCount);
                                    insertCommand.Parameters.AddWithValue("@normalizedSCCount", normalizedSCCount);
                                    insertCommand.Parameters.AddWithValue("@normalizedFavoriteCount", normalizedFavoriteCount);

                                    insertCommand.ExecuteNonQuery();
                                }
                            }



                        }
                        
                    }
                }
            }



        }
        public void max_min()
        {

            double fiyat, ram, kapasite, boyut, agırlık, EKH, İnesli, garanti, islemcihizi, pil,lisans;
            double maxStarRating;
            double maxReviewCount, maxSCCount, maxFavoriteCount;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {
                connection.Open();

                string getMaxValuesQuery = "SELECT MIN(Fiyat) AS fiyat,MAX(Ram) AS ram,MAX([SSD Kapasitesi]) AS kapasite,MIN(Lisans) AS lisans,MIN([Ekran Boyutu]) AS boyut,MIN([Cihaz Ağırlığı]) AS agırlık,MAX([Ekran Kartı Hafızası]) AS EKH,MAX([İşlemci Nesli]) AS İnesli,MAX([Garanti Süresi]) AS garanti,MAX([Temel İşlemci Hızı (GHz)]) AS islemcihizi,MAX([Şarjlı Kullanım Süresi]) AS pil,MAX([Yıldız Puanı]) AS MaxStarRating, MAX([Değerlendirme Sayısı]) AS MaxReviewCount, MAX([SC Sayısı]) AS MaxSCCount, MAX([Favori Sayısı]) AS MaxFavoriteCount FROM veriler";
                using (SqlCommand getMaxValuesCommand = new SqlCommand(getMaxValuesQuery, connection))
                {
                    using (SqlDataReader reader = getMaxValuesCommand.ExecuteReader())
                    {
                        reader.Read();
                        fiyat = (double)reader["fiyat"];
                        ram = (double)reader["ram"];
                        kapasite = (double)reader["kapasite"];
                        boyut = (double)reader["boyut"];

                        agırlık = (double)reader["agırlık"];
                        EKH = (double)reader["EKH"];

                        İnesli = (double)reader["İnesli"];
                        lisans = (double)reader["Lisans"];

                        garanti = (double)reader["garanti"];

                        islemcihizi = (double)reader["islemcihizi"];
                        pil = (double)reader["pil"];


                        maxStarRating = (double)reader["MaxStarRating"];
                        maxReviewCount = (double)reader["MaxReviewCount"];
                        maxSCCount = (double)reader["MaxSCCount"];
                        maxFavoriteCount = (double)reader["MaxFavoriteCount"];



                    }
                }

                string selectQuery = "SELECT ID,Fiyat,Ram,[SSD Kapasitesi],Lisans,[Ekran Boyutu],[Cihaz Ağırlığı],[Ekran Kartı Hafızası],[İşlemci Nesli],[Garanti Süresi],[Temel İşlemci Hızı (GHz)],[Şarjlı Kullanım Süresi],[Yıldız Puanı], [Değerlendirme Sayısı], [SC Sayısı], [Favori Sayısı] FROM veriler";
                string insertQuery = "INSERT INTO verilerim (ID,Fiyat,Ram,[SSD Kapasitesi],Lisans,[Ekran Boyutu],[Cihaz Ağırlığı],[Ekran Kartı Hafızası],[İşlemci Nesli],[Garanti Süresi],[Temel İşlemci Hızı (GHz)],[Şarjlı Kullanım Süresi],[Yıldız Puanı], [Değerlendirme Sayısı], [SC Sayısı], [Favori Sayısı]) " +
                                      "VALUES (@ID,@fiyat,@ram,@kapasite,@lisans,@boyut,@agırlık,@EKH,@İnesli,@garanti,@islemcihizi,@pil,@normalizedStarRating, @normalizedReviewCount, @normalizedSCCount, @normalizedFavoriteCount)";
                List<double> deger = new List<double>();
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader selectReader = selectCommand.ExecuteReader())
                    {
                        while (selectReader.Read())
                        {
                            int ID = (int)selectReader["ID"];
                            double fiyatdeger = (double)selectReader["Fiyat"];
                            double ramdeger = (double)selectReader["Ram"];
                            double kapasitedeger = (double)selectReader["SSD Kapasitesi"];
                            double boyutdeger = (double)selectReader["Ekran Boyutu"];

                            double agırlıkdeger = (double)selectReader["Cihaz Ağırlığı"];
                            double EKHdeger = (double)selectReader["Ekran Kartı Hafızası"];

                            double İneslideger = (double)selectReader["İşlemci Nesli"];
                            double lisansdeger = (double)selectReader["Lisans"];
                            double garantideger = (double)selectReader["Garanti Süresi"];

                            double islemcihizideger = (double)selectReader["Temel İşlemci Hızı (GHz)"];
                            double pildeger = (double)selectReader["Şarjlı Kullanım Süresi"];


                            double reviewCount = (double)selectReader["Değerlendirme Sayısı"];
                            double scCount = (double)selectReader["SC Sayısı"];
                            double favoriteCount = (double)selectReader["Favori Sayısı"];

                            double starRatingObject = (double)selectReader["Yıldız Puanı"];

                       
                            

                            double normalizefiyat = (fiyat / fiyatdeger);
                            double normalizeram = (ram / ramdeger);
                            double normalizekapasite = (kapasite / kapasitedeger);
                            double normalizeboyut = (boyut / boyutdeger);
                            double normalizeagırlık = (agırlık / agırlıkdeger);

                            double normalizeEKH = ( EKH/ EKHdeger);
                            double normalizelisans = lisans/lisansdeger;

                            double normalizeİnesli = (İnesli / İneslideger);
                            double normalizegaranti = (garanti / garantideger);
                            double normalizeislemci = (islemcihizi / islemcihizideger);
                            double normalizepil = (pil / pildeger);
                            double normalizedStarRating = maxStarRating / starRatingObject;
                            double normalizedReviewCount = (maxReviewCount / reviewCount);
                            double normalizedSCCount = (maxSCCount / scCount);
                            double normalizedFavoriteCount = (maxFavoriteCount /favoriteCount);

                        using (SqlConnection insertConnection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
                        {
                            insertConnection.Open();
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, insertConnection))
                            {
                                insertCommand.Parameters.AddWithValue("@ID", ID);

                                insertCommand.Parameters.AddWithValue("@fiyat", normalizefiyat);
                                insertCommand.Parameters.AddWithValue("@ram", normalizeram);
                                insertCommand.Parameters.AddWithValue("@kapasite", normalizekapasite);
                                insertCommand.Parameters.AddWithValue("@boyut", normalizeboyut);

                                insertCommand.Parameters.AddWithValue("@agırlık", normalizeagırlık);
                                insertCommand.Parameters.AddWithValue("@EKH", normalizeEKH);
                                insertCommand.Parameters.AddWithValue("@İnesli", normalizeİnesli);
                                insertCommand.Parameters.AddWithValue("@lisans", normalizelisans);

                                insertCommand.Parameters.AddWithValue("@garanti", normalizegaranti);

                                insertCommand.Parameters.AddWithValue("@islemcihizi", normalizeislemci);
                                insertCommand.Parameters.AddWithValue("@pil", normalizepil);

                                insertCommand.Parameters.AddWithValue("@normalizedStarRating", normalizedStarRating);
                                insertCommand.Parameters.AddWithValue("@normalizedReviewCount", normalizedReviewCount);
                                insertCommand.Parameters.AddWithValue("@normalizedSCCount", normalizedSCCount);
                                insertCommand.Parameters.AddWithValue("@normalizedFavoriteCount", normalizedFavoriteCount);

                                                insertCommand.ExecuteNonQuery();

                     }
                    }
                                   }
                            }
                            }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button7.Visible = false;
            button8.Visible = false;
            DataTable dataTable = new DataTable();
            string query = "Select * FROM veriler";


            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {
                // SqlDataAdapter ve DataTable oluştur
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);


                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void kriterler()
        {
            double w1 = 19.66;
            double w2 = 14.99;
            double w3 = 17.82;
            double w4 = 10.92;
            double w5 = 6.99;
            double w6 = 4.23;
            double w7 = 0;
            double w8 = 10.71;
            double w9 = 69.26;
            double w10 = 0;
            double w11 = 0;
            double w12 = 25.52;
            double w13 = 26.76;
            double w14 = 15.49;
            double w15 = 18.34;
            double WÖZ = 49.21;
            double WM = 24.25;
            double WD = 11.62;

            double[] weights1 = { w1, w2, w3, w4, w5, w6, w7, w8 };
            double[] weights2 = { w9, w10, w11 };

            double[] weights3 = { w12, w13, w14, w15 };
            double[] weightsTotal = { WÖZ, WM, WD };

            double toplam1 = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;
            double toplam2 = w9 + w10 + w11;
            double toplam3 = w12 + w13 + w14 + w15;
            double toplam4 = WÖZ + WM + WD;


            double[] normalizedWeights1 = NormalizeWeights(weights1, toplam1);
            double[] normalizedWeights2 = NormalizeWeights(weights2, toplam2);
            double[] normalizedWeights3 = NormalizeWeights(weights3, toplam3);
            double[] normalizedWeightsTotal = NormalizeWeights(weightsTotal, toplam4);


        }
        private void button6_Click(object sender, EventArgs e)
        {


            DataTable resultTable = new DataTable();
            List<string> listBoxResults = new List<string>();

            // DataTable4'ün içindeki verileri al
            DataTable dataTable4 = (DataTable)dataGridView1.DataSource;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {
                // İkinci DataTable verilerini çek
                string selectQuery2 = "SELECT t1.* FROM veriler t1 INNER JOIN sonuc t2 ON t1.ID = t2.ID ORDER BY t2.Fdeger DESC, t1.ID ASC";
                using (SqlCommand selectCommand2 = new SqlCommand(selectQuery2, connection))
                using (SqlDataAdapter dataAdapter3 = new SqlDataAdapter(selectCommand2))
                {
                    DataTable dataTable3 = new DataTable();

                    dataAdapter3.Fill(dataTable3);

                    // Eşleşen satırları bul
                    var matchedRows = from row1 in dataTable3.AsEnumerable()
                                      join row2 in dataTable4.AsEnumerable() on row1.Field<int>("ID") equals row2.Field<int>("ID")
                                      select row1;

                    // Eşleşen satırları resultTable'a ekleyin

                    resultTable = matchedRows.CopyToDataTable();

                    // Sonuçları ListBox'a ekle
                    foreach (DataRow row in resultTable.Rows)
                    {
                        listBoxResults.Add($"ID: {row["ID"]}, Marka: {row["Marka"]}, Fiyat: {row["Fiyat"] + "TL"}, Yıldız Puanı: {row["Yıldız Puanı"]}, Degerlendirme: {row["Değerlendirme Sayısı"]}, Soru-Cevap: { row["SC Sayısı"]}, Favori Sayısı: { row["Favori Sayısı"]}, İslemci Tipi: { row["İşlemci Tipi"]}," +
                            $"Ram: {row["Ram"]},SSD : {row["SSD Kapasitesi"]},Ekran Boyutu: {row["Ekran Boyutu"]},Kullanım Amacı: {row["Kullanım Amacı"]}"); // DiğerSutunAdi'yi kendi verilerinizle değiştirin
                    }

                    // ListBox'a sonuçları ekle
                    //listBox1.Items.Clear();
                    //listBox1.Items.AddRange(listBoxResults.ToArray());
                }
            }

            // Sonucu göster
            dataGridView1.DataSource = resultTable;




        }
        static double[] NormalizeWeights(double[] weights, double total)
        {
            double[] normalizedWeights = new double[weights.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                normalizedWeights[i] = weights[i] / total;
            }
            return normalizedWeights;
        }
        List<string> selectedBrandsList = new List<string>();
        List<string> Selectedchecbox = new List<string>();
        List<string> HddKapasitesi = new List<string>();
        List<string> EkranBoyutu = new List<string>();
        List<string> RamBellek = new List<string>();
       
       
        private void seçimler()
        {
            selectedBrandsList.Clear();

            if (checkBox1.Checked)
            {  
                    selectedBrandsList.Add(checkBox1.Text);
            }

            if (checkBox2.Checked)
            {
                selectedBrandsList.Add(checkBox2.Text);
            }
            if (checkBox3.Checked)
            {
                selectedBrandsList.Add(checkBox3.Text);
            }
            if (checkBox4.Checked)
            {
                selectedBrandsList.Add(checkBox4.Text);
            }
            if (checkBox5.Checked)
            {
                selectedBrandsList.Add(checkBox5.Text);
            }
            if (checkBox6.Checked)
            {
                selectedBrandsList.Add(checkBox6.Text);
            }
            //if (checkBox7.Checked)
            //{
            //    selectedBrandsList.Add(checkBox7.Text);
            //}
            //if (checkBox8.Checked)
            //{
            //    selectedBrandsList.Add(checkBox8.Text);
            //}
          
        }
        private void SSDKapasitesi()
        {
            Selectedchecbox.Clear();

            if (checkBox30.Checked)
            {
                Selectedchecbox.Add("0 GB-240 GB");
             }

            if (checkBox32.Checked)
            {
                Selectedchecbox.Add("240 GB-512 GB");
            }
            if (checkBox33.Checked)
            {
                Selectedchecbox.Add("1 TB");
            }
            if (checkBox34.Checked)
            {
                Selectedchecbox.Add("2-4 TB");

            }
            if (checkBox31.Checked)
            {
                Selectedchecbox.Add("SSD Yok");

            }
        }
        private void HDD()
        {
            HddKapasitesi.Clear();
            if (checkBox40.Checked)
            {

                HddKapasitesi.Add("128 GB - 500 GB");
            }

            if (checkBox41.Checked)
            {

                HddKapasitesi.Add("512 GB - 1 TB");
            }
            if (checkBox42.Checked)
            {

                HddKapasitesi.Add("1 TB - 4 TB");
            }
            if (checkBox43.Checked)
            {

                HddKapasitesi.Add("4 TB - 12 TB");
            }
            if (checkBox45.Checked)
            {

                HddKapasitesi.Add("HDD Yok");
            }
        }
        private void Ekranboyut()
        {
            EkranBoyutu.Clear();
            if (checkBox57.Checked)
            {
                EkranBoyutu.Add("13 inç ve altı");

            }
            if (checkBox47.Checked)
            {
                EkranBoyutu.Add("13,3 inç - 15 inç");

            }

            if (checkBox48.Checked)
            {
                EkranBoyutu.Add("15,6 inç-17.6 inç");

            }
            if (checkBox49.Checked)
            {
                EkranBoyutu.Add("18 inç - 21 inç");

            }
            if (checkBox50.Checked)
            {
                EkranBoyutu.Add("21,5 inç - 24,5 inç");

            }
            if (checkBox51.Checked)
            {
                EkranBoyutu.Add("25 inç -27 inç");

            }
          

        }
        private void RAM()
        {

            RamBellek.Clear();
            if (checkBox35.Checked)
            {
                RamBellek.Add("1 GB - 3 GB");

            }
            if (checkBox36.Checked)
            {
                RamBellek.Add("4 GB - 6 GB");

            }

            if (checkBox37.Checked)
            {
                RamBellek.Add("8 GB - 12 GB");

            }
            if (checkBox38.Checked)
            {
                RamBellek.Add("12 GB - 16 GB");

            }
            if (checkBox39.Checked)
            {
                RamBellek.Add("20 GB - 24 GB");

            }
            if (checkBox53.Checked)
            {
                RamBellek.Add("32 GB - 36 GB");

            }
            if (checkBox58.Checked)
            {
                RamBellek.Add("40 GB - 48 GB");

            }
            if (checkBox55.Checked)
            {
                RamBellek.Add("64 GB - 96 GB");

            }
            if (checkBox56.Checked)
            {
                RamBellek.Add("96 GB+");

            }
        }

        DataTable dataTable = new DataTable();
        DataTable dataTable4 = new DataTable();

        List<double> veriler = new List<double>();
        //Filtreleme butonu
        private void button5_Click(object sender, EventArgs e)
        {
            string Kamacı = comboBox2.Text;
            string EkranTipi = comboBox5.Text;
            string IslemciNesli = comboBox4.Text;
            string İslemcitipi = comboBox9.Text;
            string Garanti = comboBox10.Text;
            // Sorgu
            string query = "SELECT * FROM veriler WHERE 1=1";
            //Fiyat

            double minPrice, maxPrice;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                     double.TryParse(textBox1.Text, out minPrice) && double.TryParse(textBox2.Text, out maxPrice))
            {
                query += $" AND Fiyat BETWEEN {minPrice} AND {maxPrice}";
            }



            if (!string.IsNullOrEmpty(Kamacı))
            {
                query += " AND [Kullanım Amacı] = @Kamacı";
            }

            if (!string.IsNullOrEmpty(EkranTipi))
            {
                query += " AND [Ekran Kartı Tipi] = @EkranTipi";
            }

            if (!string.IsNullOrEmpty(IslemciNesli))
            {
                query += " AND [İşlemci Nesli] = @IslemciNesli";
            }

            
            if (!string.IsNullOrEmpty(İslemcitipi))
            {
               query += " AND [İşlemci Tipi] = @İslemcitipi";

            }

            if (!string.IsNullOrEmpty(Garanti))
            {
                query += " AND [Garanti Süresi] = @Garanti";

            }
            //Marka
            seçimler();
            string[] selectedBrands = selectedBrandsList.ToArray();

            if (selectedBrandsList.Count > 0)
            {

                query += " AND (";

                for (int i = 0; i < selectedBrands.Length; i++)
                {
                    if (i > 0)
                    {
                        query += " OR";
                    }

                    query += $" [Marka] = @Brand{i}";
                }

                query += ")";
            }

            //SSD kapasitesi
            SSDKapasitesi();
            string[] selectedSSDCapacitiesArray = Selectedchecbox.ToArray();

            if (Selectedchecbox.Count > 0)
            {
                query += " AND (";

                for (int i = 0; i < selectedSSDCapacitiesArray.Length; i++)
                {
                    if (i > 0)
                    {
                        query += " OR";
                    }
                    switch (selectedSSDCapacitiesArray[i])
                    {
                        case "0 GB-240 GB":
                            query += " [SSD Kapasitesi]  BETWEEN 0 AND 240";
                            break;
                        case "240 GB-512 GB":
                            query += " [SSD Kapasitesi] BETWEEN 240 AND 512";
                            break;
                        case "1 TB":
                            query += " [SSD Kapasitesi] = '1024'";
                            break;
                        case "2-4 TB":
                            query += " [SSD Kapasitesi] BETWEEN 2048 AND 4096";
                            break;
                        case "SSD Yok":
                            query += " [SSD Kapasitesi] = '0'";
                            break;
                        case "Yok":
                            query += " [SSD Kapasitesi] BETWEEN 0 AND 4096";
                            break;

                    }
                }
                 query += ")";
          }


            // HDD kapasitesi
            HDD();
            string[] hddkapasitesi=HddKapasitesi.ToArray() ;
            if (HddKapasitesi.Count > 0)
            {
                query += " AND (";

                for (int i = 0; i < hddkapasitesi.Length; i++)
                {
                    if (i > 0)
                    {
                        query += " OR";
                    }

                    switch (hddkapasitesi[i])
                    {
                        case "128 GB - 500 GB":
                            query += " [Hard Disk Kapasitesi] IN ('128 GB', '256 GB', '500 GB')";
                            break;
                        case "512 GB - 1 TB":
                            query += " [Hard Disk Kapasitesi] IN ('512 GB', '1 TB')";
                            break;
                        case "1 TB - 4 TB":
                            query += " [Hard Disk Kapasitesi] IN ('1 TB', '2 TB', '4 TB')";
                            break;
                        case "4 TB - 12 TB":
                            query += " [Hard Disk Kapasitesi] IN ('4 TB', '8 TB', '12 TB')";
                            break;
                        case "HDD Yok":
                            query += " [Hard Disk Kapasitesi] = 'HDD Yok'";
                            break;
                    }
                }

                query += ")";
            }
            //Ekran Boyutu
            Ekranboyut();
            string[] ekran = EkranBoyutu.ToArray();

            if (EkranBoyutu.Count > 0)
            {
                query += " AND (";
              
                for (int i=0;i<ekran.Length;i++)   
                {
                    if (i > 0)
                    {
                        query += " OR";
                    }
                   switch (ekran[i])
        {
            case "13 inç ve altı":
                query += " [Ekran Boyutu] <= 13";
                break;
            case "13,3 inç - 15 inç":
                query += " [Ekran Boyutu] BETWEEN 13.3 AND 15";
                break;
            case "15,6 inç-17.6 inç":
                query += " [Ekran Boyutu] BETWEEN 15.6 AND 17.6";
                break;
            case "18 inç - 21 inç":
                query += " [Ekran Boyutu] BETWEEN 18 AND 21";
                break;
            case "21,5 inç - 24,5 inç":
                query += " [Ekran Boyutu] BETWEEN 21.5 AND 24.5";
                break;
            case "25 inç -27 inç":
                query += " [Ekran Boyutu] BETWEEN 25 AND 27";
                break;
        }
                    


                }
                query += ")";

            }
            //Ram
            RAM();
            string[] rambellekkapasite = RamBellek.ToArray();

            if (RamBellek.Count > 0)
            {
                query += " AND (";
                for (int i = 0; i < rambellekkapasite.Length; i++)
                {
                    if (i > 0)
                    {
                        query += " OR";
                    }

                    switch (rambellekkapasite[i])
                    {
                        case "1 GB - 3 GB":
                            query += " [Ram] >= 1 AND [Ram] <= 3";
                            break;
                        case "4 GB - 6 GB":
                            query += " [Ram] >= 4 AND [Ram] <= 6";
                            break;
                        case "8 GB - 12 GB":
                            query += " [Ram] >= 8 AND [Ram] <= 12";
                            break;
                        case "12 GB - 16 GB":
                            query += " [Ram] >= 12 AND [Ram] <= 16";
                            break;
                        case "16 GB - 20 GB":
                            query += " [Ram] >= 16 AND [Ram] <= 20";
                            break;
                        case "20 GB - 24 GB":
                            query += " [Ram] >= 20 AND [Ram] <= 24";
                            break;
                        case "32 GB - 36 GB":
                            query += " [Ram] >= 32 AND [Ram] <= 36";
                            break;
                        case "40 GB - 48 GB":
                            query += " [Ram] >= 40 AND [Ram] <= 48";
                            break;
                        case "64 GB - 96 GB":
                            query += " [Ram] >= 64 AND [Ram] <= 96";
                            break;
                        case "96 GB+":
                            query += " [Ram] >= 96 AND [Ram] <= 128";
                            break;
                    }
                }

                    query += ")";

            }
            //Lisans
            string selectedValue = checkBox46.Text;
            if (checkBox46.Checked)
            {
                query += " AND Lisans= 1 ";
               
            }
            else if (!checkBox46.Checked)
            {
                query += " AND Lisans= 2 ";
            }



            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {
                  
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                    if (!string.IsNullOrEmpty(Kamacı))
                    {
                        command.Parameters.AddWithValue("@Kamacı", Kamacı);
                    }

                    if (!string.IsNullOrEmpty(EkranTipi))
                    {
                        command.Parameters.AddWithValue("@EkranTipi", EkranTipi);
                    }

                    if (!string.IsNullOrEmpty(IslemciNesli) )
                    {
                        command.Parameters.AddWithValue("@IslemciNesli", IslemciNesli);
                    }

                    if (!string.IsNullOrEmpty(İslemcitipi))
                    {
                        command.Parameters.AddWithValue("@İslemcitipi", İslemcitipi);
                    }
                    if (!string.IsNullOrEmpty(Garanti))
                    {
                        command.Parameters.AddWithValue("@Garanti", Garanti);
                    }
                    for (int i = 0; i < selectedBrands.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@Brand{i}", selectedBrands[i]);
                    }

                    for (int i = 0; i < selectedSSDCapacitiesArray.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@Brandi{i}", selectedSSDCapacitiesArray[i]);
                    }
                    for (int i = 0; i < hddkapasitesi.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@Brandim{i}", hddkapasitesi[i]);
                    }
                    for (int i = 0; i < ekran.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@Ekran{i}", ekran[i]);
                    }
                    for (int i = 0; i < rambellekkapasite.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@Ram{i}", rambellekkapasite[i]);
                    }
                    command.Parameters.AddWithValue("@Lisans", selectedValue);


                    dataTable4.Clear();


                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {

                            try
                            {
                                connection.Open();
                                dataAdapter.Fill(dataTable4);
                            dataGridView1.DataSource = null;

                            dataGridView1.DataSource = dataTable4;
                            
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Veri çekme hatası: " + ex.Message);

                            }
                        }
                    }
                }
            }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Ev - Okul")
            {
                checkBox42.Enabled = false;
                checkBox43.Enabled = false;
                checkBox57.Enabled = true;
                checkBox51.Enabled = true;
                checkBox47.Enabled = true;
                checkBox35.Enabled = true;
                comboBox10.Items.Clear();
                comboBox10.Items.Add("1");
                comboBox10.Items.Add("2");
                comboBox10.Items.Add("3");

            }
           else if (comboBox2.Text == "Ofis - İş")
            {
                checkBox42.Enabled = true;
                checkBox43.Enabled = true;
                checkBox57.Enabled = true;
                checkBox51.Enabled = true;
                checkBox47.Enabled = true;
                checkBox35.Enabled = true;
                comboBox10.Items.Clear();
                comboBox10.Items.Add("2");
                comboBox10.Items.Add("3");
                comboBox10.Items.Add("5");

            }
           else if (comboBox2.Text == "Oyun")
            {
                checkBox57.Enabled = false;
                checkBox47.Enabled = false;
                checkBox35.Enabled = false;
                checkBox42.Enabled = true;
                checkBox43.Enabled = true;
                checkBox51.Enabled = true;
                comboBox10.Items.Clear();
                comboBox10.Items.Add("2");
                comboBox10.Items.Add("3");

                
            }
            else if (comboBox2.Text == "Tasarım")
            {
                checkBox35.Enabled = false;
                checkBox51.Enabled = false;
                checkBox57.Enabled = true;
                checkBox42.Enabled = true;
                checkBox47.Enabled = true;
                checkBox43.Enabled = true;
                checkBox51.Enabled = true;
               
                comboBox10.Items.Clear();
              
                comboBox10.Items.Add("2");

            }
            
                

            
           

        }


       


       
        

      

       

       

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
         //   max_min();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Normalizeetme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kriterler kr = new Kriterler();
            kr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
    


   

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KararDestekSistemi
{
    public partial class Kriterler : Form
    {

        public Kriterler()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBoxTextChanged;
            textBox2.TextChanged += TextBoxTextChanged;
            textBox3.TextChanged += TextBoxTextChanged;
            textBox4.TextChanged += TextBoxTextChanged;
            textBox5.TextChanged += TextBoxTextChanged;
            textBox6.TextChanged += TextBoxTextChanged;
            textBox7.TextChanged += TextBoxTextChanged;
            textBox8.TextChanged += TextBoxTextChanged;
           
            textBox9.TextChanged += TextBox1TextChanged;
            textBox10.TextChanged += TextBox1TextChanged;
            textBox11.TextChanged += TextBox1TextChanged;


            textBox12.TextChanged += TextBox2TextChanged;
            textBox13.TextChanged += TextBox2TextChanged;
            textBox14.TextChanged += TextBox2TextChanged;
            textBox15.TextChanged += TextBox2TextChanged;

            textBox16.TextChanged += TextBox3TextChanged;
            textBox17.TextChanged += TextBox3TextChanged;
            textBox18.TextChanged += TextBox3TextChanged;





        }
        private void TextBox3TextChanged(object sender, EventArgs e)
        {
            HesaplaToplamAnakriter();
        }
        private void TextBox2TextChanged(object sender, EventArgs e)
        {
            HesaplaToplamDeneyim();
        }
        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            HesaplaToplamMaliyet();
        }
        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            HesaplaToplam();
        }
        private void HesaplaToplamMaliyet()
        {
            if (float.TryParse(textBox9.Text, out float deger9) &&
             float.TryParse(textBox10.Text, out float deger10) &&
             float.TryParse(textBox11.Text, out float deger11))
            {
                float toplam = deger9 + deger10 + deger11;
                label24.Text = "Toplam: " + toplam.ToString();
            }
            else
            {
                label24.Text = "Lütfen sayısal bir değer girin";
            }

        }
        private void HesaplaToplamDeneyim()
        {
            if (float.TryParse(textBox12.Text, out float deger12) &&
             float.TryParse(textBox13.Text, out float deger13) &&
             float.TryParse(textBox14.Text, out float deger14) &&
             float.TryParse(textBox15.Text, out float deger15))
            {
                float toplam = deger12 + deger13 + deger14+deger15;
                label22.Text = "Toplam: " + toplam.ToString();
            }
            else
            {
                label22.Text = "Lütfen sayısal bir değer girin";
            }

        }
        private void HesaplaToplamAnakriter()
        {
            if (float.TryParse(textBox16.Text, out float deger16) &&
          float.TryParse(textBox17.Text, out float deger17) &&
          float.TryParse(textBox18.Text, out float deger18))
            {
                float toplam = deger16 + deger17 + deger18;
                label26.Text = "Toplam: " + toplam.ToString();
            }
            else
            {
                label26.Text = "Lütfen sayısal bir değer girin";
            }

        }
        private void HesaplaToplam()
        {
            if (float.TryParse(textBox1.Text, out float deger1) &&
               float.TryParse(textBox2.Text, out float deger2) &&
               float.TryParse(textBox3.Text, out float deger3) &&
               float.TryParse(textBox4.Text, out float deger4) &&
               float.TryParse(textBox5.Text, out float deger5) &&
               float.TryParse(textBox6.Text, out float deger6) &&
               float.TryParse(textBox7.Text, out float deger7) &&
               float.TryParse(textBox8.Text, out float deger8))
            {
                float toplam = deger1 + deger2 + deger3 + deger4 + deger5 + deger6 + deger7 + deger8;
                label19.Text = "Toplam: " + toplam.ToString();
            }
            else
            {
                label19.Text = "Lütfen sayısal bir değer girin";
            }

        }



    
        private void button1_Click(object sender, EventArgs e)
        {
            toplam();
        
           
        }
        private void toplam()
        {
            List<double> numbers = new List<double>();
            List<double> numbers1 = new List<double>();
            List<double> numbers2 = new List<double>();
            List<double> numbers3 = new List<double>();

            if (!string.IsNullOrEmpty(textBox1.Text))
                numbers.Add(Convert.ToDouble(textBox1.Text));
            if (!string.IsNullOrEmpty(textBox2.Text))
                numbers.Add(Convert.ToDouble(textBox2.Text));
            if (!string.IsNullOrEmpty(textBox3.Text))
                numbers.Add(Convert.ToDouble(textBox3.Text));
            if (!string.IsNullOrEmpty(textBox4.Text))
                numbers.Add(Convert.ToDouble(textBox4.Text));
            if (!string.IsNullOrEmpty(textBox5.Text))
                numbers.Add(Convert.ToDouble(textBox5.Text));
            if (!string.IsNullOrEmpty(textBox6.Text))
                numbers.Add(Convert.ToDouble(textBox6.Text));
            if (!string.IsNullOrEmpty(textBox7.Text))
                numbers.Add(Convert.ToDouble(textBox7.Text));
            if (!string.IsNullOrEmpty(textBox8.Text))
                numbers.Add(Convert.ToDouble(textBox8.Text));

            if (!string.IsNullOrEmpty(textBox9.Text))
                numbers1.Add(Convert.ToDouble(textBox9.Text));
            if (!string.IsNullOrEmpty(textBox10.Text))
                numbers1.Add(Convert.ToDouble(textBox10.Text));
            if (!string.IsNullOrEmpty(textBox11.Text))
                numbers1.Add(Convert.ToDouble(textBox11.Text));

            if (!string.IsNullOrEmpty(textBox12.Text))
                numbers2.Add(Convert.ToDouble(textBox12.Text));
            if (!string.IsNullOrEmpty(textBox13.Text))
                numbers2.Add(Convert.ToDouble(textBox13.Text));
            if (!string.IsNullOrEmpty(textBox14.Text))
                numbers2.Add(Convert.ToDouble(textBox14.Text));
            if (!string.IsNullOrEmpty(textBox15.Text))
                numbers2.Add(Convert.ToDouble(textBox15.Text));
            if (!string.IsNullOrEmpty(textBox16.Text))

                numbers3.Add(Convert.ToDouble(textBox16.Text));
            if (!string.IsNullOrEmpty(textBox17.Text))
                numbers3.Add(Convert.ToDouble(textBox17.Text));
            if (!string.IsNullOrEmpty(textBox18.Text))
                numbers3.Add(Convert.ToDouble(textBox18.Text));

            double total = numbers.Sum();
            double total1 = numbers1.Sum();
            double total2 = numbers2.Sum();
            double total3 = numbers3.Sum();

            if (total > 100 || total1>100 || total2 > 100 || total3 > 100)
            {

                MessageBox.Show("Toplam 100'ü geçiyor!");
                
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
                {
                    string updateQuery = "UPDATE kriterler SET Fiyat = @Fiyat, [Yıldız Puanı] = @YildizPuani, [Değerlendirme Sayısı] = @DegerlendirmeSayisi, [SC Sayısı] = @SCSayisi, [Favori Sayısı] = @FavoriSayisi, Ram = @Ram, [SSD Kapasitesi] = @SSDKapasitesi, Lisans = @Lisans, [Ekran Boyutu] = @EkranBoyutu, [Cihaz Ağırlığı] = @CihazAgirligi, [Ekran Kartı Hafızası] = @EkranKartiHafizasi, [İşlemci Nesli] = @IslemciNesli, [Garanti Süresi] = @GarantiSuresi, [Temel İşlemci Hızı (GHz)] = @TemelIslemciHizi, [Şarjlı Kullanım Süresi] = @SarjliKullanimSuresi, Özellik_kriterleri = @OzellikKriterleri, Maliyet_kriterleri = @MaliyetKriterleri, Deneyim_kriterleri = @DeneyimKriterleri WHERE ID = 1";

                    using (SqlCommand komut = new SqlCommand(updateQuery, connection))
                    {

                        komut.Parameters.AddWithValue("@Fiyat", float.Parse(textBox9.Text));
                        komut.Parameters.AddWithValue("@YildizPuani", float.Parse(textBox12.Text));
                        komut.Parameters.AddWithValue("@DegerlendirmeSayisi", float.Parse(textBox13.Text));
                        komut.Parameters.AddWithValue("@SCSayisi", float.Parse(textBox14.Text));
                        komut.Parameters.AddWithValue("@FavoriSayisi", float.Parse(textBox15.Text));

                        komut.Parameters.AddWithValue("@Ram", float.Parse(textBox3.Text));
                        komut.Parameters.AddWithValue("@SSDKapasitesi", float.Parse(textBox4.Text));
                        komut.Parameters.AddWithValue("@Lisans", float.Parse(textBox11.Text));
                        komut.Parameters.AddWithValue("@EkranBoyutu", float.Parse(textBox7.Text));
                        komut.Parameters.AddWithValue("@CihazAgirligi", float.Parse(textBox6.Text));

                        komut.Parameters.AddWithValue("@EkranKartiHafizasi", float.Parse(textBox2.Text));
                        komut.Parameters.AddWithValue("@IslemciNesli", float.Parse(textBox8.Text));
                        komut.Parameters.AddWithValue("@GarantiSuresi", float.Parse(textBox10.Text));
                        komut.Parameters.AddWithValue("@TemelIslemciHizi", float.Parse(textBox1.Text));
                        komut.Parameters.AddWithValue("@SarjliKullanimSuresi", float.Parse(textBox5.Text));

                        komut.Parameters.AddWithValue("@OzellikKriterleri", float.Parse(textBox16.Text));
                        komut.Parameters.AddWithValue("@MaliyetKriterleri", float.Parse(textBox17.Text));
                        komut.Parameters.AddWithValue("@DeneyimKriterleri", float.Parse(textBox18.Text));
                        connection.Open();

                        komut.ExecuteNonQuery();

                        button2.Enabled = true;
                    }
                    




                }
               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kaydetagırlık();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();

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
        public void Kaydetagırlık()
        {



            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
            {

                connection.Open();
                string deleteQuery = "DELETE FROM Sonuc";
                using (SqlConnection deleteConnection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
                {
                    deleteConnection.Open();
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, deleteConnection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                }

                // Ağırlıkları çek
                string selectQueryKriterler = "SELECT * FROM kriterler WHERE ID = 1";

                using (SqlCommand selectCommandKriterler = new SqlCommand(selectQueryKriterler, connection))
                using (SqlDataReader readerKriterler = selectCommandKriterler.ExecuteReader())
                {
                    if (readerKriterler.Read())
                    {
                        double w1 = Convert.ToDouble(readerKriterler["Temel İşlemci Hızı (GHz)"]);
                        double w2 = Convert.ToDouble(readerKriterler["Ekran Kartı Hafızası"]);
                        double w3 = Convert.ToDouble(readerKriterler["Ram"]);
                        double w4 = Convert.ToDouble(readerKriterler["SSD Kapasitesi"]);
                        double w5 = Convert.ToDouble(readerKriterler["Şarjlı Kullanım Süresi"]);
                        double w6 = Convert.ToDouble(readerKriterler["Cihaz Ağırlığı"]);
                        double w7 = Convert.ToDouble(readerKriterler["Ekran Boyutu"]);
                        double w8 = Convert.ToDouble(readerKriterler["İşlemci Nesli"]);
                        double w9 = Convert.ToDouble(readerKriterler["Fiyat"]);
                        double w10 = Convert.ToDouble(readerKriterler["Garanti Süresi"]);
                        double w11 = Convert.ToDouble(readerKriterler["Lisans"]);
                        double w12 = Convert.ToDouble(readerKriterler["Yıldız Puanı"]);
                        double w13 = Convert.ToDouble(readerKriterler["Değerlendirme Sayısı"]);
                        double w14 = Convert.ToDouble(readerKriterler["SC Sayısı"]);
                        double w15 = Convert.ToDouble(readerKriterler["Favori Sayısı"]);
                        double WOZ = Convert.ToDouble(readerKriterler["Özellik_kriterleri"]);
                        double WM = Convert.ToDouble(readerKriterler["Maliyet_kriterleri"]);
                        double WD = Convert.ToDouble(readerKriterler["Deneyim_kriterleri"]);

                        double[] weights1 = { w1, w2, w3, w4, w5, w6, w7, w8 };
                        double[] weights2 = { w9, w10, w11 };
                        double[] weights3 = { w12, w13, w14, w15 };
                        double[] weightsTotal = { WOZ, WM, WD };

                        double toplam1 = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;
                        double toplam2 = w9 + w10 + w11;
                        double toplam3 = w12 + w13 + w14 + w15;
                        double toplam4 = WOZ + WM + WD;

                        double[] normalizedWeights1 = NormalizeWeights(weights1, toplam1);
                        double[] normalizedWeights2 = NormalizeWeights(weights2, toplam2);
                        double[] normalizedWeights3 = NormalizeWeights(weights3, toplam3);
                        double[] normalizedWeightsTotal = NormalizeWeights(weightsTotal, toplam4);
                        readerKriterler.Close();
                        // Verileri çek ve işle
                        string selectQuery = "SELECT ID,Fiyat,Ram,[SSD Kapasitesi],Lisans,[Ekran Boyutu],[Cihaz Ağırlığı],[Ekran Kartı Hafızası],[İşlemci Nesli],[Garanti Süresi],[Temel İşlemci Hızı (GHz)],[Şarjlı Kullanım Süresi],[Yıldız Puanı], [Değerlendirme Sayısı], [SC Sayısı], [Favori Sayısı] FROM yeniverilerim";

                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
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
                                double garantideger = (double)selectReader["Garanti Süresi"];
                                double lisansdeger = (double)selectReader["Lisans"];
                                double islemcihizideger = (double)selectReader["Temel İşlemci Hızı (GHz)"];
                                double pildeger = (double)selectReader["Şarjlı Kullanım Süresi"];
                                double starRating = (double)selectReader["Yıldız Puanı"];
                                double reviewCount = (double)selectReader["Değerlendirme Sayısı"];
                                double scCount = (double)selectReader["SC Sayısı"];
                                double favoriteCount = (double)selectReader["Favori Sayısı"];

                                double result = 0.0;
                                double result1 = 0.0;
                                double result2 = 0.0;
                                double result3 = 0.0;

                                for (int i = 0; i < normalizedWeights1.Length; i++)
                                {
                                    result += normalizedWeights1[i] * new double[] { islemcihizideger, EKHdeger, ramdeger, kapasitedeger, pildeger, agırlıkdeger, boyutdeger, İneslideger }[i];
                                }

                                for (int i = 0; i < normalizedWeights2.Length; i++)
                                {
                                    result1 += normalizedWeights2[i] * new double[] { fiyatdeger, garantideger, lisansdeger }[i];
                                }

                                for (int i = 0; i < normalizedWeights3.Length; i++)
                                {
                                    result2 += normalizedWeights3[i] * new double[] { starRating, reviewCount, scCount, favoriteCount }[i];
                                }

                                for (int i = 0; i < normalizedWeightsTotal.Length; i++)
                                {
                                    result3 += normalizedWeightsTotal[i] * new double[] { result, result1, result2 }[i];
                                }

                                // Sonucu ekleyin

                                string insertQuery = "INSERT INTO Sonuc (ID, Ozellikdeger,Maliyetdeger,Deneyimdeger,Fdeger) VALUES (@ID,@Ozellikdeger,@Maliyetdeger,@Deneyimdeger,@Fdeger)";
                                using (SqlConnection insertConnection = new SqlConnection(@"Data Source=DESKTOP-IMD9LC0\MSSQLSERVER123;Initial Catalog=Proje3;Integrated Security=True"))
                                {
                                    insertConnection.Open();
                                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, insertConnection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@ID", ID);
                                        insertCommand.Parameters.AddWithValue("@Ozellikdeger", result);
                                        insertCommand.Parameters.AddWithValue("@Maliyetdeger", result1);
                                        insertCommand.Parameters.AddWithValue("@Deneyimdeger", result2);
                                        insertCommand.Parameters.AddWithValue("@Fdeger", result3);

                                        insertCommand.ExecuteNonQuery();
                                    }
                                }

                            }
                        }
                    }
                }
            }



        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
       }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void Kriterler_Load(object sender, EventArgs e)
        {
            //button2.Enabled = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

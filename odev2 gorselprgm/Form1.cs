using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace odev2_gorselprgm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("veritabani.db"))
            {
                SQLiteConnection.CreateFile("veritabani.db");

                using (SQLiteConnection baglanti = new SQLiteConnection("Data Source=veritabani.db;Version=3;"))
                {
                    baglanti.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS Kayitlar (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Ad TEXT,
                            Soyad TEXT,
                            DogumTarihi TEXT,
                            Burc TEXT,
                            Vki REAL,
                            VkiYorum TEXT
                        )";
                    SQLiteCommand komut = new SQLiteCommand(sql, baglanti);
                    komut.ExecuteNonQuery();
                }
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            DateTime dogumTarihi = dtpDogumTarihi.Value;
            int gun = dogumTarihi.Day;
            string ay = dogumTarihi.ToString("MMMM");
            int yil = dogumTarihi.Year;

            double boy = Convert.ToDouble(txtBoy.Text) / 100;  
            double kilo = Convert.ToDouble(txtKilo.Text);
            double vki = kilo / (boy * boy);

            string burc = BurcHesapla(dogumTarihi);
            string burcYorum = BurcYorum(burc);
            string vkiYorum = VkiYorum(vki);

           
            string burcDosyaAdi = burc.ToLower().Normalize(NormalizationForm.FormD);
            burcDosyaAdi = new string(burcDosyaAdi.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());

            string burcResimYolu = $"burclar\\{burcDosyaAdi}.png";

            if (System.IO.File.Exists(burcResimYolu))
                pbBurcResmi.Image = Image.FromFile(burcResimYolu);
            else
                pbBurcResmi.Image = null;

            // Sonuçları richTextBox'a yaz
            rtbCikti.Text = $"Adı: {ad}\n" +
                            $"Soyadı: {soyad}\n" +
                            $"Gün:  {gun}\n" +
                            $"Ay: {ay}\n" +
                            $"Yıl: {yil}\n\n" +
                            $"Burç: {burc}\n" +
                            $"Yorum: {burcYorum}\n" +
                            $"VKİ: {Math.Round(vki, 2)}\n" +
                            $"VKİ Yorum: {vkiYorum}";

            using (SQLiteConnection baglanti = new SQLiteConnection("Data Source=veritabani.db;Version=3;"))
            {
                baglanti.Open();
                string sql = "INSERT INTO Kayitlar (Ad, Soyad, DogumTarihi, Burc, Vki, VkiYorum) VALUES (@ad, @soyad, @dtarih, @burc, @vki, @vkiYorum)";
                SQLiteCommand komut = new SQLiteCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@dtarih", dogumTarihi.ToShortDateString());
                komut.Parameters.AddWithValue("@burc", burc);
                komut.Parameters.AddWithValue("@vki", Math.Round(vki, 2));
                komut.Parameters.AddWithValue("@vkiYorum", vkiYorum);
                komut.ExecuteNonQuery();
            }

        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection baglanti = new SQLiteConnection("Data Source=veritabani.db;Version=3;"))
            {
                baglanti.Open();
                string sql = "SELECT * FROM Kayitlar";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKayitlar.DataSource = dt;
            }
        }


        private string BurcHesapla(DateTime dt)
        {
            int gun = dt.Day;
            int ay = dt.Month;

            if ((ay == 6 && gun >= 22) || (ay == 7 && gun <= 22))
                return "Yengeç";
            else if ((ay == 7 && gun >= 23) || (ay == 8 && gun <= 22))
                return "Aslan";
            else if ((ay == 8 && gun >= 23) || (ay == 9 && gun <= 22))
                return "Başak";
            else if ((ay == 9 && gun >= 23) || (ay == 10 && gun <= 22))
                return "Terazi";
            else if ((ay == 10 && gun >= 23) || (ay == 11 && gun <= 21))
                return "Akrep";
            else if ((ay == 11 && gun >= 22) || (ay == 12 && gun <= 21))
                return "Yay";
            else if ((ay == 12 && gun >= 22) || (ay == 1 && gun <= 19))
                return "Oğlak";
            else if ((ay == 1 && gun >= 20) || (ay == 2 && gun <= 18))
                return "Kova";
            else if ((ay == 2 && gun >= 19) || (ay == 3 && gun <= 20))
                return "Balık";
            else if ((ay == 3 && gun >= 21) || (ay == 4 && gun <= 19))
                return "Koç";
            else if ((ay == 4 && gun >= 20) || (ay == 5 && gun <= 20))
                return "Boğa";
            else
                return "İkizler";
        }

        private string BurcYorum(string burc)
        {
            switch (burc)
            {
                case "Yengeç": return "Duygusal, sezgisel ve aileye düşkündür.";
                case "Aslan": return "Lider ruhlu, özgüvenli ve cömerttir.";
                case "Başak": return "Detaycı, titiz ve yardımseverdir.";
                case "Terazi": return "Adaletli, uyumlu ve zariftir.";
                case "Akrep": return "Tutkulu, kararlı ve gizemlidir.";
                case "Yay": return "Macera sever, iyimser ve enerjiktir.";
                case "Oğlak": return "Çalışkan, sorumluluk sahibi ve ciddi yapılıdır.";
                case "Kova": return "Özgür ruhlu, yenilikçi ve entelektüeldir.";
                case "Balık": return "Hayalperest, merhametli ve duyarlıdır.";
                case "Koç": return "Cesur, enerjik ve lider ruhludur.";
                case "Boğa": return "Sadık, sabırlı ve zevkine düşkündür.";
                case "İkizler": return "Zeki, meraklı ve iletişimcidir.";
                default: return "Burç yorumu bulunamadı.";
            }
        }

        private string VkiYorum(double vki)
        {
            if (vki < 18.5)
                return "Zayıf - Kilonuzu biraz artırmanız gerekebilir.";
            else if (vki < 25)
                return "Normal - Sağlıklı kilodasınız.";
            else if (vki < 30)
                return "Fazla kilolu - Dikkatli olmanızda fayda var.";
            else
                return "Obez - Sağlık açısından riskli, önlem alınmalı.";
        }
    }
}

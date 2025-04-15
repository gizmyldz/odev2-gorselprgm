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

            // Sonu�lar� richTextBox'a yaz
            rtbCikti.Text = $"Ad�: {ad}\n" +
                            $"Soyad�: {soyad}\n" +
                            $"G�n:  {gun}\n" +
                            $"Ay: {ay}\n" +
                            $"Y�l: {yil}\n\n" +
                            $"Bur�: {burc}\n" +
                            $"Yorum: {burcYorum}\n" +
                            $"VK�: {Math.Round(vki, 2)}\n" +
                            $"VK� Yorum: {vkiYorum}";

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
                return "Yenge�";
            else if ((ay == 7 && gun >= 23) || (ay == 8 && gun <= 22))
                return "Aslan";
            else if ((ay == 8 && gun >= 23) || (ay == 9 && gun <= 22))
                return "Ba�ak";
            else if ((ay == 9 && gun >= 23) || (ay == 10 && gun <= 22))
                return "Terazi";
            else if ((ay == 10 && gun >= 23) || (ay == 11 && gun <= 21))
                return "Akrep";
            else if ((ay == 11 && gun >= 22) || (ay == 12 && gun <= 21))
                return "Yay";
            else if ((ay == 12 && gun >= 22) || (ay == 1 && gun <= 19))
                return "O�lak";
            else if ((ay == 1 && gun >= 20) || (ay == 2 && gun <= 18))
                return "Kova";
            else if ((ay == 2 && gun >= 19) || (ay == 3 && gun <= 20))
                return "Bal�k";
            else if ((ay == 3 && gun >= 21) || (ay == 4 && gun <= 19))
                return "Ko�";
            else if ((ay == 4 && gun >= 20) || (ay == 5 && gun <= 20))
                return "Bo�a";
            else
                return "�kizler";
        }

        private string BurcYorum(string burc)
        {
            switch (burc)
            {
                case "Yenge�": return "Duygusal, sezgisel ve aileye d��k�nd�r.";
                case "Aslan": return "Lider ruhlu, �zg�venli ve c�merttir.";
                case "Ba�ak": return "Detayc�, titiz ve yard�mseverdir.";
                case "Terazi": return "Adaletli, uyumlu ve zariftir.";
                case "Akrep": return "Tutkulu, kararl� ve gizemlidir.";
                case "Yay": return "Macera sever, iyimser ve enerjiktir.";
                case "O�lak": return "�al��kan, sorumluluk sahibi ve ciddi yap�l�d�r.";
                case "Kova": return "�zg�r ruhlu, yenilik�i ve entelekt�eldir.";
                case "Bal�k": return "Hayalperest, merhametli ve duyarl�d�r.";
                case "Ko�": return "Cesur, enerjik ve lider ruhludur.";
                case "Bo�a": return "Sad�k, sab�rl� ve zevkine d��k�nd�r.";
                case "�kizler": return "Zeki, merakl� ve ileti�imcidir.";
                default: return "Bur� yorumu bulunamad�.";
            }
        }

        private string VkiYorum(double vki)
        {
            if (vki < 18.5)
                return "Zay�f - Kilonuzu biraz art�rman�z gerekebilir.";
            else if (vki < 25)
                return "Normal - Sa�l�kl� kilodas�n�z.";
            else if (vki < 30)
                return "Fazla kilolu - Dikkatli olman�zda fayda var.";
            else
                return "Obez - Sa�l�k a��s�ndan riskli, �nlem al�nmal�.";
        }
    }
}

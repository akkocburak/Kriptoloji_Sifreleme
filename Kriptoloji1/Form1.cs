using System.Text.RegularExpressions;

namespace Kriptoloji1
{
    public partial class Form1 : Form
    {

        private readonly char[] turkAlfabesi = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ".ToCharArray();
        private readonly string anahtarAlfabe = "XNIĞKZYDSÖCTPBHUVJFLGÜORÇMŞEOI";


        //hill algoritması için gerekli metotlar 

        private char[,] MatrisOlustur(char[] alfabe)
        {
            char[,] matris = new char[6, 5];
            for (int i = 0; i < alfabe.Length; i++)
            {
                matris[i / 5, i % 5] = alfabe[i];
            }
            return matris;
        }
        private (int, int) HarfKonumu(char[,] matris, char harf)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matris[i, j] == harf)
                        return (i, j);
                }
            }
            return (-1, -1);
        }
        private int Mod(int a, int m)
        {
            return (a % m + m) % m;
        }
        private void TextBoxlariGizle()
        {
            label3.Visible = false;
            textBox1.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;

        }
        
        public Form1()
        {
            InitializeComponent();
            TextBoxlariGizle();
        }

        // şifreleme algoritmaları
        private string SezarSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            int alfabeUzunlugu = alfabe.Length;
            int kaydirmaAnahtari = 3; // Sabit kaydırma değeri
            metin = metin.ToUpper(); // Büyük harflere çeviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin içindeyse kaydırma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf değilse (boşluk, noktalama vs.) olduğu gibi ekle
                    //sifreliMetin += karakter;
                }
            }

            return sifreliMetin;
        }
        private string KaydirmaliSifrele(string metin, int kaydirmaAnahtari)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            int alfabeUzunlugu = alfabe.Length;
            metin = metin.ToUpper(); // Büyük harflere çeviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin içindeyse kaydırma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf değilse (boşluk, noktalama vs.) olduğu gibi ekle
                   // sifreliMetin += karakter;
                }
            }

            return sifreliMetin;


        }
        private string DogrusalSifrele(string metin, int a, int b)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            int m = alfabe.Length;
            metin = metin.ToUpper();
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    int yeniIndex = (a * index + b) % m;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                   // sifreliMetin += karakter; // noktalama, boşluk vs.
                }
            }

            return sifreliMetin;
        }
        private string YerDegistirmeAlfabetikSifrele(string metin, string anahtarAlfabe)

        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";


            metin = metin.ToUpper();
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);
                if (index != -1)
                {
                    sifreliMetin += anahtarAlfabe[index];
                }
                else
                {
                   // sifreliMetin += karakter;
                }
            }

            return sifreliMetin;
        }
        private string PermutasyonSifrele(string metin, int blokBoyutu, int[] permutasyon)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            metin = metin.ToUpper();

            // SADECE alfabe harflerini al
            string temizMetin = "";
            foreach (char c in metin)
            {
                if (alfabe.Contains(c))
                    temizMetin += c;
            }

            string sifreliMetin = "";

            for (int i = 0; i < temizMetin.Length; i += blokBoyutu)
            {
                char[] blok = new char[blokBoyutu];

                for (int j = 0; j < blokBoyutu; j++)
                {
                    if (i + j < temizMetin.Length)
                        blok[j] = temizMetin[i + j];
                    else
                        blok[j] = 'X'; // Eksik harf varsa 'X' ile doldur
                }

                // Permütasyona göre yeni blok oluştur
                char[] sifreliBlok = new char[blokBoyutu];
                for (int j = 0; j < blokBoyutu; j++)
                {
                    sifreliBlok[j] = blok[permutasyon[j]];
                }

                sifreliMetin += new string(sifreliBlok);
            }

            return sifreliMetin;
        }
        private string RotaSolAltAnahtarli(string metin, int anahtar)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            metin = metin.ToUpper();

            // Sadece alfabe karakterlerini al
            string temizMetin = "";
            foreach (char c in metin)
            {
                if (alfabe.Contains(c))
                    temizMetin += c;
            }

            int uzunluk = temizMetin.Length;
            int kolon = anahtar;
            int satir = (int)Math.Ceiling(uzunluk / (double)kolon);

            char[,] matris = new char[satir, kolon];

            // Metni matrise doldur (satır satır)
            int index = 0;
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < kolon; j++)
                {
                    if (index < uzunluk)
                        matris[i, j] = temizMetin[index++];
                    else
                        matris[i, j] = 'X'; // Boşluklar 'X' ile dolduruluyor
                }
            }

            string sifreliMetin = "";
            int top = 0, bottom = satir - 1, left = 0, right = kolon - 1;

            // Sol alt köşeden spiral okuma
            while (top <= bottom && left <= right)
            {
                // Yukarı
                for (int i = bottom; i >= top; i--)
                    sifreliMetin += matris[i, left];
                left++;

                // Sağa
                for (int i = left; i <= right; i++)
                    sifreliMetin += matris[top, i];
                top++;

                // Aşağı
                if (top <= bottom)
                {
                    for (int i = top; i <= bottom; i++)
                        sifreliMetin += matris[i, right];
                    right--;
                }

                // Sola
                if (left <= right)
                {
                    for (int i = right; i >= left; i--)
                        sifreliMetin += matris[bottom, i];
                    bottom--;
                }
            }

            return sifreliMetin;
        }
        private string ZigzagSifrele(string metin, int satirSayisi)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

            // Metni büyük harfe çevir, boşlukları ve alfabede olmayan karakterleri kaldır
            metin = metin.ToUpper();
            string temizMetin = "";
            foreach (char harf in metin)
            {
                if (alfabe.Contains(harf))
                    temizMetin += harf;
            }

            if (satirSayisi <= 1 || temizMetin.Length <= 1)
                return temizMetin;

            // Satır listesi oluştur
            List<char>[] satirlar = new List<char>[satirSayisi];
            for (int i = 0; i < satirSayisi; i++)
                satirlar[i] = new List<char>();

            int satir = 0;
            bool asagiIniyor = true;

            // Zigzag dolumu
            foreach (char harf in temizMetin)
            {
                satirlar[satir].Add(harf);

                if (asagiIniyor)
                {
                    satir++;
                    if (satir == satirSayisi - 1)
                        asagiIniyor = false;
                }
                else
                {
                    satir--;
                    if (satir == 0)
                        asagiIniyor = true;
                }
            }

            // Satırları sırayla birleştir
            string sifreli = "";
            foreach (var satirListesi in satirlar)
            {
                foreach (var harf in satirListesi)
                    sifreli += harf;
            }

            return sifreli;
        }
        private string DortKareSifrele(string metin, string anahtarAlfabe2, int satir, int sutun)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZX"; // 30 karakter

            // Matrisleri tanımla
            char[,] A = new char[satir, sutun]; // Sol Üst
            char[,] B = new char[satir, sutun]; // Sağ Üst
            char[,] C = new char[satir, sutun]; // Sol Alt
            char[,] D = new char[satir, sutun]; // Sağ Alt

            for (int i = 0; i < 30; i++)
            {
                A[i / sutun, i % sutun] = alfabe[i];
                D[i / sutun, i % sutun] = alfabe[i];
                B[i / sutun, i % sutun] = anahtarAlfabe2[i];
                C[i / sutun, i % sutun] = anahtarAlfabe2[i];
            }

            // ✅ METNİ TEMİZLE
            metin = metin.ToUpper();
            string temizMetin = "";
            foreach (char harf in metin)
            {
                if (alfabe.Contains(harf))
                    temizMetin += harf;
            }

            if (temizMetin.Length % 2 != 0)
                temizMetin += "X";

            string sifreli = "";

            for (int i = 0; i < temizMetin.Length; i += 2)
            {
                char h1 = temizMetin[i];     // A matrisinde
                char h2 = temizMetin[i + 1]; // D matrisinde

                int aSatir = -1, aSutun = -1;
                int dSatir = -1, dSutun = -1;

                // A matrisinde ilk harfi bul
                for (int r = 0; r < satir; r++)
                {
                    for (int c = 0; c < sutun; c++)
                    {
                        if (A[r, c] == h1)
                        {
                            aSatir = r;
                            aSutun = c;
                        }
                        if (D[r, c] == h2)
                        {
                            dSatir = r;
                            dSutun = c;
                        }
                    }
                }

                if (aSatir != -1 && aSutun != -1 && dSatir != -1 && dSutun != -1)
                {
                    char yeniH1 = B[aSatir, dSutun]; // Sağ Üst
                    char yeniH2 = C[dSatir, aSutun]; // Sol Alt
                    sifreli += yeniH1.ToString() + yeniH2.ToString();
                }
                else
                {
                    sifreli += h1.ToString() + h2.ToString(); // Bulunamazsa aynen ekle
                }
            }

            return sifreli;
        }
        private string SayisalYerdegistirmeSifrele(string metin, int anahtar2)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZX"; // 30 karakterlik Türk alfabesi

            // Metni temizle: sadece Türk alfabesindeki harfleri al
            metin = metin.ToUpper();
            string temizMetin = "";
            foreach (char harf in metin)
            {
                if (alfabe.Contains(harf))
                    temizMetin += harf;
            }

            int sutunSayisi = anahtar2;
            int satirSayisi = (int)Math.Ceiling((double)temizMetin.Length / sutunSayisi);

            char[,] tablo = new char[satirSayisi, sutunSayisi];

            // Tabloya doldurma (soldan sağa, yukarıdan aşağıya)
            int index = 0;
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (index < temizMetin.Length)
                        tablo[i, j] = temizMetin[index++];
                    else
                        tablo[i, j] = 'X'; // eksik yerleri 'X' ile doldur
                }
            }

            // Tabloyu sütun sütun okuyarak şifreleme
            string sifreli = "";
            for (int j = 0; j < sutunSayisi; j++)
            {
                for (int i = 0; i < satirSayisi; i++)
                {
                    sifreli += tablo[i, j];
                }
            }

            return sifreli;
        }
        private string VigenereSifrele(string metin, string anahtar3)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

            metin = metin.ToUpper().Replace(" ", "");

            string sonuc = "";
            int anahtarIndex = 0;

            for (int i = 0; i < metin.Length; i++)
            {
                char harf = metin[i];
                if (alfabe.Contains(harf))
                {
                    int metinIndex = alfabe.IndexOf(harf);
                    int anahtarHarfIndex = alfabe.IndexOf(anahtar3[anahtarIndex % anahtar3.Length]);

                    int sifreIndex = ((metinIndex + anahtarHarfIndex) % alfabe.Length);//+1 eklenirse dağa doğru ama deşifreleme çalışmıyor 
                    sonuc += alfabe[sifreIndex];

                    anahtarIndex++;
                }
                else
                {
                    //sonuc += harf; // harf alfabe dışındaysa direkt ekle
                }
            }

            return sonuc;
        }
        private string HillSifrele(string metin, int[,] anahtarMatris)
        {
            string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            metin = metin.ToUpper().Replace(" ", "");

            int boyut = anahtarMatris.GetLength(0);
            int mod = alfabe.Length;

            // Eksik harfleri X ile tamamla
            while (metin.Length % boyut != 0)
                metin += "X";

            string sifreli = "";

            for (int i = 0; i < metin.Length; i += boyut)
            {
                int[] grup = new int[boyut];
                for (int j = 0; j < boyut; j++)
                    grup[j] = alfabe.IndexOf(metin[i + j]);

                for (int satir = 0; satir < boyut; satir++)
                {
                    int toplam = 0;
                    for (int sutun = 0; sutun < boyut; sutun++)
                        toplam += anahtarMatris[satir, sutun] * grup[sutun];

                    sifreli += alfabe[Mod(toplam, mod)];
                }
            }

            return sifreli;
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            string selectedAlgorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "";

            string result = "";

            switch (selectedAlgorithm)
            {
                case "Sezar Şifreleme":
                    result = SezarSifrele(inputText);
                    break;
                case "Kaydırmalı Şifreleme":
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Lütfen bir kaydırma anahtarı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }

                    int kaydırmaanahtarı = Convert.ToInt16(textBox1.Text);
                    result = KaydirmaliSifrele(inputText, kaydırmaanahtarı);
                    break;
                case "Doğrusal Şifreleme":
                    if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        MessageBox.Show("Lütfen iki anahtarıda giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }
                    int a = Convert.ToInt16(textBox1.Text);
                    int b = Convert.ToInt16(textBox2.Text);
                    result = DogrusalSifrele(inputText, a, b);
                    break;
                case "Yer Değiştirme":
                     string anahtarAlfabe = "ESDĞNÜAYMÇTŞİUPHZRDLBKGJCVFÖI"; // Karışık alfabetik sıralama ANAHTAR
                    //string anahtarAlfabe = Convert.ToString(textBox1.Text).ToUpper();
                    result = YerDegistirmeAlfabetikSifrele(inputText, anahtarAlfabe);
                    break;
                case "Permutasyon":
                    int blokBoyutu = 5;
                    int[] permutasyon = { 3, 0, 4, 1, 2 }; // Sabit bir permütasyon dizisi
                    result = PermutasyonSifrele(inputText, blokBoyutu, permutasyon);
                    break;
                case "Rota Algoritması":
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Lütfen bir  anahtar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }
                    int anahtar = Convert.ToInt16(textBox1.Text);
                    result = RotaSolAltAnahtarli(inputText, anahtar);
                    break;
                case "Zigzag Algoritması":
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Lütfen bir  anahtar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }
                    int satirSayisi = Convert.ToInt16(textBox1.Text);
                    result = ZigzagSifrele(inputText, satirSayisi);
                    break;
                case "4 Kare":
                    if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        MessageBox.Show("Lütfen iki anahtarıda giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }
                    string anahtarAlfabe2 = "XNIĞKZYDSÖCTPBHUVJFLGÜORÇMŞEOI"; // 30 karakter
                    int satir = Convert.ToInt16(textBox1.Text);
                    int sutun = Convert.ToInt16(textBox2.Text);
                    result = DortKareSifrele(inputText, anahtarAlfabe2, satir, sutun);
                    break;
                case "Yer Değiştirme (Sayı Anahtarlı)":
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Lütfen  anahtarı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Bu durumda şifreleme işlemi yapılmaz
                    }
                    int anahtar2 = Convert.ToInt16(textBox1.Text);// anahtar sayı
                    result = SayisalYerdegistirmeSifrele(inputText, anahtar2);

                    break;
                case "Vigenère":
                    string anahtarMetin = textBox1.Text;

                    if (string.IsNullOrWhiteSpace(anahtarMetin))
                    {
                        MessageBox.Show("Lütfen anahtar kelimeyi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Sadece Türkçe büyük harf karakterleri içeriyor mu kontrolü
                    string turkceAlfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
                    foreach (char c in anahtarMetin.ToUpper())
                    {
                        if (!turkceAlfabe.Contains(c))
                        {
                            MessageBox.Show("Anahtar sadece Türkçe harflerden oluşmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string anahtar3 = anahtarMetin.ToUpper();
                    result = VigenereSifrele(inputText, anahtar3);
                    break;
                case "Hill Algoritması":
                    int[,] anahtarMatris = new int[,]
  {
    { 3, 2, 4 },
    { 1, 3, 5 },
    { 0, 2, 1 }
  };
                    result = HillSifrele(inputText, anahtarMatris);
                    break;

                default:
                    MessageBox.Show("Lütfen bir algoritma seçin.");
                    return;
            }

            txtOutput.Text = result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAlgorithm.Items.AddRange(new string[]
{
     "Şifreleme Algoritması Seçin",
    "Sezar Şifreleme",
    "Kaydırmalı Şifreleme",
    "Doğrusal Şifreleme",
    "Yer Değiştirme",
    "Permutasyon",
    "Rota Algoritması",
    "Zigzag Algoritması",
    "4 Kare",
    "Yer Değiştirme (Sayı Anahtarlı)",
    "Vigenère",
    "Hill Algoritması",

});
            cmbAlgorithm.SelectedIndex = 0;

        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenIslem = cmbAlgorithm.SelectedItem.ToString();
            TextBoxlariGizle();

            switch (secilenIslem)
            {
                case "Kaydırmalı Şifreleme":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    break;
                case "Doğrusal Şifreleme":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    textBox2.Visible = true;
                    label4.Visible = true;
                    break;
                case "Yer Değiştirme":
                    //textBox1.Visible = true;
                    //label3.Visible = true;
                    break;

                case "Rota Algoritması":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    break;
                case "Zigzag Algoritması":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    break;

                case "4 Kare":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    textBox2.Visible = true;
                    label4.Visible = true;
                    break;
                case "Yer Değiştirme (Sayı Anahtarlı)":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    break;
                case "Vigenère":
                    textBox1.Visible = true;
                    label3.Visible = true;
                    break;

                default:
                    textBox1.Visible = false;
                    label3.Visible = false;
                    textBox2.Visible = false;
                    label4.Visible = false;

                    break;
            }
        }

        
    }
}



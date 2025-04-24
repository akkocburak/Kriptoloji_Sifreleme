namespace Kriptoloji1
{
    public partial class Form1 : Form
    {
       
        private readonly char[] turkAlfabesi = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ".ToCharArray();
        private readonly string anahtarAlfabe = "XNIÐKZYDSÖCTPBHUVJFLGÜORÇMÞEOI";

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


        // test edildi
        private string SezarSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            int alfabeUzunlugu = alfabe.Length;
            int kaydirmaAnahtari = 3; // Sabit kaydýrma deðeri
            metin = metin.ToUpper(); // Büyük harflere çeviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin içindeyse kaydýrma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf deðilse (boþluk, noktalama vs.) olduðu gibi ekle
                    sifreliMetin += karakter;
                }
            }

            return sifreliMetin;
        }
        private string KaydirmaliSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            int alfabeUzunlugu = alfabe.Length;
            int kaydirmaAnahtari = 5; // Sabit kaydýrma deðeri
            metin = metin.ToUpper(); // Büyük harflere çeviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin içindeyse kaydýrma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf deðilse (boþluk, noktalama vs.) olduðu gibi ekle
                    sifreliMetin += karakter;
                }
            }

            return sifreliMetin;

            // burasý farklý kaynakta kaydýrmalý algoritma için her karakteri bir sonraki karakterin indexi kadar kaydýrýyor


            //    int pozisyon = 1;

            //    foreach (char karakter in metin)
            //    {
            //        int index = alfabe.IndexOf(karakter);

            //        if (index != -1)
            //        {
            //            int yeniIndex = (index + pozisyon) % alfabeUzunlugu;
            //            sifreliMetin += alfabe[yeniIndex];
            //            pozisyon++; // Bir sonraki karakter daha fazla kaydýrýlýr
            //        }
            //        else
            //        {
            //            sifreliMetin += karakter;
            //        }
            //    }

            //    return sifreliMetin;
        }
        private string DogrusalSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            int m = alfabe.Length;
            int a = 3; // çarpan anahtar 
            int b = 2; // toplama anahtarý
            metin = metin.ToUpper();
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = (alfabe.IndexOf(karakter))+1;

                if (index != -1)
                {
                    int yeniIndex =( (a * index + b) % m);
                    sifreliMetin += alfabe[(yeniIndex-1)];
                }
                else
                {
                    sifreliMetin += karakter; // noktalama, boþluk vs.
                }
            }

            return sifreliMetin;
        }
        private string YerDegistirmeAlfabetikSifrele(string metin)

        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            string anahtarAlfabe = "ESDÐNÜAYMÇTÞÝUPHZRDLBKGJCVFÖI"; // Karýþýk alfabetik sýralama ANAHTAR

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
                    sifreliMetin += karakter;
                }
            }

            return sifreliMetin;
        }
        private string PermutasyonSifrele(string metin)
        {
            int blokBoyutu = 5;
            int[] permutasyon = { 3, 0, 4, 1, 2 }; // Sabit bir permütasyon dizisi
            metin = metin.ToUpper();
            string sifreliMetin = "";

            for (int i = 0; i < metin.Length; i += blokBoyutu)
            {
                char[] blok = new char[blokBoyutu];

                for (int j = 0; j < blokBoyutu; j++)
                {
                    if (i + j < metin.Length)
                        blok[j] = metin[i + j];
                    else
                        blok[j] = 'X'; // Eksik harf varsa 'X' ile doldur
                }

                // Permütasyona göre yeni blok oluþtur
                char[] sifreliBlok = new char[blokBoyutu];
                for (int j = 0; j < blokBoyutu; j++)
                {
                    sifreliBlok[j] = blok[permutasyon[j]];
                }

                sifreliMetin += new string(sifreliBlok);
            }

            return sifreliMetin;
        }
        private string RotaSolAltAnahtarli(string metin)
        {
            int anahtar = 5;
            metin = metin.ToUpper();
            int uzunluk = metin.Length;

            int kolon = anahtar;
            int satir = (int)Math.Ceiling(uzunluk / (double)kolon);

            char[,] matris = new char[satir, kolon];

            // Metni matrise doldur (satýr satýr)
            int index = 0;
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < kolon; j++)
                {
                    if (index < uzunluk)
                        matris[i, j] = metin[index++];
                    else
                        matris[i, j] = 'j'; // Boþluklar X ile dolduruluyor
                }
            }

            string sifreliMetin = "";
            int top = 0, bottom = satir - 1, left = 0, right = kolon - 1;

            // Sol alt köþeden spiral okuma
            while (top <= bottom && left <= right)
            {
                // Yukarý
                for (int i = bottom; i >= top; i--)
                    sifreliMetin += matris[i, left];
                left++;

                // Saða
                for (int i = left; i <= right; i++)
                    sifreliMetin += matris[top, i];
                top++;

                // Aþaðý
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
        private string ZigzagYazVeOku(string metin)

        {
            int satirSayisi = 5;
            metin = metin.ToUpper().Replace(" ", "");
            if (satirSayisi <= 1 || metin.Length <= 1)
                return metin;

            // Satýr listesi oluþtur
            List<char>[] satirlar = new List<char>[satirSayisi];
            for (int i = 0; i < satirSayisi; i++)
                satirlar[i] = new List<char>();

            int satir = 0;
            bool asagiIniyor = true;

            // Zigzag dolumu
            foreach (char harf in metin)
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

            // Satýrlarý sýrayla birleþtir
            string sifreli = "";
            foreach (var satirListesi in satirlar)
            {
                foreach (var harf in satirListesi)
                    sifreli += harf;
            }

            return sifreli;
        }
        private string DortKareSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZX"; // 30 karakter
            string anahtarAlfabe = "XNIÐKZYDSÖCTPBHUVJFLGÜORÇMÞEOI"; // 30 karakter
            int satir = 6, sutun = 5;

            // Matrisleri tanýmla
            char[,] A = new char[satir, sutun]; // Sol Üst
            char[,] B = new char[satir, sutun]; // Sað Üst
            char[,] C = new char[satir, sutun]; // Sol Alt
            char[,] D = new char[satir, sutun]; // Sað Alt

            for (int i = 0; i < 30; i++)
            {
                A[i / sutun, i % sutun] = alfabe[i];
                D[i / sutun, i % sutun] = alfabe[i];
                B[i / sutun, i % sutun] = anahtarAlfabe[i];
                C[i / sutun, i % sutun] = anahtarAlfabe[i];
            }

            // Metni hazýrlama
            metin = metin.ToUpper().Replace(" ", "");
            if (metin.Length % 2 != 0)
                metin += "X";

            string sifreli = "";

            for (int i = 0; i < metin.Length; i += 2)
            {
                char h1 = metin[i];     // A matrisinde
                char h2 = metin[i + 1]; // D matrisinde

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
                    char yeniH1 = B[aSatir, dSutun]; // Sað Üstten
                    char yeniH2 = C[dSatir, aSutun]; // Sol Alttan
                    sifreli += yeniH1.ToString() + yeniH2.ToString();
                }
                else
                {
                    sifreli += h1.ToString() + h2.ToString(); // Bulunamazsa aynen ekle
                }
            }

            return sifreli;
        }
        private string SayisalYerdegistirmeSifrele(string metin)
        {
            int anahtar = 7;
            metin = metin.ToUpper().Replace(" ", "");

            int sutunSayisi = anahtar;
            int satirSayisi = (int)Math.Ceiling((double)metin.Length / sutunSayisi);

            char[,] tablo = new char[satirSayisi, sutunSayisi];

            // Tabloya doldurma (soldan saða yukarýdan aþaðýya)
            int index = 0;
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (index < metin.Length)
                        tablo[i, j] = metin[index++];
                    else
                        tablo[i, j] = 'X'; // eksik karakterler için doldurma
                }
            }

            // Tabloyu sütun sütun okuyarak þifreleme
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
        private string VigenereSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            string anahtar = "ARABA"; // Buraya dilediðin sabit anahtarý koyabilirsin
            metin = metin.ToUpper().Replace(" ", "");

            string sonuc = "";
            int anahtarIndex = 0;

            for (int i = 0; i < metin.Length; i++)
            {
                char harf = metin[i];
                if (alfabe.Contains(harf))
                {
                    int metinIndex = alfabe.IndexOf(harf);
                    int anahtarHarfIndex = alfabe.IndexOf(anahtar[anahtarIndex % anahtar.Length]);

                    int sifreIndex = ((metinIndex + anahtarHarfIndex) % alfabe.Length)+1;
                    sonuc += alfabe[sifreIndex];

                    anahtarIndex++;
                }
                else
                {
                    sonuc += harf; // harf alfabe dýþýndaysa direkt ekle
                }
            }

            return sonuc;
        }
        private string HillSifrele(string metin)
        {
            string alfabe = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ";
            metin = metin.ToUpper().Replace(" ", "");

            // Metin uzunluðu 3'ün katý olmalý, deðilse X ekle
            while (metin.Length % 3 != 0)
            {
                metin += "A";
            }

            int[,] anahtarMatris = { { 3, 2, 4 }, { 1, 3, 5 }, { 0, 2, 1 } };
            string sonuc = "";

            for (int i = 0; i < metin.Length; i += 3)
            {
                int[] vektor = new int[3];

                // 1 tabanlý indeks alýyoruz (A=1, ..., Z=29)
                for (int j = 0; j < 3; j++)
                {
                    vektor[j] = alfabe.IndexOf(metin[i + j]) + 1;
                }

                int[] sifreliVektor = new int[3];

                // Matris çarpýmý ve mod alma
                for (int satir = 0; satir < 3; satir++)
                {
                    int toplam = 0;
                    for (int sutun = 0; sutun < 3; sutun++)
                    {
                        toplam += anahtarMatris[satir, sutun] * vektor[sutun];
                    }
                    sifreliVektor[satir] = toplam % alfabe.Length;
                    if (sifreliVektor[satir] == 0)
                        sifreliVektor[satir] = alfabe.Length; // 0 -> 29
                }

                // Þifreli harfleri ekle (dizi 0 indeksli, -1)
                foreach (int index in sifreliVektor)
                {
                    sonuc += alfabe[index - 1];
                }
            }

            return sonuc;
        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAlgorithm.Items.AddRange(new string[]
{
    "Sezar Þifreleme",
    "Kaydýrmalý Þifreleme",
    "Doðrusal Þifreleme",
    "Yer Deðiþtirme",
    "Permutasyon",
    "Rota Algoritmasý",
    "Zigzag Algoritmasý",
    "4 Kare",
    "Yer Deðiþtirme (Sayý Anahtarlý)",
    "Vigenère",
    "Hill Algoritmasý"
});

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            string selectedAlgorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "";

            string result = "";

            switch (selectedAlgorithm)
            {
                case "Sezar Þifreleme":
                    result = SezarSifrele(inputText);
                    break;
                case "Kaydýrmalý Þifreleme":
                    result = KaydirmaliSifrele(inputText);
                    break;
                case "Doðrusal Þifreleme":
                    result = DogrusalSifrele(inputText);
                    break;
                case "Yer Deðiþtirme":
                    result = YerDegistirmeAlfabetikSifrele(inputText);
                    break;
                case "Permutasyon":
                    result = PermutasyonSifrele(inputText);
                    break;
                case "Rota Algoritmasý":
                    result = RotaSolAltAnahtarli(inputText);
                    break;
                case "Zigzag Algoritmasý":
                    result = ZigzagYazVeOku(inputText);
                    break;
                case "4 Kare":

                    result = DortKareSifrele(inputText);
                    break;
                case "Yer Deðiþtirme (Sayý Anahtarlý)":
                    result = SayisalYerdegistirmeSifrele(inputText);
                    break;
                case "Vigenère":
                    result = VigenereSifrele(inputText);
                    break;
                case "Hill Algoritmasý":
                    result = HillSifrele(inputText);
                    break;
                default:
                    MessageBox.Show("Lütfen bir algoritma seçin.");
                    return;
            }

            txtOutput.Text = result;
        }
    }
    }


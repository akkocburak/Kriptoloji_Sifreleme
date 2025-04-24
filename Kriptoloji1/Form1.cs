namespace Kriptoloji1
{
    public partial class Form1 : Form
    {
       
        private readonly char[] turkAlfabesi = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ".ToCharArray();
        private readonly string anahtarAlfabe = "XNI�KZYDS�CTPBHUVJFLG�OR�M�EOI";

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
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            int alfabeUzunlugu = alfabe.Length;
            int kaydirmaAnahtari = 3; // Sabit kayd�rma de�eri
            metin = metin.ToUpper(); // B�y�k harflere �eviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin i�indeyse kayd�rma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf de�ilse (bo�luk, noktalama vs.) oldu�u gibi ekle
                    sifreliMetin += karakter;
                }
            }

            return sifreliMetin;
        }
        private string KaydirmaliSifrele(string metin)
        {
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            int alfabeUzunlugu = alfabe.Length;
            int kaydirmaAnahtari = 5; // Sabit kayd�rma de�eri
            metin = metin.ToUpper(); // B�y�k harflere �eviriyoruz
            string sifreliMetin = "";

            foreach (char karakter in metin)
            {
                int index = alfabe.IndexOf(karakter);

                if (index != -1)
                {
                    // Harf alfabenin i�indeyse kayd�rma uygula
                    int yeniIndex = (index + kaydirmaAnahtari) % alfabeUzunlugu;
                    sifreliMetin += alfabe[yeniIndex];
                }
                else
                {
                    // Harf de�ilse (bo�luk, noktalama vs.) oldu�u gibi ekle
                    sifreliMetin += karakter;
                }
            }

            return sifreliMetin;

            // buras� farkl� kaynakta kayd�rmal� algoritma i�in her karakteri bir sonraki karakterin indexi kadar kayd�r�yor


            //    int pozisyon = 1;

            //    foreach (char karakter in metin)
            //    {
            //        int index = alfabe.IndexOf(karakter);

            //        if (index != -1)
            //        {
            //            int yeniIndex = (index + pozisyon) % alfabeUzunlugu;
            //            sifreliMetin += alfabe[yeniIndex];
            //            pozisyon++; // Bir sonraki karakter daha fazla kayd�r�l�r
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
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            int m = alfabe.Length;
            int a = 3; // �arpan anahtar 
            int b = 2; // toplama anahtar�
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
                    sifreliMetin += karakter; // noktalama, bo�luk vs.
                }
            }

            return sifreliMetin;
        }
        private string YerDegistirmeAlfabetikSifrele(string metin)

        {
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            string anahtarAlfabe = "ESD�N�AYM�T��UPHZRDLBKGJCVF�I"; // Kar���k alfabetik s�ralama ANAHTAR

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
            int[] permutasyon = { 3, 0, 4, 1, 2 }; // Sabit bir perm�tasyon dizisi
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

                // Perm�tasyona g�re yeni blok olu�tur
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

            // Metni matrise doldur (sat�r sat�r)
            int index = 0;
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < kolon; j++)
                {
                    if (index < uzunluk)
                        matris[i, j] = metin[index++];
                    else
                        matris[i, j] = 'j'; // Bo�luklar X ile dolduruluyor
                }
            }

            string sifreliMetin = "";
            int top = 0, bottom = satir - 1, left = 0, right = kolon - 1;

            // Sol alt k��eden spiral okuma
            while (top <= bottom && left <= right)
            {
                // Yukar�
                for (int i = bottom; i >= top; i--)
                    sifreliMetin += matris[i, left];
                left++;

                // Sa�a
                for (int i = left; i <= right; i++)
                    sifreliMetin += matris[top, i];
                top++;

                // A�a��
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

            // Sat�r listesi olu�tur
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

            // Sat�rlar� s�rayla birle�tir
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
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZX"; // 30 karakter
            string anahtarAlfabe = "XNI�KZYDS�CTPBHUVJFLG�OR�M�EOI"; // 30 karakter
            int satir = 6, sutun = 5;

            // Matrisleri tan�mla
            char[,] A = new char[satir, sutun]; // Sol �st
            char[,] B = new char[satir, sutun]; // Sa� �st
            char[,] C = new char[satir, sutun]; // Sol Alt
            char[,] D = new char[satir, sutun]; // Sa� Alt

            for (int i = 0; i < 30; i++)
            {
                A[i / sutun, i % sutun] = alfabe[i];
                D[i / sutun, i % sutun] = alfabe[i];
                B[i / sutun, i % sutun] = anahtarAlfabe[i];
                C[i / sutun, i % sutun] = anahtarAlfabe[i];
            }

            // Metni haz�rlama
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
                    char yeniH1 = B[aSatir, dSutun]; // Sa� �stten
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

            // Tabloya doldurma (soldan sa�a yukar�dan a�a��ya)
            int index = 0;
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (index < metin.Length)
                        tablo[i, j] = metin[index++];
                    else
                        tablo[i, j] = 'X'; // eksik karakterler i�in doldurma
                }
            }

            // Tabloyu s�tun s�tun okuyarak �ifreleme
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
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            string anahtar = "ARABA"; // Buraya diledi�in sabit anahtar� koyabilirsin
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
                    sonuc += harf; // harf alfabe d���ndaysa direkt ekle
                }
            }

            return sonuc;
        }
        private string HillSifrele(string metin)
        {
            string alfabe = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ";
            metin = metin.ToUpper().Replace(" ", "");

            // Metin uzunlu�u 3'�n kat� olmal�, de�ilse X ekle
            while (metin.Length % 3 != 0)
            {
                metin += "A";
            }

            int[,] anahtarMatris = { { 3, 2, 4 }, { 1, 3, 5 }, { 0, 2, 1 } };
            string sonuc = "";

            for (int i = 0; i < metin.Length; i += 3)
            {
                int[] vektor = new int[3];

                // 1 tabanl� indeks al�yoruz (A=1, ..., Z=29)
                for (int j = 0; j < 3; j++)
                {
                    vektor[j] = alfabe.IndexOf(metin[i + j]) + 1;
                }

                int[] sifreliVektor = new int[3];

                // Matris �arp�m� ve mod alma
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

                // �ifreli harfleri ekle (dizi 0 indeksli, -1)
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
    "Sezar �ifreleme",
    "Kayd�rmal� �ifreleme",
    "Do�rusal �ifreleme",
    "Yer De�i�tirme",
    "Permutasyon",
    "Rota Algoritmas�",
    "Zigzag Algoritmas�",
    "4 Kare",
    "Yer De�i�tirme (Say� Anahtarl�)",
    "Vigen�re",
    "Hill Algoritmas�"
});

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            string selectedAlgorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "";

            string result = "";

            switch (selectedAlgorithm)
            {
                case "Sezar �ifreleme":
                    result = SezarSifrele(inputText);
                    break;
                case "Kayd�rmal� �ifreleme":
                    result = KaydirmaliSifrele(inputText);
                    break;
                case "Do�rusal �ifreleme":
                    result = DogrusalSifrele(inputText);
                    break;
                case "Yer De�i�tirme":
                    result = YerDegistirmeAlfabetikSifrele(inputText);
                    break;
                case "Permutasyon":
                    result = PermutasyonSifrele(inputText);
                    break;
                case "Rota Algoritmas�":
                    result = RotaSolAltAnahtarli(inputText);
                    break;
                case "Zigzag Algoritmas�":
                    result = ZigzagYazVeOku(inputText);
                    break;
                case "4 Kare":

                    result = DortKareSifrele(inputText);
                    break;
                case "Yer De�i�tirme (Say� Anahtarl�)":
                    result = SayisalYerdegistirmeSifrele(inputText);
                    break;
                case "Vigen�re":
                    result = VigenereSifrele(inputText);
                    break;
                case "Hill Algoritmas�":
                    result = HillSifrele(inputText);
                    break;
                default:
                    MessageBox.Show("L�tfen bir algoritma se�in.");
                    return;
            }

            txtOutput.Text = result;
        }
    }
    }


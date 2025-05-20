using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private readonly char[] turkAlfabesi = "ABCÇDEFGĞHIIJKLMNOÖPRSŞTUÜVYZ".ToCharArray();
    private readonly string anahtarAlfabe = "XNIİKZYDSŞCTPBHUVJFLGĞORÇMĞEOI";

    // Anahtar giriş kontrolleri
    private TextBox txtKeyShift;  // Kaydırmalı şifreleme için
    private TextBox txtKeyA;      // Doğrusal şifreleme için A
    private TextBox txtKeyB;      // Doğrusal şifreleme için B
    private TextBox txtKeyAlphabet; // Yer değiştirme için anahtar alfabe
    private TextBox txtKeyPermutation; // Permütasyon için
    private TextBox txtKeyRotaSize;    // Rota algoritması için
    private TextBox txtKeyZigzagRows;  // Zigzag için satır sayısı
    private TextBox txtKey4Square;     // 4 Kare için anahtar alfabe
    private TextBox txtKeyNumeric;     // Sayısal yer değiştirme için
    private TextBox txtKeyVigenere;    // Vigenère için anahtar kelime
    private TextBox txtKeyHill;        // Hill matrisi için

    private Panel pnlKeys;        // Anahtar girişleri için panel
    private Label lblKeyInfo;     // Anahtar bilgisi için label

    private void Form1_Load(object sender, EventArgs e)
    {
        // ComboBox items
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

        // Anahtar giriş paneli oluşturma
        pnlKeys = new Panel
        {
            Location = new Point(20, txtInput.Bottom + 10),
            Size = new Size(400, 100),
            BorderStyle = BorderStyle.FixedSingle
        };

        lblKeyInfo = new Label
        {
            Location = new Point(0, 5),
            Size = new Size(380, 20),
            Text = "Lütfen algoritma seçiniz..."
        };

        // Anahtar giriş kontrollerini oluşturma
        txtKeyShift = CreateTextBox("Kaydırma Miktarı");
        txtKeyA = CreateTextBox("A Değeri");
        txtKeyB = CreateTextBox("B Değeri");
        txtKeyAlphabet = CreateTextBox("Anahtar Alfabe");
        txtKeyPermutation = CreateTextBox("Permütasyon (örn: 3,0,4,1,2)");
        txtKeyRotaSize = CreateTextBox("Rota Boyutu");
        txtKeyZigzagRows = CreateTextBox("Satır Sayısı");
        txtKey4Square = CreateTextBox("4 Kare Anahtar Alfabesi");
        txtKeyNumeric = CreateTextBox("Sayısal Anahtar");
        txtKeyVigenere = CreateTextBox("Vigenère Anahtarı");
        txtKeyHill = CreateTextBox("Hill Matrisi (örn: 3,2,4;1,3,5;0,2,1)");

        // Panel'e label ekleme
        pnlKeys.Controls.Add(lblKeyInfo);

        // Form'a panel ekleme
        this.Controls.Add(pnlKeys);

        // ComboBox değişim olayını dinleme
        cmbAlgorithm.SelectedIndexChanged += CmbAlgorithm_SelectedIndexChanged;
    }

    private TextBox CreateTextBox(string placeholder)
    {
        return new TextBox
        {
            Size = new Size(380, 25),
            PlaceholderText = placeholder,
            Visible = false
        };
    }

    private void CmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Tüm TextBox'ları gizle
        HideAllKeyInputs();

        // Seçilen algoritmaya göre ilgili TextBox'ı göster
        switch (cmbAlgorithm.SelectedItem?.ToString())
        {
            case "Sezar Şifreleme":
                ShowKeyInput(txtKeyShift, "Kaydırma miktarını giriniz (Varsayılan: 3)");
                break;
            case "Kaydırmalı Şifreleme":
                ShowKeyInput(txtKeyShift, "Kaydırma miktarını giriniz");
                break;
            case "Doğrusal Şifreleme":
                ShowKeyInput(txtKeyA, "A değerini giriniz");
                ShowKeyInput(txtKeyB, "B değerini giriniz", 30);
                break;
            case "Yer Değiştirme":
                ShowKeyInput(txtKeyAlphabet, "29 karakterlik anahtar alfabeyi giriniz");
                break;
            case "Permutasyon":
                ShowKeyInput(txtKeyPermutation, "Permütasyon değerlerini virgülle ayırarak giriniz (örn: 3,0,4,1,2)");
                break;
            case "Rota Algoritması":
                ShowKeyInput(txtKeyRotaSize, "Rota boyutunu giriniz");
                break;
            case "Zigzag Algoritması":
                ShowKeyInput(txtKeyZigzagRows, "Satır sayısını giriniz");
                break;
            case "4 Kare":
                ShowKeyInput(txtKey4Square, "29 karakterlik anahtar alfabeyi giriniz");
                break;
            case "Yer Değiştirme (Sayı Anahtarlı)":
                ShowKeyInput(txtKeyNumeric, "Sayısal anahtarı giriniz");
                break;
            case "Vigenère":
                ShowKeyInput(txtKeyVigenere, "Anahtar kelimeyi giriniz");
                break;
            case "Hill Algoritması":
                ShowKeyInput(txtKeyHill, "3x3 matris değerlerini noktalı virgülle ayırarak giriniz (örn: 3,2,4;1,3,5;0,2,1)");
                break;
        }
    }

    private void ShowKeyInput(TextBox textBox, string labelText, int yOffset = 0)
    {
        textBox.Location = new Point(10, 30 + yOffset);
        textBox.Visible = true;
        pnlKeys.Controls.Add(textBox);
        lblKeyInfo.Text = labelText;
    }

    private void HideAllKeyInputs()
    {
        foreach (Control control in pnlKeys.Controls)
        {
            if (control is TextBox)
            {
                control.Visible = false;
            }
        }
    }

    private void btnEncrypt_Click(object sender, EventArgs e)
    {
        string inputText = txtInput.Text;
        string selectedAlgorithm = cmbAlgorithm.SelectedItem?.ToString() ?? "";

        if (string.IsNullOrEmpty(inputText))
        {
            MessageBox.Show("Lütfen şifrelenecek metni giriniz.");
            return;
        }

        string result = "";

        try
        {
            switch (selectedAlgorithm)
            {
                case "Sezar Şifreleme":
                    int sezarKey = string.IsNullOrEmpty(txtKeyShift.Text) ? 3 : int.Parse(txtKeyShift.Text);
                    result = KaydirmaliSifrele(inputText, sezarKey);
                    break;

                case "Kaydırmalı Şifreleme":
                    int kaydirmaKey = int.Parse(txtKeyShift.Text);
                    result = KaydirmaliSifrele(inputText, kaydirmaKey);
                    break;

                case "Doğrusal Şifreleme":
                    int a = int.Parse(txtKeyA.Text);
                    int b = int.Parse(txtKeyB.Text);
                    result = DogrusalSifrele(inputText, a, b);
                    break;

                case "Yer Değiştirme":
                    string yerDegistirmeKey = txtKeyAlphabet.Text;
                    if (yerDegistirmeKey.Length != 29)
                    {
                        MessageBox.Show("Anahtar alfabe 29 karakter olmalıdır!");
                        return;
                    }
                    result = YerDegistirmeAlfabetikSifrele(inputText, yerDegistirmeKey);
                    break;

                case "Permutasyon":
                    string[] permValues = txtKeyPermutation.Text.Split(',');
                    int[] permutasyon = Array.ConvertAll(permValues, int.Parse);
                    result = PermutasyonSifrele(inputText, permutasyon.Length, permutasyon);
                    break;

                case "Rota Algoritması":
                    int rotaKey = int.Parse(txtKeyRotaSize.Text);
                    result = RotaSolAltAnahtarli(inputText, rotaKey);
                    break;

                case "Zigzag Algoritması":
                    int zigzagKey = int.Parse(txtKeyZigzagRows.Text);
                    result = ZigzagYazVeOku(inputText, zigzagKey);
                    break;

                case "4 Kare":
                    string kareKey = txtKey4Square.Text;
                    if (kareKey.Length != 29)
                    {
                        MessageBox.Show("4 Kare anahtar alfabesi 29 karakter olmalıdır!");
                        return;
                    }
                    result = DortKareSifrele(inputText, kareKey, 6, 5);
                    break;

                case "Yer Değiştirme (Sayı Anahtarlı)":
                    int sayisalKey = int.Parse(txtKeyNumeric.Text);
                    result = SayisalYerdegistirmeSifrele(inputText, sayisalKey);
                    break;

                case "Vigenère":
                    string vigenereKey = txtKeyVigenere.Text.ToUpper();
                    if (string.IsNullOrEmpty(vigenereKey))
                    {
                        MessageBox.Show("Vigenère anahtarı boş olamaz!");
                        return;
                    }
                    result = VigenereSifrele(inputText, vigenereKey);
                    break;

                case "Hill Algoritması":
                    try
                    {
                        string[] rows = txtKeyHill.Text.Split(';');
                        if (rows.Length != 3)
                        {
                            MessageBox.Show("Hill matrisi 3x3 boyutunda olmalıdır!");
                            return;
                        }

                        int[,] hillMatrix = new int[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            string[] values = rows[i].Split(',');
                            if (values.Length != 3)
                            {
                                MessageBox.Show("Her satırda 3 değer olmalıdır!");
                                return;
                            }
                            for (int j = 0; j < 3; j++)
                            {
                                hillMatrix[i, j] = int.Parse(values[j]);
                            }
                        }
                        result = HillSifrele(inputText, hillMatrix);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hill matrisi formatı hatalı! Örnek format: 3,2,4;1,3,5;0,2,1");
                        return;
                    }
                    break;

                default:
                    MessageBox.Show("Lütfen bir algoritma seçin.");
                    return;
            }

            txtOutput.Text = result;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hata oluştu: {ex.Message}\nLütfen anahtar değerlerini kontrol ediniz.");
        }
    }
} 
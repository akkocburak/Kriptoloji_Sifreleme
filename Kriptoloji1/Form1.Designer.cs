namespace Kriptoloji1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtInput = new TextBox();
            label3 = new Label();
            btnEncrypt = new Button();
            cmbAlgorithm = new ComboBox();
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 20);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 0;
            label1.Text = "şifrelenecek metin girişi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(295, 20);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "şifrelenmiş metin ";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(28, 38);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(221, 135);
            txtInput.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 203);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 4;
            label3.Text = "Şifreleme algoritması seçin";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(295, 203);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(75, 49);
            btnEncrypt.TabIndex = 5;
            btnEncrypt.Text = "Şifrele";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(125, 229);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(148, 23);
            cmbAlgorithm.TabIndex = 6;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(295, 38);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(221, 135);
            txtOutput.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 278);
            Controls.Add(txtOutput);
            Controls.Add(cmbAlgorithm);
            Controls.Add(btnEncrypt);
            Controls.Add(label3);
            Controls.Add(txtInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtInput;
        private Label label3;
        private Button btnEncrypt;
        private ComboBox cmbAlgorithm;
        private TextBox txtOutput;
    }
}

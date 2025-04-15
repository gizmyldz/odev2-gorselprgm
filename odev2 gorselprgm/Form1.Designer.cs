namespace odev2_gorselprgm
{
    partial class Form1 : Form 
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtBoy = new TextBox();
            txtKilo = new TextBox();
            dtpDogumTarihi = new DateTimePicker();
            btnHesapla = new Button();
            pbBurcResmi = new PictureBox();
            rtbCikti = new RichTextBox();
            btnGoster = new Button();
            dgvKayitlar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pbBurcResmi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKayitlar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label1.Location = new Point(119, 93);
            label1.Name = "label1";
            label1.Size = new Size(37, 22);
            label1.TabIndex = 0;
            label1.Text = "AD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label2.Location = new Point(87, 173);
            label2.Name = "label2";
            label2.Size = new Size(78, 22);
            label2.TabIndex = 1;
            label2.Text = "SOYAD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label3.Location = new Point(12, 245);
            label3.Name = "label3";
            label3.Size = new Size(153, 22);
            label3.TabIndex = 2;
            label3.Text = "DOĞUM TARİHİ\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label4.Location = new Point(114, 320);
            label4.Name = "label4";
            label4.Size = new Size(51, 44);
            label4.TabIndex = 3;
            label4.Text = "BOY\r\n(cm)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            label5.Location = new Point(111, 389);
            label5.Name = "label5";
            label5.Size = new Size(54, 22);
            label5.TabIndex = 4;
            label5.Text = "KİLO";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(176, 88);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(145, 27);
            txtAd.TabIndex = 5;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(176, 168);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(145, 27);
            txtSoyad.TabIndex = 6;
            // 
            // txtBoy
            // 
            txtBoy.Location = new Point(176, 320);
            txtBoy.Name = "txtBoy";
            txtBoy.Size = new Size(145, 27);
            txtBoy.TabIndex = 7;
            // 
            // txtKilo
            // 
            txtKilo.Location = new Point(176, 389);
            txtKilo.Name = "txtKilo";
            txtKilo.Size = new Size(145, 27);
            txtKilo.TabIndex = 8;
            // 
            // dtpDogumTarihi
            // 
            dtpDogumTarihi.Location = new Point(176, 240);
            dtpDogumTarihi.Name = "dtpDogumTarihi";
            dtpDogumTarihi.Size = new Size(145, 27);
            dtpDogumTarihi.TabIndex = 9;
            // 
            // btnHesapla
            // 
            btnHesapla.BackColor = Color.FromArgb(255, 192, 255);
            btnHesapla.Location = new Point(119, 461);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(114, 56);
            btnHesapla.TabIndex = 10;
            btnHesapla.Text = "Hesapla";
            btnHesapla.UseVisualStyleBackColor = false;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // pbBurcResmi
            // 
            pbBurcResmi.Location = new Point(440, 11);
            pbBurcResmi.Name = "pbBurcResmi";
            pbBurcResmi.Size = new Size(390, 302);
            pbBurcResmi.TabIndex = 12;
            pbBurcResmi.TabStop = false;
            // 
            // rtbCikti
            // 
            rtbCikti.Location = new Point(378, 319);
            rtbCikti.Name = "rtbCikti";
            rtbCikti.Size = new Size(524, 272);
            rtbCikti.TabIndex = 13;
            rtbCikti.Text = "";
            // 
            // btnGoster
            // 
            btnGoster.BackColor = Color.FromArgb(255, 192, 255);
            btnGoster.Location = new Point(119, 523);
            btnGoster.Name = "btnGoster";
            btnGoster.Size = new Size(114, 52);
            btnGoster.TabIndex = 14;
            btnGoster.Text = "Kayıtları Göster";
            btnGoster.UseVisualStyleBackColor = false;
            btnGoster.Click += btnGoster_Click;
            // 
            // dgvKayitlar
            // 
            dgvKayitlar.BackgroundColor = SystemColors.ButtonHighlight;
            dgvKayitlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKayitlar.Location = new Point(34, 612);
            dgvKayitlar.Name = "dgvKayitlar";
            dgvKayitlar.RowHeadersWidth = 51;
            dgvKayitlar.Size = new Size(888, 126);
            dgvKayitlar.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(955, 750);
            Controls.Add(dgvKayitlar);
            Controls.Add(btnGoster);
            Controls.Add(rtbCikti);
            Controls.Add(pbBurcResmi);
            Controls.Add(btnHesapla);
            Controls.Add(dtpDogumTarihi);
            Controls.Add(txtKilo);
            Controls.Add(txtBoy);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbBurcResmi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKayitlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtBoy;
        private TextBox txtKilo;
        private DateTimePicker dtpDogumTarihi;
        private Button btnHesapla;
        private PictureBox pbBurcResmi;
        private RichTextBox rtbCikti;
        private Button btnGoster;
        private DataGridView dgvKayitlar;
    }
}

namespace OtobusBiletRezervasyon;

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
        groupBoxSefer = new GroupBox();
        comboBoxVaris = new ComboBox();
        comboBoxKalkis = new ComboBox();
        labelKalkis = new Label();
        labelVaris = new Label();
        labelTarih = new Label();
        labelTip = new Label();
        dateTimePickerTarih = new DateTimePicker();
        comboBoxTip = new ComboBox();
        buttonSeferEkle = new Button();
        buttonSeferSil = new Button();
        listBoxSeferler = new ListBox();
        textBoxMusteri = new TextBox();
        buttonRezerve = new Button();
        buttonBiletYazdir = new Button();
        panelKoltuklar = new FlowLayoutPanel();
        label1 = new Label();
        label2 = new Label();
        textBoxTelefon = new TextBox();
        textBoxKimlik = new TextBox();
        buttonRezervasyonIptal = new Button();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        groupBoxSefer.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxSefer
        // 
        groupBoxSefer.Controls.Add(comboBoxVaris);
        groupBoxSefer.Controls.Add(comboBoxKalkis);
        groupBoxSefer.Controls.Add(labelKalkis);
        groupBoxSefer.Controls.Add(labelVaris);
        groupBoxSefer.Controls.Add(labelTarih);
        groupBoxSefer.Controls.Add(labelTip);
        groupBoxSefer.Controls.Add(dateTimePickerTarih);
        groupBoxSefer.Controls.Add(comboBoxTip);
        groupBoxSefer.Controls.Add(buttonSeferEkle);
        groupBoxSefer.Location = new Point(12, 36);
        groupBoxSefer.Name = "groupBoxSefer";
        groupBoxSefer.Size = new Size(476, 234);
        groupBoxSefer.TabIndex = 0;
        groupBoxSefer.TabStop = false;
        groupBoxSefer.Text = "Sefer Oluştur";
        groupBoxSefer.Enter += groupBoxSefer_Enter;
        // 
        // comboBoxVaris
        // 
        comboBoxVaris.FormattingEnabled = true;
        comboBoxVaris.Location = new Point(129, 57);
        comboBoxVaris.Name = "comboBoxVaris";
        comboBoxVaris.Size = new Size(319, 28);
        comboBoxVaris.TabIndex = 10;
        // 
        // comboBoxKalkis
        // 
        comboBoxKalkis.FormattingEnabled = true;
        comboBoxKalkis.Location = new Point(129, 23);
        comboBoxKalkis.Name = "comboBoxKalkis";
        comboBoxKalkis.Size = new Size(319, 28);
        comboBoxKalkis.TabIndex = 9;
        comboBoxKalkis.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // labelKalkis
        // 
        labelKalkis.Location = new Point(11, 28);
        labelKalkis.Name = "labelKalkis";
        labelKalkis.Size = new Size(74, 23);
        labelKalkis.TabIndex = 0;
        labelKalkis.Text = "Nerden";
        // 
        // labelVaris
        // 
        labelVaris.Location = new Point(11, 56);
        labelVaris.Name = "labelVaris";
        labelVaris.Size = new Size(57, 23);
        labelVaris.TabIndex = 1;
        labelVaris.Text = "Nereya";
        // 
        // labelTarih
        // 
        labelTarih.Location = new Point(11, 93);
        labelTarih.Name = "labelTarih";
        labelTarih.Size = new Size(106, 23);
        labelTarih.TabIndex = 2;
        labelTarih.Text = "Sefer Tarihi :";
        // 
        // labelTip
        // 
        labelTip.Location = new Point(11, 135);
        labelTip.Name = "labelTip";
        labelTip.Size = new Size(87, 23);
        labelTip.TabIndex = 3;
        labelTip.Text = "Sefer Tipi";
        labelTip.Click += labelTip_Click;
        // 
        // dateTimePickerTarih
        // 
        dateTimePickerTarih.Location = new Point(129, 88);
        dateTimePickerTarih.Name = "dateTimePickerTarih";
        dateTimePickerTarih.Size = new Size(319, 27);
        dateTimePickerTarih.TabIndex = 6;
        // 
        // comboBoxTip
        // 
        comboBoxTip.Items.AddRange(new object[] { "Şehirlerarası", "Şehiriçi" });
        comboBoxTip.Location = new Point(129, 130);
        comboBoxTip.Name = "comboBoxTip";
        comboBoxTip.Size = new Size(319, 28);
        comboBoxTip.TabIndex = 7;
        // 
        // buttonSeferEkle
        // 
        buttonSeferEkle.Location = new Point(211, 182);
        buttonSeferEkle.Name = "buttonSeferEkle";
        buttonSeferEkle.Size = new Size(148, 33);
        buttonSeferEkle.TabIndex = 8;
        buttonSeferEkle.Text = "Sefer Ekle";
        buttonSeferEkle.Click += buttonSeferEkle_Click;
        // 
        // buttonSeferSil
        // 
        buttonSeferSil.Location = new Point(1131, 206);
        buttonSeferSil.Name = "buttonSeferSil";
        buttonSeferSil.Size = new Size(100, 33);
        buttonSeferSil.TabIndex = 9;
        buttonSeferSil.Text = "Sefer Sil";
        buttonSeferSil.UseVisualStyleBackColor = true;
        buttonSeferSil.Click += buttonSeferSil_Click;
        // 
        // listBoxSeferler
        // 
        listBoxSeferler.Location = new Point(518, 36);
        listBoxSeferler.Name = "listBoxSeferler";
        listBoxSeferler.Size = new Size(713, 164);
        listBoxSeferler.TabIndex = 1;
        listBoxSeferler.SelectedIndexChanged += listBoxSeferler_SelectedIndexChanged;
        // 
        // textBoxMusteri
        // 
        textBoxMusteri.Location = new Point(233, 322);
        textBoxMusteri.Name = "textBoxMusteri";
        textBoxMusteri.Size = new Size(158, 27);
        textBoxMusteri.TabIndex = 3;
        // 
        // buttonRezerve
        // 
        buttonRezerve.Location = new Point(249, 459);
        buttonRezerve.Name = "buttonRezerve";
        buttonRezerve.Size = new Size(123, 47);
        buttonRezerve.TabIndex = 4;
        buttonRezerve.Text = "Rezerve Et";
        buttonRezerve.Click += buttonRezerve_Click;
        // 
        // buttonBiletYazdir
        // 
        buttonBiletYazdir.Location = new Point(248, 522);
        buttonBiletYazdir.Name = "buttonBiletYazdir";
        buttonBiletYazdir.Size = new Size(123, 37);
        buttonBiletYazdir.TabIndex = 5;
        buttonBiletYazdir.Text = "Bilet Yazdır";
        buttonBiletYazdir.Click += buttonBiletYazdir_Click;
        // 
        // panelKoltuklar
        // 
        panelKoltuklar.Location = new Point(518, 245);
        panelKoltuklar.Name = "panelKoltuklar";
        panelKoltuklar.Size = new Size(721, 280);
        panelKoltuklar.TabIndex = 6;
        panelKoltuklar.Paint += panelKoltuklar_Paint_1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(800, 218);
        label1.Name = "label1";
        label1.Size = new Size(68, 20);
        label1.TabIndex = 7;
        label1.Text = "Koltuklar";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(825, 9);
        label2.Name = "label2";
        label2.Size = new Size(60, 20);
        label2.TabIndex = 8;
        label2.Text = "Seferler";
        label2.Click += label2_Click;
        // 
        // textBoxTelefon
        // 
        textBoxTelefon.Location = new Point(233, 412);
        textBoxTelefon.Name = "textBoxTelefon";
        textBoxTelefon.Size = new Size(158, 27);
        textBoxTelefon.TabIndex = 7;
        // 
        // textBoxKimlik
        // 
        textBoxKimlik.Location = new Point(233, 367);
        textBoxKimlik.Name = "textBoxKimlik";
        textBoxKimlik.Size = new Size(158, 27);
        textBoxKimlik.TabIndex = 8;
        textBoxKimlik.TextChanged += textBoxKimlik_TextChanged;
        // 
        // buttonRezervasyonIptal
        // 
        buttonRezervasyonIptal.Location = new Point(1094, 531);
        buttonRezervasyonIptal.Name = "buttonRezervasyonIptal";
        buttonRezervasyonIptal.Size = new Size(145, 33);
        buttonRezervasyonIptal.TabIndex = 10;
        buttonRezervasyonIptal.Text = "Rezervasyon İptal Et";
        buttonRezervasyonIptal.UseVisualStyleBackColor = true;
        buttonRezervasyonIptal.Click += buttonRezervasyonIptal_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(96, 322);
        label3.Name = "label3";
        label3.Size = new Size(85, 20);
        label3.TabIndex = 11;
        label3.Text = "Müşteri Adı";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(96, 370);
        label4.Name = "label4";
        label4.Size = new Size(117, 20);
        label4.TabIndex = 12;
        label4.Text = "Kimlik Numarası";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(96, 419);
        label5.Name = "label5";
        label5.Size = new Size(125, 20);
        label5.TabIndex = 13;
        label5.Text = "Telefon Numarası";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1314, 630);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(textBoxTelefon);
        Controls.Add(textBoxKimlik);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(panelKoltuklar);
        Controls.Add(groupBoxSefer);
        Controls.Add(listBoxSeferler);
        Controls.Add(textBoxMusteri);
        Controls.Add(buttonRezerve);
        Controls.Add(buttonSeferSil);
        Controls.Add(buttonBiletYazdir);
        Controls.Add(buttonRezervasyonIptal);
        Name = "Form1";
        Text = "Otobüs Bilet Rezervasyon Sistemi";
        Load += Form1_Load;
        groupBoxSefer.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel panelKoltuklar;
    private Label label1;
    private Label label2;
    private TextBox textBoxTelefon;
    private TextBox textBoxKimlik;
    private System.Windows.Forms.Button buttonSeferSil;
    private System.Windows.Forms.Button buttonRezervasyonIptal;
    private Label label3;
    private Label label4;
    private Label label5;
    private ComboBox comboBoxVaris;
    private ComboBox comboBoxKalkis;
}

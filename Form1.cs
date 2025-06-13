using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Net;
using System.Net.Http;

namespace OtobusBiletRezervasyon
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.GroupBox? groupBoxSefer;
        private System.Windows.Forms.Label? labelKalkis;
        private System.Windows.Forms.Label? labelVaris;
        private System.Windows.Forms.Label? labelTarih;
        private System.Windows.Forms.Label? labelTip;
        private System.Windows.Forms.DateTimePicker? dateTimePickerTarih;
        private System.Windows.Forms.ComboBox? comboBoxTip;
        private System.Windows.Forms.Button? buttonSeferEkle;
        private System.Windows.Forms.ListBox? listBoxSeferler;
        private System.Windows.Forms.TextBox? textBoxMusteri;
        private System.Windows.Forms.Button? buttonRezerve;
        private System.Windows.Forms.Button? buttonBiletYazdir;
        private PictureBox? pictureBoxOtobus;

        private List<Sefer> seferler = new();
        private Sefer? seciliSefer;
        private int? seciliKoltukNo = null;

        public Form1()
        {
            InitializeComponent();
            // Sefer oluşturma tarihinin geçmişte seçilmesini engelle
            if (dateTimePickerTarih != null)
            {
                dateTimePickerTarih.MinDate = DateTime.Today;
            }
            // Şehirler için ComboBox'ları tasarımda ekleyin ve isimlerini comboBoxKalkis ve comboBoxVaris olarak ayarlayın.
            // Aşağıdaki kod sadece şehir listesini doldurur
            string[] turkSehirler = new string[] {
                "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Şırnak", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak"
            };
            // احذف تعريف ComboBox المتكرر من الكود (يجب أن يبقى فقط تعريف واحد في الأعلى)
            // عند استخدام comboBoxKalkis و comboBoxVaris استخدم فقط المتغيرات التي أنشأها المصمم (Designer)
            this.comboBoxKalkis.Items.Clear();
            this.comboBoxKalkis.Items.AddRange(turkSehirler);
            this.comboBoxVaris.Items.Clear();
            this.comboBoxVaris.Items.AddRange(turkSehirler);
        }

        private void buttonSeferEkle_Click(object? sender, EventArgs e)
        {
            if ((this.comboBoxKalkis?.SelectedItem == null) || (this.comboBoxVaris?.SelectedItem == null) || comboBoxTip?.SelectedItem == null)
                return;
            Sefer sefer;
            if (comboBoxTip.SelectedItem.ToString() == "Şehirlerarası")
                sefer = new Sehirlerarasi { Kalkis = this.comboBoxKalkis.SelectedItem.ToString(), Varis = this.comboBoxVaris.SelectedItem.ToString(), Tarih = dateTimePickerTarih?.Value ?? DateTime.Now, Otobus = new Otobus(20) };
            else
                sefer = new Sehirici { Kalkis = this.comboBoxKalkis.SelectedItem.ToString(), Varis = this.comboBoxVaris.SelectedItem.ToString(), Tarih = dateTimePickerTarih?.Value ?? DateTime.Now, Otobus = new Otobus(15) };
            sefer.Id = seferler.Count + 1;
            seferler.Add(sefer);
            listBoxSeferler?.Items.Add($"{sefer.Id}: {sefer.Kalkis} → {sefer.Varis} - {sefer.Tarih:dd.MM.yyyy}");
            FileHelper.SaveToFile("seferler.json", seferler);
        }

        private async void listBoxSeferler_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxSeferler?.SelectedIndex >= 0)
            {
                seciliSefer = seferler[listBoxSeferler.SelectedIndex];
                panelKoltuklar?.Controls.Clear();
                var koltuklar = seciliSefer.Otobus.Koltuklar ?? new Koltuk[0];
                for (int i = 0; i < koltuklar.Length; i++)
                {
                    var koltuk = koltuklar[i];
                    var btn = new Button();
                    btn.Text = (i + 1).ToString();
                    btn.Width = 70;
                    btn.Height = 70;
                    btn.Font = new Font("Arial", 16, FontStyle.Bold);
                    btn.Tag = i;
                    btn.Margin = new Padding(10);
                    if (koltuk.Dolu)
                    {
                        btn.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        btn.BackColor = Color.LightGreen;
                    }
                    btn.Click += Koltuk_Click;
                    panelKoltuklar?.Controls.Add(btn);
                }
            }
        }

        private void Koltuk_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && seciliSefer != null)
            {
                var koltuklar = seciliSefer.Otobus.Koltuklar ?? new Koltuk[0];
                int no = btn.Tag is int tagInt ? tagInt : Convert.ToInt32(btn.Tag);
                seciliKoltukNo = no;
                foreach (Button b in panelKoltuklar?.Controls!)
                {
                    var koltuk = koltuklar[b.Tag is int t ? t : Convert.ToInt32(b.Tag)];
                    if (koltuk.Dolu)
                    {
                        b.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        b.BackColor = Color.LightGreen;
                    }
                }
                btn.BackColor = Color.Gold;
            }
        }

        private void buttonRezerve_Click(object? sender, EventArgs e)
        {
            var koltuklar = seciliSefer?.Otobus.Koltuklar ?? new Koltuk[0];
            if (seciliSefer != null && seciliKoltukNo != null && seciliKoltukNo.Value < koltuklar.Length)
            {
                if (koltuklar[seciliKoltukNo.Value].Dolu)
                {
                    MessageBox.Show("seçtiğiniz koltuk doludur", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxMusteri?.Text) || string.IsNullOrWhiteSpace(textBoxTelefon?.Text) || string.IsNullOrWhiteSpace(textBoxKimlik?.Text))
                {
                    MessageBox.Show("Lütfen tüm müşteri bilgilerini giriniz (isim, telefon, kimlik).", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                koltuklar[seciliKoltukNo.Value].Dolu = true;
                koltuklar[seciliKoltukNo.Value].MusteriAdi = textBoxMusteri.Text;
                koltuklar[seciliKoltukNo.Value].MusteriTelefon = textBoxTelefon.Text;
                koltuklar[seciliKoltukNo.Value].MusteriKimlik = textBoxKimlik.Text;
                FileHelper.SaveToFile("seferler.json", seferler);
                listBoxSeferler_SelectedIndexChanged(listBoxSeferler, EventArgs.Empty);
            }
        }

        private void buttonBiletYazdir_Click(object? sender, EventArgs e)
        {
            var koltuklar = seciliSefer?.Otobus.Koltuklar ?? new Koltuk[0];
            if (seciliSefer != null && seciliKoltukNo != null && seciliKoltukNo.Value < koltuklar.Length)
            {
                var koltuk = koltuklar[seciliKoltukNo.Value];
                if (koltuk.Dolu)
                {
                    string bilet = $"BİLET\nSefer: {seciliSefer.Kalkis} → {seciliSefer.Varis}\nTarih: {seciliSefer.Tarih:dd.MM.yyyy}\nKoltuk: {koltuk.No}\nMüşteri: {koltuk.MusteriAdi}\nTelefon: {koltuk.MusteriTelefon}\nKimlik : {koltuk.MusteriKimlik}";
                    MessageBox.Show(bilet, "Bilet");
                }
                else
                {
                    MessageBox.Show("Bu koltuk boştur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // زر حذف الرحلة
        private void buttonSeferSil_Click(object sender, EventArgs e)
        {
            if (listBoxSeferler?.SelectedIndex >= 0)
            {
                int idx = listBoxSeferler.SelectedIndex;
                if (idx < seferler.Count)
                {
                    var result = MessageBox.Show("Seçili seferi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        seferler.RemoveAt(idx);
                        listBoxSeferler.Items.RemoveAt(idx);
                        FileHelper.SaveToFile("seferler.json", seferler);
                        seciliSefer = null;
                        panelKoltuklar?.Controls.Clear();
                    }
                }
            }
        }

        // زر إبطال الحجز
        private void buttonRezervasyonIptal_Click(object sender, EventArgs e)
        {
            var koltuklar = seciliSefer?.Otobus.Koltuklar ?? new Koltuk[0];
            if (seciliSefer != null && seciliKoltukNo != null && seciliKoltukNo.Value < koltuklar.Length)
            {
                var koltuk = koltuklar[seciliKoltukNo.Value];
                if (koltuk.Dolu)
                {
                    var result = MessageBox.Show($"{koltuk.No} numaralı koltuğun rezervasyonunu iptal etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        koltuk.Dolu = false;
                        koltuk.MusteriAdi = null;
                        koltuk.MusteriTelefon = null;
                        koltuk.MusteriKimlik = null;
                        FileHelper.SaveToFile("seferler.json", seferler);
                        listBoxSeferler_SelectedIndexChanged(listBoxSeferler, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Bu koltukta zaten rezervasyon yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // صورة الأوتوبوس
            pictureBoxOtobus = new PictureBox();
            pictureBoxOtobus.Size = new Size(350, 120);
            pictureBoxOtobus.Location = new Point(12, 80);
            pictureBoxOtobus.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxOtobus.ImageLocation = "https://cdn.pixabay.com/photo/2013/07/12/18/39/bus-153871_1280.png";
            this.Controls.Add(pictureBoxOtobus);
            // تحميل الرحلات
            var kayitli = FileHelper.LoadFromFile<List<Sefer>>("seferler.json");
            if (kayitli != null)
            {
                seferler = kayitli;
                foreach (var sefer in seferler)
                    listBoxSeferler?.Items.Add($"{sefer.Id}: {sefer.Kalkis} → {sefer.Varis} - {sefer.Tarih:dd.MM.yyyy}");
            }
        }

        private void groupBoxSefer_Enter(object sender, EventArgs e)
        {

        }

        private void panelKoltuklar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelKoltuklar_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxKimlik_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelTip_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

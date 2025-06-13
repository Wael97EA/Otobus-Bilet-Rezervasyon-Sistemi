# Otobüs Bilet Rezervasyon Sistemi - Proje Analizi ve Sınıf Diyagramı

## 1. Problem Analizi
Otobüs Bilet Rezervasyon Sistemi, otobüs yolculukları için sefer oluşturma, koltuk seçimi ve bilet rezervasyonu işlemlerini kolaylaştırmak amacıyla geliştirilmiştir. Manuel işlemlerde yaşanan karışıklıkların ve hataların önüne geçmek, müşteri bilgilerinin düzenli saklanmasını sağlamak ve rezervasyon süreçlerini hızlandırmak hedeflenmiştir.

## 2. Sınıf Yapılarının Planlanması
- **Sefer (Base Class):** Her otobüs seferinin temel bilgilerini (Kalkış, Varış, Tarih, Otobüs) tutar.
- **Sehirlerarasi / Sehirici (Inheritance):** Sefer'den türeyen, şehirlerarası ve şehiriçi seferler için özelleştirilmiş alt sınıflar.
- **Otobus (Composition):** Her seferde bir otobüs bulunur ve otobüs içinde Koltuk[] dizisi ile koltuklar tutulur.
- **Koltuk:** Her koltuk için numara, doluluk durumu ve müşteri bilgileri (isim, telefon, kimlik) saklanır.
- **IRezervasyon (Interface):** Rezervasyon işlemleri için arayüz (rezervasyon yap/iptal).
- **FileHelper:** Verilerin dosyaya kaydedilmesi ve okunması için yardımcı sınıf.

### Sınıf İlişkileri (UML Class Diagram)

```
+-------------------+
|    IRezervasyon   |
+-------------------+
| +RezervasyonYap() |
| +RezervasyonIptal()|
+-------------------+
         ^
         |
+-------------------+
|      Sefer        |
+-------------------+
| Id                |
| Kalkis            |
| Varis             |
| Tarih             |
| Otobus            |
+-------------------+
   ^           ^
   |           |
+---------+ +----------+
|Sehirlerarasi|Sehirici|
+---------+ +----------+
| Mesafe  | | Guzergah |
+---------+ +----------+

Sefer --(has a)--> Otobus --(has)--> Koltuk[]
Koltuk --(has)--> Musteri Bilgileri
```

## 3. Temel Veri Yapılarının Kodlanması
```csharp
// Sefer.cs
public class Sefer {
    public int Id { get; set; }
    public string? Kalkis { get; set; }
    public string? Varis { get; set; }
    public DateTime Tarih { get; set; }
    public Otobus Otobus { get; set; } = new Otobus();
}

// Sehirlerarasi.cs
public class Sehirlerarasi : Sefer {
    public double Mesafe { get; set; }
}

// Sehirici.cs
public class Sehirici : Sefer {
    public string? Guzergah { get; set; }
}

// Otobus.cs
public class Otobus {
    public string? Plaka { get; set; }
    public Koltuk[]? Koltuklar { get; set; }
}

// Koltuk.cs
public class Koltuk {
    public int No { get; set; }
    public bool Dolu { get; set; }
    public string? MusteriAdi { get; set; }
    public string? MusteriTelefon { get; set; }
    public string? MusteriKimlik { get; set; }
}

// IRezervasyon.cs
public interface IRezervasyon {
    void RezervasyonYap(Sefer sefer, int koltukNo, string musteriAdi);
    void RezervasyonIptal(Sefer sefer, int koltukNo);
}
```

**Veri Saklama:**
Tüm sefer ve rezervasyon bilgileri `seferler.json` dosyasında JSON formatında saklanır ve okunur.

---

Bu dosyayı Word veya PDF olarak çıktı alıp, diyagramı elle veya bir çizim aracıyla daha görsel hale getirebilirsin. Eğer diyagramı görsel olarak (PNG, SVG) istersen، أخبرني بذلك.

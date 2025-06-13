namespace OtobusBiletRezervasyon;

public interface IRezervasyon
{
    void RezervasyonYap(Sefer sefer, int koltukNo, string musteriAdi);
    void RezervasyonIptal(Sefer sefer, int koltukNo);
}

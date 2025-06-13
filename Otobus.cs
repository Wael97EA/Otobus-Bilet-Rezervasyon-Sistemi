namespace OtobusBiletRezervasyon;

public class Otobus
{
    public string? Plaka { get; set; }
    public Koltuk[]? Koltuklar { get; set; }

    public Otobus()
    {
        Koltuklar = new Koltuk[0];
    }
    public Otobus(int koltukSayisi)
    {
        Koltuklar = new Koltuk[koltukSayisi];
        for (int i = 0; i < koltukSayisi; i++)
        {
            Koltuklar[i] = new Koltuk { No = i + 1, Dolu = false };
        }
    }
}

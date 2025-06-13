namespace OtobusBiletRezervasyon
{
    public class Sefer
    {
        public int Id { get; set; }
        public string? Kalkis { get; set; }
        public string? Varis { get; set; }
        public DateTime Tarih { get; set; }
        public Otobus Otobus { get; set; } = new Otobus();

        public Sefer() { }
    }
}

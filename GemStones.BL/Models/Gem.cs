namespace GemStones.BL.Models
{
    public class Gem
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}


using System.Collections.Generic;

namespace GemStones.BL.Models
{
    public class Product
    {
        public Product()
        {
            Gems = new List<Gem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Type Type { get; set; }
        public List<Gem> Gems { get; set; }
    }
}

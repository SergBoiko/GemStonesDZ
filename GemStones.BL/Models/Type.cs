using System.Collections.Generic;

namespace GemStones.BL.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Type()
        {
            Products = new List<Product>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemStones.DAL.Entities
{
    public class GemEntity
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public ProductEntity Product { get; set; }
    }
}

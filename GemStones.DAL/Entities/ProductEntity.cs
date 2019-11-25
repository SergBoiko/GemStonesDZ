using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemStones.DAL.Entities
{
    public class ProductEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TypeEntity Type { get; set; }
        public int Stone { get; set; }
        public ICollection<GemEntity> Gems { get; set; }
    }
}

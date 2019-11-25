using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemStones.DAL.Entities
{
    public class TypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

        public TypeEntity()
        {
            Products = new List<ProductEntity>();
        }
    }
}

using GemStones.DAL.Entities;
using GemStones.DAL.Repositories.Interfaces;

namespace GemStones.DAL.Repositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
    }
}

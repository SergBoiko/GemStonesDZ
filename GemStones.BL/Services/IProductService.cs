using GemStones.BL.Models;
using System.Collections.Generic;

namespace GemStones.BL.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        List<Product> GetProductByType(int typeId);
        List<Product> GetProductByGems(bool containsGems);
        int AddProduct(Product product);
        int AddStoneToProduct(int productId, Gem gem);
    }
}

using GemStones.BL.Models;
using GemStones.BL.Services;
using GemStones.Presentation.Services.Interfaces;
using GemStones.Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace GemStones.Presentation.Services
{
    public class ProductViewService : IProductViewService
    {
        private readonly IProductService productService;

        public ProductViewService()
        {
            productService = new ProductService();
        }

        public List<ProductView> GetProductByGems(bool containsGems)
        {
            return productService.GetProductByGems(containsGems).Select(x => MapViewModel(x)).ToList();
        }

        public ProductView GetProductById(int id)
        {
            return MapViewModel(productService.GetProductById(id));
        }

        public List<ProductView> GetProductByType(int typeId)
        {
            return productService.GetProductByType(typeId).Select(x => MapViewModel(x)).ToList();
        }

        private ProductView MapViewModel(Product product)
        {
            return new ProductView()
            {
                Id = product.Id,
                Price = product.Price + product.Gems.Sum(x => x.Price),
                Type = product.Type.Name
            };
        }
    }
}

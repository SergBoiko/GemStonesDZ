using GemStones.BL.Models;
using GemStones.DAL.Entities;
using GemStones.DAL.Repositories;
using GemStones.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GemStones.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IGemRepository gemRepository;

        public ProductService()
        {
            this.productRepository = new ProductRepository();
            this.gemRepository = new GemRepository();
        }

        public int AddProduct(Product product)
        {
            var entity = new ProductEntity()
            {
                Name = product.Name,
                Price = product.Price
            };

            productRepository.Create(entity);

            return entity.Id;
        }

        public int AddStoneToProduct(int productId, Gem gem)
        {
            var product = productRepository.FindById(productId);

            if (product.Gems.Count > 10)
            {
                throw new System.Exception("Number of gems should be lower or equal to 10");
            }

            var gemEntity = new GemEntity()
            {
                Color = gem.Color,
                Price = gem.Price,
                Size = gem.Size,
                Product = product
            };

            gemRepository.Create(gemEntity);

            return gemEntity.Id;
        }

        public List<Product> GetProductByGems(bool containsGems)
        {
            return productRepository.GetWithInclude(x => x.Gems.Any() == containsGems, p => p.Gems, q => q.Type)
                .Select(x => MapToDomain(x))
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return MapToDomain(productRepository.GetWithInclude(x=> x.Id == id, p => p.Gems, q => q.Type).FirstOrDefault());
        }

        public List<Product> GetProductByType(int typeId)
        {
            return productRepository.GetWithInclude(x => x.Type.Id == typeId, p => p.Gems, q => q.Type)
                .Select(x => MapToDomain(x))
                .ToList();
        }

        private Product MapToDomain(ProductEntity entity)
        {
            return new Product()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Type = MapToDomain(entity.Type),
                Gems = entity.Gems.Select(x => MapToDomain(x)).ToList()
            };
        }

        private Type MapToDomain(TypeEntity entity)
        {
            return new Type()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private Gem MapToDomain(GemEntity entity)
        {
            return new Gem()
            {
                Id = entity.Id,
                Color = entity.Color,
                Price = entity.Price,
                Size = entity.Size
            };
        }
    }
}

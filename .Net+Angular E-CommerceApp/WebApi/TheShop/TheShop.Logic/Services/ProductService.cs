using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DataAccess.Interfaces;
using TheShop.Domain.Models;
using TheShop.Logic.Interfaces;
using TheShop.Specifications;

namespace TheShop.Logic.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductService(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType>
            productTypeRepo)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _productBrandRepo.ListAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _productTypeRepo.ListAllAsync();
        }

        public async Task<(IReadOnlyList<Product> products, int count)> ListProducts(ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

            var countSpec = new ProductWithFilterForCountSpecification(productSpecParams);

            var totalItems = await _productsRepo.CountAsync(countSpec);

            var products = await _productsRepo.ListAsync(spec);

            return (products, totalItems);
        }
    }
}

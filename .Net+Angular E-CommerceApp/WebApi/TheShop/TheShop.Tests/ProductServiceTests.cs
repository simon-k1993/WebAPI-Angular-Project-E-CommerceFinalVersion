using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.DataAccess.Interfaces;
using TheShop.Domain.Models;
using TheShop.Logic.Interfaces;
using TheShop.Logic.Services;
using TheShop.Specifications;
using Xunit;

namespace TheShop.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IGenericRepository<Product>> _productsRepo;
        private readonly Mock<IGenericRepository<ProductBrand>> _productBrandRepo;
        private readonly Mock<IGenericRepository<ProductType>> _productTypeRepo;
        private readonly IProductService _productService;
        public ProductServiceTests()
        {
            _productsRepo = new Mock<IGenericRepository<Product>>();
            _productBrandRepo = new Mock<IGenericRepository<ProductBrand>>();
            _productTypeRepo = new Mock<IGenericRepository<ProductType>>();

            _productService = new ProductService(_productsRepo.Object, _productBrandRepo.Object, _productTypeRepo.Object);
        }

        [Fact]
        public async Task ListProducts_ReturnsCorrectTuple()
        {
            //arrange
            var request = new ProductSpecParams();
            var totalProducts = 5;
            var productsToReturn = new List<Product> { new Product { Id = 1, }, new Product { Id = 2 } };
            _productsRepo.Setup(x => x.ListAsync(It.IsAny<ProductsWithTypesAndBrandsSpecification>())).ReturnsAsync(productsToReturn);
            _productsRepo.Setup(x => x.CountAsync(It.IsAny<ProductWithFilterForCountSpecification>())).ReturnsAsync(totalProducts);

            //act
            var result = await _productService.ListProducts(request);


            //assert
            Assert.Equal(5, result.count);
            Assert.Equal(productsToReturn, result.products);
        }
    }
}


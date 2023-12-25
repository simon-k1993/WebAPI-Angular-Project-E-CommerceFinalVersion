using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Models;
using TheShop.Specifications;

namespace TheShop.Logic.Interfaces
{
    public interface IProductService
    {
        Task<(IReadOnlyList<Product> products, int count)> ListProducts(ProductSpecParams productSpecParams);
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}

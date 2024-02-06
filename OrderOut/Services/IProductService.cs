using OrderOut.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Services
{
    public interface IProductService
    {
        ProductDto GetProduct(int productId);
        Task<bool> CreateProduct(ProductDto request);
        Task<List<ProductDto>> GetAllProducts();
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(ProductDto request);
    }
}

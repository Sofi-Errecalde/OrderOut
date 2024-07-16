using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Services.product
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productId);
        Task<bool> CreateProduct(ProductDto request);
        Task<bool> CreateProductWhithPhoto(ProductDto request);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByCategory(int categoryId);
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(ProductDto request);
    }
}

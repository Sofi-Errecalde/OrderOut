using OrderOut.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Repositorys
{
    public interface IProductRepository
    {
        Task<Product?> GetProduct(int productId);
        Task<bool> CreateProduct(Product newProduct);
        Task<List<Product>> GetAllProducts();
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(Product Product);
    }
}

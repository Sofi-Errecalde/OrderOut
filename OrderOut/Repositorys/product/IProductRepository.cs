using OrderOut.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Repositorys.product
{
    public interface IProductRepository
    {
        Task<Product?> GetProduct(int productId);
        Task<bool> CreateProduct(Product newProduct);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByCategory(int categoryId);
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(Product Product);
    }
}

using OrderOut.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Services.product
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        Task<bool> CreateProduct(Product request);
        List<Product> GetAllProducts();
        Task<bool> DeleteProduct(int productId);
        Task<bool> UpdateProduct(Product request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(int productId)
        {
            return DBContext.Product.Where(x => x.id == productId);

        }
    }
}

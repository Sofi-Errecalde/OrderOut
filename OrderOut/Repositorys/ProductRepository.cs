using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<Product?> GetProduct(int productId)
        {
            return await _appDbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

        }

        public async Task<bool> CreateProduct(Product newProduct)
        {
            try
            {
                await _appDbContext.AddAsync(newProduct);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;   
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys.product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product?> GetProduct(int productId)
        {
            return await _appDbContext.Products.Where(x => x.Id == productId && x.IsDeleted == false).FirstOrDefaultAsync();

        }

        public async Task<bool> CreateProduct(Product newProduct)
        {
            try
            {
                _appDbContext.Add(newProduct);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _appDbContext.Products.Where(x => x.IsDeleted == false).ToListAsync();

        }

        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            return await _appDbContext.Products.Where(x => x.CategoryId == categoryId && x.IsDeleted == false).ToListAsync();

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _appDbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if (product != null)
            {
                try
                {   
                    product.IsDeleted = true;
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;

        }

        public async Task<bool> UpdateProduct(Product Product)
        {
            try
            {
                _appDbContext.Update(Product);
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

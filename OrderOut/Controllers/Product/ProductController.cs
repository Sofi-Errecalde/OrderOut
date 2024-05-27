using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Repositorys;
using OrderOut.Services.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        

        [HttpGet]
        [Route("GetProduct")]
        public Product GetProduct(int productId)
        {
            var response = _productService.GetProduct(productId);

            return response;
        }

        [HttpGet]
        [Route("AllProducts")]
        public List<Product> AllProducts()
        {
            var response = _productService.GetAllProducts();

            return response;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<bool> CreateProduct(Product product)
        {
            var response = await _productService.CreateProduct(product);

            return response;
        }
       
        
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProduct(Product product)
        {
            var response = await _productService.UpdateProduct(product);

            return response;
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<bool> DeleteProduct(int productId)
        {
            var response = await _productService.DeleteProduct(productId);

            return response;
        }
    }
}

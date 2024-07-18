using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderOut.DtosOU.Dtos;
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

        //[Authorize(Policy = "Usuario")]
        [HttpGet]
        [Route("GetProduct")]
        public async Task<Product> GetProduct(int productId)
        {
            var response = await _productService.GetProduct(productId);

            return response;
        }

        [HttpGet]
        [Route("GetProductPhoto")]
        public async Task<ProductDto> GetProductPhoto(int productId)
        {
            var response = await _productService.GetProductPhoto(productId);

            return response;
        }


        [HttpGet]
        [Route("AllProducts")]
        public Task<List<Product>> AllProducts()
        {
            var response = _productService.GetAllProducts();

            return response;
        }

        [HttpGet]
        [Route("GetProductByCategory")]
        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            var response = await _productService.GetProductByCategory(categoryId);

            return response;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<bool> CreateProduct(ProductDto product)
        {
            var response = await _productService.CreateProduct(product);

            return response;
        }

        [HttpPost]
        [Route("CreateProductWhithPhoto")]
        public async Task<bool> CreateProductWhithPhoto(ProductDto product)
        {
            var response = await _productService.CreateProductWhithPhoto(product);

            return response;
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProduct(ProductDto product)
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

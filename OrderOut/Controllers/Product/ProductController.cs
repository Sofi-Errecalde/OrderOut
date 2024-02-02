using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderOut.Dtos;
using OrderOut.Repositorys;
using OrderOut.Services;
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

        [HttpGet(Name = "GetProduct")]
        public ProductDto GetProduct(int productId)
        {
            var response = _productService.GetProduct(productId);

            return response;
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<bool> CreateProduct(ProductDto product)
        {
            var response = await _productService.CreateProduct(product);

            return response;
        }
    }
}

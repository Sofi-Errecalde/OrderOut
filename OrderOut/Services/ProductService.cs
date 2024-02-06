using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderOut.Repositorys;
using OrderOut.Dtos;
using AutoMapper;
using OrderOut.EF.Models;
namespace OrderOut.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
                                IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public ProductDto GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            var response = _mapper.Map<ProductDto>(product);
            return response;
        }
        
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var response = _mapper.Map<List<ProductDto>>(products);
            return response;

        }

        public async Task<bool> CreateProduct(ProductDto request)
        {

            var newProduct = _mapper.Map<Product>(request);
            var response = await _productRepository.CreateProduct(newProduct);
            return response;
        }

         public async Task<bool> DeleteProduct(int productId)
         {
            return await _productRepository.DeleteProduct(productId);
         }

         public async Task<bool> UpdateProduct(ProductDto request)
         {
            var product = _mapper.Map<Product>(request);
            var response = await _productRepository.UpdateProduct(product);
             return response;
         }
    }
}

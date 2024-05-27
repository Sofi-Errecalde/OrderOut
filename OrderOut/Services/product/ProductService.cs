using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys.product;
namespace OrderOut.Services.product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
                                IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Product GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            var response = _mapper.Map<Product>(product);
            return response;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            var response = _mapper.Map<List<Product>>(products);
            return response;

        }

        public async Task<bool> CreateProduct(Product request)
        {

            var newProduct = _mapper.Map<Product>(request);
            var response = await _productRepository.CreateProduct(newProduct);
            return response;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        public async Task<bool> UpdateProduct(Product request)
        {
            var product = _mapper.Map<Product>(request);
            var response = await _productRepository.UpdateProduct(product);
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Repositorys.product;
using OrderOut.Services.photo;
namespace OrderOut.Services.product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly PhotoService _photoService;

        public ProductService(IProductRepository productRepository,
                                IMapper mapper, PhotoService photoService )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            if(product == null)
            {
                throw new Exception("ID de producto inexistente");
            }
            var response = _mapper.Map<Product>(product);
            return response;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if (products == null)
            {
                throw new Exception("No hay productos disponibles");
            }
            var response = _mapper.Map<List<Product>>(products);
            return response;

        }

        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductByCategory(categoryId);
            if (products.IsNullOrEmpty())
            {
                throw new Exception("No hay productos disponibles para la categoría");
            }
            var response = _mapper.Map<List<Product>>(products);
            return response;
        }

        public async Task<bool> CreateProduct(ProductDto request)
        {

            var newProduct = _mapper.Map<Product>(request);
            try
            {
                await _productRepository.CreateProduct(newProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar crear el producto");
            }
            return true;
        }


        public async Task<bool> CreateProductWhithPhoto(ProductDto request)
        {

            var newProduct = _mapper.Map<Product>(request);
            try
            {
                var img = await _photoService.UploadPhotoAsync(request.Photo);
                newProduct.ImageUrl = img;
                await _productRepository.CreateProduct(newProduct);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar crear el producto");
            }
            return true;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                await _productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                 throw new Exception("Ocurrio un error al intentar eliminar el producto");
            }
            return true;
        }

        public async Task<bool> UpdateProduct(ProductDto request)
        {
            var product = _mapper.Map<Product>(request);
            try
            {
               await _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar modificar el producto");
            }
            return true;
        }
    }
}

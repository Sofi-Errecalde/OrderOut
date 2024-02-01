using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderOut.Repositorys;
using OrderOut.Dtos;

namespace OrderOut.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IProductRepository productRepository,
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

        public ProductDto GetAllProducts()
        {


        }

        public async Task<BaseResult<bool>> CreateProduct()
        {

        }
        public async Task<BaseResult<bool>> DeleteProduct()
        {

        }
        public async Task<BaseResult<bool>> UpdateProduct()
        {

        }
    }
}

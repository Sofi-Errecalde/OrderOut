using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,
                            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public  List<Order> GetAllOrders()
        {
            var orders =  _orderRepository.GetAllOrders();
            var response = _mapper.Map<List<Order>>(orders);
            return response;
        }

        public  Order GetOrder(int orderId)
        {
            var order =  _orderRepository.GetOrder(orderId);
            var response = _mapper.Map<Order>(order);
            return response;
        }

        public async Task<bool> CreateOrder(Order request)
        {
            var newOrder = _mapper.Map<Order>(request);
            var response = await _orderRepository.CreateOrder(newOrder);
            return response;
        }

        public async Task<bool> UpdateOrder(Order request)
        {
            var order = _mapper.Map<Order>(request);
            var response = await _orderRepository.UpdateOrder(order);
            return response;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var response = await _orderRepository.DeleteOrder(orderId);
            return response;
        }
    }
}

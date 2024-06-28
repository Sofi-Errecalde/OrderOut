using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Repositorys;

namespace OrderOut.Services.order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepository orderRepository,AppDbContext context,
                            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders =  await _orderRepository.GetAllOrders();
            var response = _mapper.Map<List<Order>>(orders);
            return response;
        }

        public async Task<Order> GetOrder(int orderId)
        {
            var order =  await _orderRepository.GetOrder(orderId);
            var response = _mapper.Map<Order>(order);
            return response;
        }

        public async Task<bool> CreateOrder(NewOrderDto request)
        {
            var newOrder = _mapper.Map<Order>(request);
            var orderProducts = new List<OrderProduct>();
            foreach (var product in request.OrdersProducts)
            {
                 var addProduct= new OrderProduct();
                addProduct.ProductId = product.ProductId;
                addProduct.Clarification = product.Clarification;
                addProduct.Quantity = product.Quantity;
                orderProducts.Add(addProduct);
            }
            var response = await _orderRepository.CreateOrder(newOrder,orderProducts);

            //if (response)
            //{
            //    foreach (var productId in request.OrdersProducts)
            //    {
            //        var orderProduct = new OrderProduct(newOrder,product);
            //        _context.OrderProducts.Add(orderProduct);
            //    }

            //    await _context.SaveChangesAsync();
            //}

            return response;
        }

        public async Task<bool> UpdateOrderStatus(OrderStatusDto request)
        {
            var response = await _orderRepository.UpdateOrderStatus(request);
            return response;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var response = await _orderRepository.DeleteOrder(orderId);
            return response;
        }

        internal async Task updateStatus(int id, string v)
        {
            throw new NotImplementedException();
        }
    }
}

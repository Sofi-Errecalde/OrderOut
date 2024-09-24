using Microsoft.AspNetCore.Mvc;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Services.order;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetOrder")]
        public async Task<Order> GetOrder(int orderId)
        {
            return await _orderService.GetOrder(orderId);
        }

        [HttpGet]
        [Route("AllOrders")]
        public async Task<List<Order>> AllOrders()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<List<Order>> CreateOrder(NewOrderDto order)
        {
            return await _orderService.CreateOrder(order);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<bool> UpdateOrderStatus(OrderStatusDto request)
        {
            return await _orderService.UpdateOrderStatus(request);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<bool> DeleteOrder(int orderId)
        {
            return await _orderService.DeleteOrder(orderId);
        }
    }
}

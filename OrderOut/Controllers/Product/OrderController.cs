using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
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
        public async Task<bool> CreateOrder(Order order)
        {
            return await _orderService.CreateOrder(order);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<bool> UpdateOrder(Order order)
        {
            return await _orderService.UpdateOrder(order);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<bool> DeleteOrder(int orderId)
        {
            return await _orderService.DeleteOrder(orderId);
        }
    }
}

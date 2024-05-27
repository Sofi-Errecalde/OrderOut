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
        public Order GetOrder(int orderId)
        {
            return _orderService.GetOrder(orderId);
        }

        [HttpGet]
        [Route("AllOrders")]
        public List<Order> AllOrders()
        {
            return _orderService.GetAllOrders();
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

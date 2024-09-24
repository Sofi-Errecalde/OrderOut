using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;

namespace OrderOut.Services.order
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int orderId);
        Task<List<Order>> CreateOrder(NewOrderDto request);
        Task<bool> UpdateOrderStatus(OrderStatusDto request);
        Task<bool> DeleteOrder(int orderId);
    }
}

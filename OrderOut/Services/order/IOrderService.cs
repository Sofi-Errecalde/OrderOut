using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.order
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int orderId);
        Task<bool> CreateOrder(Order request);
        Task<bool> UpdateOrder(Order request);
        Task<bool> DeleteOrder(int orderId);
    }
}

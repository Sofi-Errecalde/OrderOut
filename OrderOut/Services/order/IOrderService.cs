using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.order
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrder(int orderId);
        Task<bool> CreateOrder(Order request);
        Task<bool> UpdateOrder(Order request);
        Task<bool> DeleteOrder(int orderId);
    }
}

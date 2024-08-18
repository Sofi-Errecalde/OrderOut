using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetAllOrdersForBill(int billId);
        Task<Order?> GetOrder(int orderId);
        Task<Order> CreateOrder(Order order, List<OrderProduct> products);
        Task<bool> UpdateOrderStatus(OrderStatusDto order);
        Task<bool> DeleteOrder(int orderId);
    }
}

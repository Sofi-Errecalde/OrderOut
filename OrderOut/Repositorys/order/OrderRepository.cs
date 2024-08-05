using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrder(int orderId)
        {
            var order = await _context.Orders
                              .Include(o => o.User)
                              .Include(o => o.Table)
                              .Include(o => o.Bill)
                              .Include(o => o.Products)
                                .ThenInclude(op => op.Product)
                              .FirstOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task<Order> CreateOrder(Order order, List<OrderProduct> products)
        {   
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            foreach (var product in products)
            { product.OrderId= order.Id; }
            _context.AddRange(products);
            await _context.SaveChangesAsync();
            return await GetOrder((int)order.Id);
        }

        public async Task<bool> UpdateOrderStatus(OrderStatusDto request)
        {   
            var order = await _context.Orders.Where(o => o.Id == request.OrderId).FirstOrDefaultAsync();
            order.Status = request.OrderStatus;
            _context.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.Where(x=>x.Id == orderId).FirstOrDefaultAsync();
            if (order == null)
                return false;
            order.IsDeleted = true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

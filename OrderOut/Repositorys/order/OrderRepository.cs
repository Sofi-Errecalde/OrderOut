using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
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
                              .Include(o => o.Products)
                                .ThenInclude(op => op.Product)
                              .FirstOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task<bool> CreateOrder(Order order, List<OrderProduct> products)
        {   
            _context.Orders.Add(order);
            foreach(var product in products)
            { product.OrderId= order.Id; }
            _context.AddRange(products);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

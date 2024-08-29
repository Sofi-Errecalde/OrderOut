using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys.NewFolder
{
    public class OrderProductRepository
    {
        private readonly AppDbContext _context;

        public OrderProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderProduct>> GetAll()
        {
            return await _context.OrderProducts
                 .Include(o => o.Product)
                 .ToListAsync();
        }
    }
}

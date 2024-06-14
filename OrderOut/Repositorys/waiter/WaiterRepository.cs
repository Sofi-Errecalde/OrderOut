using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class WaiterRepository : IWaiterRepository
    {
        private readonly AppDbContext _context;

        public WaiterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Waiter>> GetAllWaiters()
        {
            return await _context.Waiters.ToListAsync();
        }

        public async Task<Waiter?> GetWaiter(int waiterId)
        {
            return await _context.Waiters.Where(x => x.Id == waiterId && x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateWaiter(Waiter waiter)
        {
            _context.Waiters.Add(waiter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateWaiter(Waiter waiter)
        {
           _context.Update(waiter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteWaiter(int waiterId)
        {
            var waiter = await _context.Waiters.Where(x => x.Id == waiterId).FirstOrDefaultAsync();
            if (waiter == null)
                return false;
            waiter.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

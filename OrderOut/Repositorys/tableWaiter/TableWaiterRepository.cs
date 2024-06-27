using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class TableWaiterRepository : ITableWaiterRepository
    {
        private readonly AppDbContext _context;

        public TableWaiterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TableWaiter>> GetAllTablesWaiters()
        {
            return await _context.TablesWaiters.ToListAsync();
        }

        public async Task<TableWaiter?> GetTableWaiter(int tableWaiterId)
        {
            return await _context.TablesWaiters.Where(x => x.Id == tableWaiterId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<bool> AssignTablesToWaiters(TableWaiter tableWaiter)
        {
            _context.TablesWaiters.Add(tableWaiter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTableWaiter(TableWaiter tableWaiter)
        {
            _context.Update(tableWaiter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTableWaiter(int tableWaiterId)
        {
            var tableWaiter = await _context.TablesWaiters.Where(x => x.Id == tableWaiterId && !x.IsDeleted).FirstOrDefaultAsync();
            if (tableWaiter == null)
                return false;
            tableWaiter.IsDeleted = true;
            _context.TablesWaiters.Update(tableWaiter);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

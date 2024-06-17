using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;

using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Table>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table?> GetTable(int tableId)
        {
            return await _context.Tables.Where(x => x.Id == tableId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignTablesToWaiters(TableWaiter tableWaiter)
        {
            _context.TablesWaiters.Add(tableWaiter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTable(Table table)
        {
            _context.Entry(table).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTable(int tableId)
        {
            var table = await _context.Tables.Where(x=> x.Id == tableId && !x.IsDeleted).FirstOrDefaultAsync();
            if (table == null)
                return false;
            table.IsDeleted = true;
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

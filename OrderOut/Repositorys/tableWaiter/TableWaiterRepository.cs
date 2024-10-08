﻿using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;
using OrderOut.Enums;

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
            return await _context.TablesWaiters.Include(x => x.Table).Include(x => x.Waiter).ToListAsync();
        }

        public async Task<TableWaiter?> GetTableWaiter(int tableWaiterId)
        {
            return await _context.TablesWaiters.Include(x => x.Table).Include(x => x.Waiter).Where(x => x.Id == tableWaiterId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<TableWaiter?> GetTableWaiterByTable(int tableId)
        {
            return await _context.TablesWaiters.Include(x => x.Table).Include(x => x.Waiter).Where(x => x.TableId == tableId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<TableWaiter?> GetTableWaiterForBill(int tableId, int shift)
        {
            var tableWaiter = await _context.TablesWaiters.Include(tw => tw.Table).Where(x => x.TableId == tableId && x.Shift == shift ).FirstOrDefaultAsync();
            return tableWaiter;
        }

        public async Task<bool> AssignTablesToWaiters(TableWaiter tableWaiter)
        {   
            var deleteWaiter = await GetTableWaiterForBill((int)tableWaiter.TableId, tableWaiter.Shift);
            if (deleteWaiter is not null)
            {
                var ok = await DeleteTableWaiter((int)deleteWaiter.Id);
            }
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

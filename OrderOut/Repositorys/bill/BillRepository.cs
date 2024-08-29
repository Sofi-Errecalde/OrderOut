using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _context;

        public BillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bill?> GetBill(long billId)
        {
            var bill = await _context.Bills.Include(x => x.TableWaiter).FirstOrDefaultAsync(o => o.Id == billId);
            return bill;
        }

        public async Task<List<Bill>> GetAll(DateTime startDate, DateTime endDate)
        {
            return await _context.Bills.Include(bill => bill.TableWaiter)
                                            .ThenInclude(tableWaiter => tableWaiter.Waiter)
                                        .Include(bill => bill.TableWaiter)
                                            .ThenInclude(tableWaiter => tableWaiter.Table)
                                        .Where(x => (x.Date).Date >= startDate.Date && (x.Date).Date <= endDate.Date)
                                        .ToListAsync();
        }
        public async Task<List<Bill>> GetBills(DateTime startDate, DateTime endDate)
        {
            return await _context.Bills.Include(x=> x.TableWaiter).Where(x=> (x.Date).Date >= startDate.Date && (x.Date).Date <= endDate.Date).ToListAsync();
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        public async Task<Bill> UpdateBill(Bill request)
        {
             _context.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        //public async Task<bool> DeleteOrder(int orderId)
        //{
        //    var order = await _context.Orders.Where(x => x.Id == orderId).FirstOrDefaultAsync();
        //    if (order == null)
        //        return false;
        //    order.IsDeleted = true;
        //    _context.Orders.Update(order);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IBillRepository
    {
        Task<Bill> GetBill(long billId);
        Task<List<Bill>> GetAll();

        Task<List<Bill>> GetBills(DateTime startDate, DateTime endDate);
        Task<Bill> CreateBill(Bill bill);
        Task<Bill> UpdateBill(Bill request);
        //Task<bool> DeleteBill(int billId);
    }
}

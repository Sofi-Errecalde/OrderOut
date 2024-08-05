using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.bill
{
    public interface IBillService
    {
        //Task<List<Order>> GetAllBills();
        Task<Bill> GetBill(long billId);
        Task<Bill> CreateBill(CreateBillDto request);
        Task<Bill> UpdateBill(Bill bill);
        //Task<bool> DeleteBill(int billId);
    }
}

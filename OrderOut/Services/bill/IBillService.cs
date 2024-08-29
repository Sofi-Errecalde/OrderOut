using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;

namespace OrderOut.Services.bill
{
    public interface IBillService
    {
        Task<Bill> GetBill(long billId);
        Task<List<Bill>> GetBills(DateTime startDate, DateTime endDate);
        Task<Bill> CreateBill(CreateBillDto request);
        Task<Bill> UpdateBill(Bill bill);
        
        Task<StatisticsDto> GetStatistics();
        Task<Bill> UpdateBillPaid(int billId, bool isPaid, WayToPayEnum wayToPay);
        //Task<bool> DeleteBill(int billId);
    }
}

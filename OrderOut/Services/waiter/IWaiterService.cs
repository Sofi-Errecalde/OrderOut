using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.waiter
{
    public interface IWaiterService
    {
        Task<List<Waiter>> GetAllWaiters();
        Task<Waiter> GetWaiter(int waiterId);
        Task<bool> CreateWaiter(WaiterDto request);
        Task<bool> UpdateWaiter(WaiterDto request);
        Task<bool> DeleteWaiter(int waiterId);
    }
}

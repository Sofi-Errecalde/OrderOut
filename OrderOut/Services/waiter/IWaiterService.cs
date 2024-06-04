using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.waiter
{
    public interface IWaiterService
    {
        Task<List<Waiter>> GetAllWaiters();
        Task<Waiter> GetWaiter(int waiterId);
        Task<bool> CreateWaiter(Waiter request);
        Task<bool> UpdateWaiter(Waiter request);
        Task<bool> DeleteWaiter(int waiterId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IWaiterRepository
    {
        Task<List<Waiter>> GetAllWaiters();
        Task<Waiter?> GetWaiter(int waiterId);
        Task<bool> CreateWaiter(Waiter waiter);
        Task<bool> UpdateWaiter(Waiter waiter);
        Task<bool> DeleteWaiter(int waiterId);
    }
}

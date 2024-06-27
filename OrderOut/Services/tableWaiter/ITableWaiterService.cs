using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.tableWaiter
{
    public interface ITableWaiterService
    {
        Task<List<TableWaiter>> GetAllTablesWaiters();
        Task<TableWaiter> GetTableWaiter(int tableWaiterId);
        Task<bool> AssignTablesToWaiters(TableWaiterDto request);
        Task<bool> UpdateTableWaiter(TableWaiterDto request);
        Task<bool> DeleteTableWaiter(int tableWaiterId);
    }
}

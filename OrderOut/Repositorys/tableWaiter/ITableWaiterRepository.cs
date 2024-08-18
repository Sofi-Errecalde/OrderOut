using OrderOut.EF.Models;
using OrderOut.Enums;

namespace OrderOut.Repositorys
{
    public interface ITableWaiterRepository
    {
        Task<List<TableWaiter>> GetAllTablesWaiters();
        Task<TableWaiter?> GetTableWaiter(int tableWaiterId);
        Task<TableWaiter?> GetTableWaiterByTable(int tableId);
        Task<TableWaiter?> GetTableWaiterForBill(int tableId, int shift);
        Task<bool> AssignTablesToWaiters(TableWaiter tableWaiter);
        Task<bool> UpdateTableWaiter(TableWaiter tableWaiter);
        Task<bool> DeleteTableWaiter(int tableWaiterId);
    }
}

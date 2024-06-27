using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface ITableWaiterRepository
    {
        Task<List<TableWaiter>> GetAllTablesWaiters();
        Task<TableWaiter?> GetTableWaiter(int tableWaiterId);
        Task<bool> AssignTablesToWaiters(TableWaiter tableWaiter);
        Task<bool> UpdateTableWaiter(TableWaiter tableWaiter);
        Task<bool> DeleteTableWaiter(int tableWaiterId);
    }
}

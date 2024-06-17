using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.table
{
    public interface ITableService
    {
        Task<List<Table>> GetAllTables();
        Task<Table> GetTable(int tableId);
        Task<bool> CreateTable(TableDto request);
        Task<bool> AssignTablesToWaiters(TableWaiterDto request);
        Task<bool> UpdateTable(TableDto request);
        Task<bool> DeleteTable(int tableId);
    }
}

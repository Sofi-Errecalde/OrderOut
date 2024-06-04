using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.table
{
    public interface ITableService
    {
        Task<List<Table>> GetAllTables();
        Task<Table> GetTable(int tableId);
        Task<bool> CreateTable(Table request);
        Task<bool> UpdateTable(Table request);
        Task<bool> DeleteTable(int tableId);
    }
}

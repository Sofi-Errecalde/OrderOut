using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTables();
        Task<Table?> GetTable(int tableId);
        Task<bool> CreateTable(Table table);
        Task<bool> UpdateTable(Table table);
        Task<bool> DeleteTable(int tableId);
    }
}

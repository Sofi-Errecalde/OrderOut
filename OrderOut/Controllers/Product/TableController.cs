using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.table;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        [Route("GetTable")]
        public Table GetTable(int tableId)
        {
            return _tableService.GetTable(tableId);
        }

        [HttpGet]
        [Route("AllTables")]
        public List<Table> AllTables()
        {
            return _tableService.GetAllTables();
        }

        [HttpPost]
        [Route("CreateTable")]
        public async Task<bool> CreateTable(Table table)
        {
            return await _tableService.CreateTable(table);
        }

        [HttpPut]
        [Route("UpdateTable")]
        public async Task<bool> UpdateTable(Table table)
        {
            return await _tableService.UpdateTable(table);
        }

        [HttpDelete]
        [Route("DeleteTable")]
        public async Task<bool> DeleteTable(int tableId)
        {
            return await _tableService.DeleteTable(tableId);
        }
    }
}

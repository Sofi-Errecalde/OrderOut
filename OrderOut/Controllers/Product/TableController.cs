using Microsoft.AspNetCore.Mvc;
using OrderOut.DtosOU.Dtos;
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
        public async Task<Table> GetTable(int tableId)
        {
            return await _tableService.GetTable(tableId);
        }

        [HttpGet]
        [Route("AllTables")]
        public async Task<List<Table>> AllTables()
        {
            return await _tableService.GetAllTables();
        }

        [HttpPost]
        [Route("CreateTable")]
        public async Task<bool> CreateTable(TableDto table)
        {
            return await _tableService.CreateTable(table);
        }

        //[HttpPost]
        //[Route("AssignTablesToWaiters")]
        //public async Task<bool> AssignTablesToWaiters(TableWaiterDto tableWaiter)
        //{
        //    return await _tableService.AssignTablesToWaiters(tableWaiter);
        //}

        [HttpPut]
        [Route("UpdateTable")]
        public async Task<bool> UpdateTable(TableDto table)
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

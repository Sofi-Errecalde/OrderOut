using Microsoft.AspNetCore.Mvc;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Services.tableWaiter;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableWaiterController : Controller
    {
        private readonly ITableWaiterService _tableWaiterService;

        public TableWaiterController(ITableWaiterService tableWaiterService)
        {
            _tableWaiterService = tableWaiterService;
        }

        [HttpGet]
        [Route("GetTableWaiter")]
        public async Task<TableWaiter> GetTableWaiter(int tableWaiterId)
        {
            return await _tableWaiterService.GetTableWaiter(tableWaiterId);
        }

        [HttpGet]
        [Route("AllTablesWaiters")]
        public async Task<List<TableWaiter>> AllTablesWaiters()
        {
            return await _tableWaiterService.GetAllTablesWaiters();
        }

        [HttpPost]
        [Route("AssignTablesToWaiters")]
        public async Task<bool> AssignTablesToWaiters(TableWaiterDto tableWaiter)
        {
            return await _tableWaiterService.AssignTablesToWaiters(tableWaiter);
        }

        [HttpPut]
        [Route("UpdateTableWaiter")]
        public async Task<bool> UpdateTableWaiter(TableWaiterDto tableWaiter)
        {
            return await _tableWaiterService.UpdateTableWaiter(tableWaiter);
        }

        [HttpDelete]
        [Route("DeleteTableWaiter")]
        public async Task<bool> DeleteTableWaiter(int tableWaiterId)
        {
            return await _tableWaiterService.DeleteTableWaiter(tableWaiterId);
        }
    }
}

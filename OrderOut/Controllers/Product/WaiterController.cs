using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.waiter;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaiterController : Controller
    {
        private readonly IWaiterService _waiterService;

        public WaiterController(IWaiterService waiterService)
        {
            _waiterService = waiterService;
        }

        [HttpGet]
        [Route("GetWaiter")]
        public Waiter GetWaiter(int waiterId)
        {
            return _waiterService.GetWaiter(waiterId);
        }

        [HttpGet]
        [Route("AllWaiters")]
        public List<Waiter> AllWaiters()
        {
            return _waiterService.GetAllWaiters();
        }

        [HttpPost]
        [Route("CreateWaiter")]
        public async Task<bool> CreateWaiter(Waiter waiter)
        {
            return await _waiterService.CreateWaiter(waiter);
        }

        [HttpPut]
        [Route("UpdateWaiter")]
        public async Task<bool> UpdateWaiter(Waiter waiter)
        {
            return await _waiterService.UpdateWaiter(waiter);
        }

        [HttpDelete]
        [Route("DeleteWaiter")]
        public async Task<bool> DeleteWaiter(int waiterId)
        {
            return await _waiterService.DeleteWaiter(waiterId);
        }
    }
}

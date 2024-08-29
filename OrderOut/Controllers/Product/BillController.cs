using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Services.order;
using OrderOut.Services.bill;
using OrderOut.DtosOU.Dtos;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : Controller
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        [Route("GetBillBy Id")]
        public async Task<Bill> GetBilById(long billId)
        {
            return await _billService.GetBill(billId);
        }

        [HttpGet]
        [Route("GetBills")]
        public async Task<List<Bill>> GetBills(DateTime startDate, DateTime endDate)
        {
            return await _billService.GetBills(startDate,endDate);
        }
        [HttpGet]
        [Route("GetStatistics")]
        public async Task<StatisticsDto> GetStatistics()
        {
            return await _billService.GetStatistics();
        }
        //[HttpPost]
        //[Route("CreateOrder")]
        //public async Task<Order> CreateOrder(NewOrderDto order)
        //{
        //    return await _billService.CreateBill(order);
        //}

        [HttpPut]
        [Route("UpdateBill")]
        public async Task<Bill> UpdateBill(Bill request)
        {
            return await _billService.UpdateBill(request);
        }

        [HttpPut]
        [Route("UpdateBillPaid")]
        public async Task<Bill> UpdateWayToPayBillPaid(int billId, bool isPaid, WayToPayEnum wayToPay)
        {
            return await _billService.UpdateBillPaid(billId, isPaid, wayToPay);
        }

        //[HttpDelete]
        //[Route("DeleteOrder")]
        //public async Task<bool> DeleteOrder(int orderId)
        //{
        //    return await _billService.DeleteOrder(orderId);
        //}

    }
}

using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Services.order;
using OrderOut.Services.bill;

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

        //[HttpGet]
        //[Route("GetBill")]
        //public async Task<Bill> GetBill(int billId)
        //{
        //    return await _billService.GetBill(billId);
        //}

        //[HttpGet]
        //[Route("AllBills")]
        //public async Task<List<Order>> AllBills()
        //{
        //    return await _billService.GetAllBills();
        //}

        //[HttpPost]
        //[Route("CreateOrder")]
        //public async Task<Order> CreateOrder(NewOrderDto order)
        //{
        //    return await _billService.CreateBill(order);
        //}

        //[HttpPut]
        //[Route("UpdateOrder")]
        //public async Task<bool> UpdateOrderStatus(BillStatusDto request)
        //{
        //    return await _billService.UpdateOrderStatus(request);
        //}
        //[HttpDelete]
        //[Route("DeleteOrder")]
        //public async Task<bool> DeleteOrder(int orderId)
        //{
        //    return await _billService.DeleteOrder(orderId);
        //}

    }
}

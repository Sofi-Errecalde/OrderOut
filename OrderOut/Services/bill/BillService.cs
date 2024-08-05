using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Repositorys;
using OrderOut.Repositorys.product;
namespace OrderOut.Services.bill
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BillService(IBillRepository billRepository, IProductRepository productRepository, AppDbContext context,
                            IMapper mapper)
        {
            _billRepository = billRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _context = context;
        }

        //public async Task<List<Bill>> GetAllBills()
        //{
        //    var bills = await _billRepository.GetAllBills();
        //    var response = _mapper.Map<List<Bill>>(bills);
        //    return response;
        //}

        public async Task<Bill> GetBill(long billId)
        {
            var response = await _billRepository.GetBill(billId);
            return response;
        }

        public async Task<Bill> CreateBill(CreateBillDto request)
        {   
            var newBill = _mapper.Map<Bill>(request);
            newBill.Date = DateTime.Now;
            var response = await _billRepository.CreateBill(newBill);

            return response;
        }

        public async Task<Bill> UpdateBill(Bill request)
        {
            request.Tip = request.Amount * (float)0.1;
            var response = await _billRepository.UpdateBill(request);
            return response;
        }

        //public async Task<bool> DeleteOrder(int orderId)
        //{
        //    var response = await _orderRepository.DeleteOrder(orderId);
        //    return response;
        //}

        //internal async Task updateStatus(int id, string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

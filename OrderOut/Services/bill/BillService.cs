using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.DtosOU;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;
using OrderOut.Enums;
using OrderOut.Repositorys;
using OrderOut.Repositorys.NewFolder;
using OrderOut.Repositorys.product;
namespace OrderOut.Services.bill
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;
        private readonly AppDbContext _context;
        private readonly OrderProductRepository _orderProductRepository;

        public BillService(IBillRepository billRepository, IProductRepository productRepository, AppDbContext context,
                            IMapper mapper, OrderProductRepository orderProductRepository, ITableRepository tableRepository)
        {
            _billRepository = billRepository;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
            _context = context;
            _tableRepository = tableRepository;
        }

        public async Task<Bill> GetBill(long billId)
        {
            var response = await _billRepository.GetBill(billId);
            return response;
        }

        public async Task<List<Bill>> GetBills(DateTime startDate, DateTime endDate)
        {
            var bills = await _billRepository.GetBills(startDate, endDate);
            return bills;
        }


        public async Task<StatisticsDto> GetStatistics(DateTime startDate, DateTime endDate)
        {
            var bills = await _billRepository.GetAll(startDate, endDate);

            // Inicializar el objeto para almacenar los indicadores
            var IndicatorsDto = new IndicatorsDto();

            // Calcular el ranking de métodos de pago
            var RankingWayToPayList = new List<RankingWayToPayDto>();
            for (int i = 1; i <= 4; i++)
            {
                var RankingWayToPay = new RankingWayToPayDto()
                {
                    WayToPay = (WayToPayEnum)i,
                    Amount = bills.Where(x => x.WayToPay == (int)(WayToPayEnum)i).Sum(x => x.Amount.HasValue ? x.Amount.Value : 0),
                    Quantity = bills.Count(x => x.WayToPay == (int)(WayToPayEnum)i)
                };
                RankingWayToPayList.Add(RankingWayToPay);
            }

            // Calcular los indicadores
            IndicatorsDto.TotalAmount = bills.Sum(x => x.Amount.HasValue ? x.Amount.Value : 0);
            var quantity = bills.Count();
            IndicatorsDto.AverageAmount = quantity > 0 ? IndicatorsDto.TotalAmount / quantity : 0;
            IndicatorsDto.TotalTip = bills.Sum(x => x.Tip.HasValue ? x.Tip.Value : 0);
            IndicatorsDto.rankingWayToPayDtos = RankingWayToPayList;


            var ordersTables = bills
                 .GroupBy(x => x.TableWaiter.Table)
                .Select(r => new RankingTableDto
                {
                    Id = r.Key.Id,
                    AmountPeople = r.Key.AmountPeople,
                    Quantity = r.Count()
                })
                .OrderByDescending(rp => rp.Quantity)
                .ToList();

            var ordersWaiters = bills
                 .GroupBy(x => x.TableWaiter.Waiter)
                .Select(r => new RankingWaiterDto
                {
                    Id = r.Key.Id,
                    Name = r.Key.Name,
                    AverageSpendingPerAccount = r.Average(bill => bill.Amount.Value),
                    AverageTipPerAccount = r.Average(bill => bill.Tip.Value),
                    QuantityBills = r.Count()
                })
                .OrderByDescending(rp => rp.QuantityBills)
                .ToList();

            var orderProducts = await _orderProductRepository.GetAll();
            var RankingProducts = orderProducts
                .GroupBy(op => op.Product)
                .Select(g => new RankingProductosDto
                {
                    Product = g.Key,
                    Quantity = g.Sum(op => op.Quantity)
                })
                .OrderByDescending(rp => rp.Quantity)
                .ToList();

            var StatisticsDto = new StatisticsDto
            {
                Indicators = IndicatorsDto,
                RankingProducts = RankingProducts
            };

            return StatisticsDto;
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

        public async Task<Bill> UpdateBillPaid(int billId, bool isPaid, WayToPayEnum wayToPay)
        {
            var bill = await _billRepository.GetBill(billId);
            bill.IsPaid = isPaid;
            bill.WayToPay = (int)wayToPay;
            var response = await _billRepository.UpdateBill(bill);
            bill.TableWaiter.Table.State = (int)TableState.Libre;
            var table = _tableRepository.UpdateTable(bill.TableWaiter.Table);
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

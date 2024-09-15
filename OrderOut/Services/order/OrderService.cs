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
using OrderOut.Services.bill;

namespace OrderOut.Services.order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITableWaiterRepository _tableWaiterRepository;
        private readonly IBillService _billService;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, 
            ITableWaiterRepository tableWaiterRepository, IBillService billService,
            ITableRepository tableRepository ,AppDbContext context, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _tableWaiterRepository = tableWaiterRepository;
            _billService = billService;
            _tableRepository = tableRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders =  await _orderRepository.GetAllOrders();
            var response = _mapper.Map<List<Order>>(orders);
            return response;
        }

        public async Task<List<Order>> GetAllOrdersForBill( int billId)
        {
            var orders = await _orderRepository.GetAllOrdersForBill(billId);
            var response = _mapper.Map<List<Order>>(orders);
            return response;
        }


        public async Task<Order> GetOrder(int orderId)
        {
            var order =  await _orderRepository.GetOrder(orderId);
            var response = _mapper.Map<Order>(order);
            return response;
        }
        public async Task<Order> CreateOrder(NewOrderDto request)
        {
            Bill bill;

            if (request.BillId == null)
            {
                var time = DateTime.Now.Hour;
                var newBill = new CreateBillDto();
                ShiftEnum shift;

                if (time < 12)
                {
                    shift = ShiftEnum.Mañana;
                }
                else if (time >= 12 && time < 19)
                {
                    shift = ShiftEnum.Tarde;
                }
                else
                {
                    shift = ShiftEnum.Noche;
                }

                // Esperar a que se obtenga el TableWaiter
                var tableWaiter = await _tableWaiterRepository.GetTableWaiterForBill((int)request.TableId, (int)shift);
                newBill.TableWaiterId = tableWaiter.Id;

                // Esperar a que se cree la nueva factura
                bill = await _billService.CreateBill(newBill);
                request.BillId = bill.Id;

                // Actualizar el estado de la mesa y esperar a que se complete
                tableWaiter.Table.State = (int)TableState.Ocupada;
                await _tableRepository.UpdateTable(tableWaiter.Table); // Asegúrate de que UpdateTableAsync es un método async
            }
            else
            {
                // Esperar a que se obtenga la factura existente
                bill = await _billService.GetBill(request.BillId.Value);
            }

            var newOrder = _mapper.Map<Order>(request);
            var orderProducts = new List<OrderProduct>();
            float amount = bill.Amount ?? 0; // Inicializar amount con el valor de bill.Amount o 0 si es null
            List<long> productsId = new List<long>();

            // Crear la lista de OrderProduct y recolectar los IDs de productos
            foreach (var product in request.OrdersProducts)
            {
                productsId.Add(product.ProductId);
                var addProduct = new OrderProduct
                {
                    ProductId = product.ProductId,
                    Clarification = product.Clarification,
                    Quantity = product.Quantity
                };
                orderProducts.Add(addProduct);

            }
            var products = await _productRepository.GetProductsByIds(productsId);
            var kitchenProductIds = products
                .Where(p => p.Category.Kitchen)
                .Select(p => p.Id)
                .ToList();

            var notKitchenProductIds = products
                .Where(p => !p.Category.Kitchen)
                .Select(p => p.Id)
                .ToList();

            // Filtrar los orderProducts según las listas de productos separadas
            var kitchenOrderProducts = orderProducts
                .Where(op => kitchenProductIds.Contains(op.ProductId))
                .ToList();

            var notKitchenOrderProducts = orderProducts
                .Where(op => notKitchenProductIds.Contains(op.ProductId))
                .ToList();

            Order response = new Order();
            if (kitchenOrderProducts.Any())
            {
                var kitchenOrder = new Order
                {
                    Requested = newOrder.Requested,
                    Status = newOrder.Status,
                    BillId = newOrder.BillId
                };
                response = await _orderRepository.CreateOrder(kitchenOrder, kitchenOrderProducts);
            }

            // Crear la orden para productos que no son de cocina
            if (notKitchenOrderProducts.Any())
            {
                var notKitchenOrder = new Order
                {
                    Requested = newOrder.Requested,
                    Status = newOrder.Status,
                    BillId = newOrder.BillId
                };
                response = await _orderRepository.CreateOrder(notKitchenOrder, notKitchenOrderProducts);
            }
            foreach (var product in products)
            {
                var orderProduct = orderProducts.FirstOrDefault(op => op.ProductId == product.Id);
                if (orderProduct != null)
                {
                    float add = product.Price * orderProduct.Quantity;
                    amount += add;
                }
            }

            // Actualizar el monto de la factura y esperar a que se complete
            bill.Amount = amount;
            var updateBill = await _billService.UpdateBill(bill);

            response.Bill = updateBill;

            return response;
        }


        public async Task<bool> UpdateOrderStatus(OrderStatusDto request)
        {
            var response = await _orderRepository.UpdateOrderStatus(request);
            return response;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var response = await _orderRepository.DeleteOrder(orderId);
            return response;
        }

        internal async Task updateStatus(int id, string v)
        {
            throw new NotImplementedException();
        }
    }
}

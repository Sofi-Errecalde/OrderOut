﻿using System.Collections.Generic;
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
                var tableWaiter = await _tableWaiterRepository.GetTableWaiterForBill((int)request.TableId,  ((int)shift));
                newBill.TableWaiterId = tableWaiter.Id;
                bill = await _billService.CreateBill(newBill);
                request.BillId = bill.Id;
                tableWaiter.Table.State = (int)TableState.Ocupada;
                var tableUpdate = _tableRepository.UpdateTable(tableWaiter.Table);
            }
            else
            {
                bill = await _billService.GetBill(request.BillId.Value);
            }

            var newOrder = _mapper.Map<Order>(request);
            var orderProducts = new List<OrderProduct>();
            float amount = 0;
            List<long> productsId = new List<long>();
            foreach (var product in request.OrdersProducts)
            {
                productsId.Add(product.ProductId);
                var addProduct= new OrderProduct();
                addProduct.ProductId = product.ProductId;
                addProduct.Clarification = product.Clarification;
                addProduct.Quantity = product.Quantity;
                orderProducts.Add(addProduct);

            }
            var kitchenProducts = orderProducts.Where(p => p.Product.Category.Kitchen == true).ToList();
            var notKitchenProducts = orderProducts.Where(p => p.Product.Category.Kitchen == false).ToList();
            var orderKitchen = newOrder.Products.Where(p => p.Product.Category.Kitchen == true).ToList();
            var orderNotKitchen = newOrder.Products.Where(p => p.Product.Category.Kitchen == false).ToList();
            Order response = new Order();
            if(kitchenProducts != null)
            {
                newOrder.Products = orderKitchen;
                response = await _orderRepository.CreateOrder(newOrder, kitchenProducts);
            }
            if(notKitchenProducts != null)
            {
                newOrder.Products = orderNotKitchen;
                response = await _orderRepository.CreateOrder(newOrder, notKitchenProducts);
            }
            var products = await _productRepository.GetProductsByIds(productsId);
            amount = bill.Amount == null?amount = 0:amount = bill.Amount.Value;
            foreach (var product in products)
            {
              foreach(var orderproduct in orderProducts)
              {
                    if(orderproduct.ProductId == product.Id)
                    {
                        float add = product.Price * orderproduct.Quantity;
                        amount = amount + add;
                        break;
                    }
              }
            }
            bill.Amount = amount;
            var updateBill = await _billService.UpdateBill(bill);

            response.Bill = updateBill;


            //if (response)
            //{
            //    foreach (var productId in request.OrdersProducts)
            //    {
            //        var orderProduct = new OrderProduct(newOrder,product);
            //        _context.OrderProducts.Add(orderProduct);
            //    }

            //    await _context.SaveChangesAsync();
            //}

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

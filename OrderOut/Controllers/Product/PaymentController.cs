﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

using MercadoPago.Client.Preference;
using OrderOut.Services.order;
using OrderOut.Services.user;
using static System.Net.WebRequestMethods;
using OrderOut.Enums;
using OrderOut.Services.bill;
using OrderOut.EF.Models;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly BillService _billService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public PaymentController(BillService billService, OrderService orderService, UserService userService)
        {
            _userService = userService;
            _billService = billService;
            _orderService = orderService;
            MercadoPagoConfig.AccessToken = "APP_USR-754556657198966-061718-54405e00f534ba1d9bc6d96985720195-1863527942";
        }

        [HttpPost("create-order/{id}")]
        public async Task<IActionResult> CreateBill(int id)
        {
            var bill = await _billService.GetBill(id);
            var ordersDetails = await _orderService.GetAllOrdersForBill((int)bill.Id);
            /* if (orderDetails == null || orderDetails.Status != OrderStatusEnum.Entregado)
             {
                 return BadRequest("Solo es posible pagar un pedido en estado Entregado");
             }*/
            var items = new List<PreferenceItemRequest>();
            foreach (var order in ordersDetails)
            {
                var orderItems = order.Products.Select(detail => new PreferenceItemRequest
                {
                    Id = detail.Id.ToString(),
                    UnitPrice = (decimal)detail.Product.Price,
                    CurrencyId = "ARS",
                    Quantity = detail.Quantity,
                    Title = $"Pedido Nro: {detail.OrderId}",
                    Description = $"Pedido Nro: {id}"
                }).ToList();
                items.AddRange(orderItems);
            }

            //var payer = await _userService.GetUser((int)orderDetails.UserId);
            var backUrls = new PreferenceBackUrlsRequest
            {
                Success = "https://www.google.com/",
                Pending = "https://www.youtube.com/",
                Failure = "https://www.youtube.com/"
            };

            var request = new PreferenceRequest
            {
                Items = items,
                Payer = new PreferencePayerRequest
                {
                    //Name = payer.Name,
                    Email = "test_user_984695644@testuser.com"
                },
                BackUrls = backUrls,
                AutoReturn = "approved",
                NotificationUrl = $"https://localhost:44369/api/payment/webhook/{id}",
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    Installments = 1
                }
            };

            try
            {
                var client = new PreferenceClient();
                var preference = await client.CreateAsync(request);
                return Ok(preference.InitPoint);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al procesar el pago");
            }
        }

        [HttpPost("webhook/{id}")]
        public async Task<IActionResult> ReceiveWebhook(int id, [FromQuery] dynamic payment)
        {
            if (payment?.type == "payment")
            {
                try
                {
                    var paymentClient = new MercadoPago.Client.Payment.PaymentClient();
                    var paymentInfo = await paymentClient.GetAsync(payment["data.id"]);
                    if (paymentInfo != null)
                    {
                        await _billService.UpdateBillPaid(id, true, WayToPayEnum.MercadoPago);
                        //await SavePaymentInfo(id, paymentInfo);
                        NotifyOrderPaid(id);
                        return NoContent();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Ocurrió un error al procesar el pago");
                }
            }
            return BadRequest();
        }

        private void NotifyOrderPaid(int id)
        {
            // Implementa la lógica para notificar que el pedido ha sido pagado
            throw new NotImplementedException();
        }
    }
}

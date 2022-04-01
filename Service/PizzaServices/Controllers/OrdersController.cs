﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Services.Interface;

namespace PizzaStoreManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet()]
        public IEnumerable<Order> GetAllOrders()
        {
            var orders = orderService.GetAllOrders();

            return orders;
        }

        [HttpGet()]
        public Order GetOrder(int orderId)
        {
            var order = orderService.GetOrder(orderId);

            return order;
        }

        [HttpPost("place-order")]
        public void PlaceOrder(PizzaOrder order)
        {
            orderService.PlaceOrder(order);
        }
    }
}

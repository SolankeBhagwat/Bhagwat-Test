using System.Collections.Generic;
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
        public IEnumerable<PizzaOrder> GetAllOrders()
        {
            var orders = orderService.GetAllOrders();

            return orders;
        }

        [HttpGet()]
        public PizzaOrder GetOrder(int orderId)
        {
            var order = orderService.GetOrder(orderId);

            return order;
        }

        [HttpPost("place-order")]
        public void PlaceOrder(PizzaOrder pizzaOrder)
        {
            orderService.PlaceOrder(pizzaOrder);
        }
    }
}

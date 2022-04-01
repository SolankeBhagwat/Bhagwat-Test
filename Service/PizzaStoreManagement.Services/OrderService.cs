using System;
using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Services.Interface;

namespace PizzaStoreManagement.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<PizzaOrder> GetAllOrders()
        {
            var orders = this.orderRepository.GetAllOrders();

            return orders;
        }

        public PizzaOrder GetOrder(int orderId)
        {
            return this.orderRepository.GetOrder(orderId);
        }

        public int PlaceOrder(PizzaOrder pizzaOrder)
        {
            orderRepository.PlaceOrder (pizzaOrder);

            return pizzaOrder.OrderId;
        }
    }
}

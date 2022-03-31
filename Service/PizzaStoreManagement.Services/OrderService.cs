using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Services.Interface;
using System;
using System.Collections.Generic;

namespace PizzaStoreManagement.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }


        public IEnumerable<Order> GetAllOrders()
        {
            var orders = this.orderRepository.GetAllOrders();

            return orders;
        }

        public Order GetOrder(int orderId)
        {
            return this.orderRepository.GetOrder(orderId);
        }

        public int PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;

            orderRepository.PlaceOrder(order);

            return order.OrderId;
        }



    }
}

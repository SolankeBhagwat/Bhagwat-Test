using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Repository.Context;
using PizzaStoreManagement.Repository.Interface;

namespace PizzaStoreManagement.Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaDbContext pizzaDbContext;

        public OrderRepository(PizzaDbContext pizzaDbContext)
        {
            this.pizzaDbContext = pizzaDbContext;
        }

        private List<PizzaOrder>
            orders =
                new List<PizzaOrder> {
                    new PizzaOrder {
                        Id = 1,
                        OrderId = 1
                    }
                };

        public PizzaOrder GetOrder(int orderId)
        {
            return orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IEnumerable<PizzaOrder> GetAllOrders()
        {
            return orders;
        }

        public void PlaceOrder(PizzaOrder pizzaOrder)
        {
            orders.Add (pizzaOrder);
        }
    }
}

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

        private List<Order>
            orders =
                new List<Order> {
                    new Order {
                        OrderId = 1,
                        Pizzas =
                            new List<PizzaOrder> {
                                new PizzaOrder {
                                    Id = 1,
                                    OrderId = 1,
                                    Size = Common.Entities.Enum.PizzaSize.Large
                                }
                            }
                    }
                };

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        public void PlaceOrder(Order order)
        {
            orders.Add (order);
        }
    }
}

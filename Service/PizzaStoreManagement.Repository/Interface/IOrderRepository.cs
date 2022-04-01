using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);

        IEnumerable<Order> GetAllOrders();

        void PlaceOrder(Order order);
    }
}

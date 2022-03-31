using PizzaStoreManagement.Common.Entities;
using System.Collections.Generic;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);
        IEnumerable<Order> GetAllOrders();
        void PlaceOrder(Order order);
    }
}

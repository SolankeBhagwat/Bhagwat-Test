using PizzaStoreManagement.Common.Entities;
using System.Collections.Generic;

namespace PizzaStoreManagement.Services.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        int PlaceOrder(Order order);
        Order GetOrder(int orderId);
    }
}
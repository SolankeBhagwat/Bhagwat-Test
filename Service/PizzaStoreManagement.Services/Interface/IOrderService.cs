using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Services.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();

        int PlaceOrder(Order order);

        Order GetOrder(int orderId);
    }
}

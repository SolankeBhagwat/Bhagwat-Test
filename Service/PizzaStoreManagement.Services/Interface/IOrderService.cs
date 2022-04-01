using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Services.Interface
{
    public interface IOrderService
    {
        IEnumerable<PizzaOrder> GetAllOrders();

        int PlaceOrder(PizzaOrder pizzaOrder);

        PizzaOrder GetOrder(int orderId);
    }
}

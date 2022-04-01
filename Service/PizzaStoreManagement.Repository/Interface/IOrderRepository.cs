using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IOrderRepository
    {
        PizzaOrder GetOrder(int orderId);

        IEnumerable<PizzaOrder> GetAllOrders();

        void PlaceOrder(PizzaOrder pizzaOrder);
    }
}

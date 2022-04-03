using PizzaStoreManagement.Common.Entities;
using System.Collections.Generic;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IPizzaRepository
    {
        Pizza GetPizza(int id);

        IEnumerable<Pizza> GetAllPizzas();
    }
}

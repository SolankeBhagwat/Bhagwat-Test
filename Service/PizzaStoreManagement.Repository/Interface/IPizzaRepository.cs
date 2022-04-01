using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetPizzas(string base1, string type);

        Pizza GetPizza(int id);
    }
}

using System.Collections.Generic;
using PizzaStoreManagement.Common.Entities;

namespace PizzaStoreManagement.Services.Interface
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetPizzas(string base1, string type);

        Pizza GetPizza(int id);
    }
}

using PizzaStoreManagement.Common.Entities;
using System.Collections.Generic;

namespace PizzaStoreManagement.Repository.Interface
{
    public interface IPizzaRepository
    {
        List<Pizza> GetPizzas(string base1, string type);
    }
}

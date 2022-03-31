using PizzaStoreManagement.Common.Entities;
using System.Collections.Generic;

namespace PizzaStoreManagement.Services.Interface
{
    public interface IPizzaService
    {
      IEnumerable<Pizza> GetPizzas(string base1,string type);
    }
}
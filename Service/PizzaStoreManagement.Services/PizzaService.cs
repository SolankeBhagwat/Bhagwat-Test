using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Services.Interface;

namespace PizzaStoreManagement.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        public IEnumerable<Pizza> GetPizzas(string base1, string type)
        {
            if (!String.IsNullOrEmpty(type))
            {
                return this.pizzaRepository.GetAllPizzas()
                    .Where(x =>
                        x.Base.ToLower() == base1.Trim('"').ToLower() &&
                        x.Type.ToLower() == type.Trim('"').ToLower());
            }

            return this.pizzaRepository.GetAllPizzas()
                .Where(x => x.Base.ToLower() == base1.Trim('"').ToLower());
        }

        public Pizza GetPizza(int id)
        {
            return pizzaRepository.GetPizza(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
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
            var pizzas = this.pizzaRepository.GetPizzas(base1, type);

            return pizzas;
        }

        public Pizza GetPizza(int id)
        {
            return pizzaRepository.GetPizza(id);
        }
    }
}

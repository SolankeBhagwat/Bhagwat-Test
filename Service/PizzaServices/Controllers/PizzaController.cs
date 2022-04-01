using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Services.Interface;

namespace PizzaStoreManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        [HttpGet("search-pizza")]
        public IEnumerable<Pizza>
        SearchPizza([FromQuery] string base1, string type)
        {
            return this.pizzaService.GetPizzas(base1, type);
        }

        [HttpGet("get-pizza")]
        public Pizza GetPizza([FromQuery] int id)
        {
            return this.pizzaService.GetPizza(id);
        }
    }
}

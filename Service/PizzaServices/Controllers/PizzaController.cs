using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Services.Interface;
using System.Collections.Generic;

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
                   [HttpGet("SearchPizza")]
                   public IEnumerable<Pizza> SearchPizza([FromQuery]string base1,string type){
                            return this.pizzaService.GetPizzas(base1,type);
                   }
    }
    
}
using DryIoc;
using Microsoft.AspNetCore.Hosting;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Repository.Repository;
using PizzaStoreManagement.Services;
using PizzaStoreManagement.Services.Interface;

namespace PizzaServices
{
    public  class CompositionRoot
    {
        private readonly IRegistrator registrator;
        public CompositionRoot(IRegistrator registrator,IWebHostEnvironment webHostEnvironment)
        {
            this.registrator = registrator;
            this.registrator.Register<IOrderService, OrderService>();
            this.registrator.Register<IOrderRepository, OrderRepository>();
            
            this.registrator.Register<IPizzaService, PizzaService>();
            
            this.registrator.Register<IPizzaRepository, PizzaRepository>();
        }

    }
}
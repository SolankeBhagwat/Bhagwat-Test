using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PizzaStoreManagement.Repository.Context;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Repository.Repository;
using PizzaStoreManagement.Services;
using PizzaStoreManagement.Services.Interface;

namespace PizzaServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string AllowCorsForPizzaria = "_AllowCorsForPizzaria";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(x =>
                    x
                        .AddPolicy(AllowCorsForPizzaria,
                        builder =>
                        {
                            builder
                                .SetIsOriginAllowed(_ => true)
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .AllowAnyHeader();
                        }));

            services.AddControllers();
            services
                .AddDbContext<PizzaDbContext>(options =>
                {
                });
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            //var serviceProvider = new Container(rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments)).WithDependencyInjectionAdapter(services)
            //    .ConfigureServiceProvider<CompositionRoot>();

            //return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors (AllowCorsForPizzaria);

            app.UseRouting();

            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}

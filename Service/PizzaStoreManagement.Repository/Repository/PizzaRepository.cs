using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using PizzaStoreManagement.Common.Entities;
using PizzaStoreManagement.Repository.Context;
using PizzaStoreManagement.Repository.Interface;

namespace PizzaStoreManagement.Repository.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaDbContext pizzaDbContext;

        private readonly IEnumerable<Pizza> Pizzas;

        public PizzaRepository(PizzaDbContext pizzaDbContext)
        {
            this.pizzaDbContext = pizzaDbContext;
            Pizzas =
                new List<Pizza>()
                {
                    new Pizza {
                        Id = 1,
                        Name = "Neapolitan Pizza",
                        Init = "v",
                        Image = "assets/1.png",
                        Price = 200,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 2,
                        Name = "Chicago Pizza",
                        Init = "v",
                        Image = "./assets/2.png",
                        Price = 300,
                        Base = "Multigrain ",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 3,
                        Name = "New York-Style Pizza",
                        Init = "n",
                        Image = "assets/3.png",
                        Price = 200,
                        Base = "Regular base",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 4,
                        Name = "Sicilian Pizza",
                        Init = "v",
                        Image = "assets/4.png",
                        Price = 300,
                        Base = "Flat bread",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 5,
                        Name = "Greek Pizza",
                        Init = "v",
                        Image = "assets/5.png",
                        Price = 200,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 6,
                        Name = "California Pizza",
                        Init = "n",
                        Image = "assets/6.png",
                        Price = 350,
                        Base = "Flat bread",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 7,
                        Name = "Detroit Pizza",
                        Init = "v",
                        Image = "assets/7.png",
                        Price = 150,
                        Base = "Thin crust",
                        Type = "No Cheese"
                    },
                    new Pizza {
                        Id = 8,
                        Name = "St. Louis Pizza",
                        Init = "n",
                        Image = "assets/8.png",
                        Price = 400,
                        Base = "Multigrain ",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 9,
                        Name = "Olive Garden",
                        Init = "v",
                        Image = "assets/1.png",
                        Price = 250,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 10,
                        Name = "Little Italy",
                        Init = "v",
                        Image = "assets/2.png",
                        Price = 200,
                        Base = "Flat bread",
                        Type = "Cheese Topping"
                    },
                    new Pizza {
                        Id = 11,
                        Name = "Neapolitan Pizza",
                        Init = "v",
                        Image = "assets/1.png",
                        Price = 200,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 12,
                        Name = "Chicago Pizza",
                        Init = "v",
                        Image = "./assets/2.png",
                        Price = 300,
                        Base = "Multigrain ",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 13,
                        Name = "New York-Style Pizza",
                        Init = "n",
                        Image = "assets/3.png",
                        Price = 400,
                        Base = "Regular base",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 14,
                        Name = "Sicilian Pizza",
                        Init = "v",
                        Image = "assets/4.png",
                        Price = 300,
                        Base = "Flat bread",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 15,
                        Name = "Greek Pizza",
                        Init = "n",
                        Image = "assets/5.png",
                        Price = 500,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 16,
                        Name = "California Pizza",
                        Init = "v",
                        Image = "assets/6.png",
                        Price = 350,
                        Base = "Flat bread",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 17,
                        Name = "Detroit Pizza",
                        Init = "v",
                        Image = "assets/7.png",
                        Price = 250,
                        Base = "Regular base",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 18,
                        Name = "St. Louis Pizza",
                        Init = "n",
                        Image = "assets/8.png",
                        Price = 400,
                        Base = "Multigrain ",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 19,
                        Name = "Olive Garden",
                        Init = "v",
                        Image = "assets/1.png",
                        Price = 250,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    },
                    new Pizza {
                        Id = 20,
                        Name = "Little Italy",
                        Init = "v",
                        Image = "assets/2.png",
                        Price = 600,
                        Base = "Multigrain ",
                        Type = "Cheese Topping"
                    }
                };
        }

        public IEnumerable<Pizza> GetPizzas(string base1, string type)
        {
            if (!String.IsNullOrEmpty(type))
            {
                return Pizzas
                    .Where(x =>
                        x.Base.ToLower() == base1.Trim('"').ToLower() &&
                        x.Type.ToLower() == type.Trim('"').ToLower());
            }
            return Pizzas
                .Where(x => x.Base.ToLower() == base1.Trim('"').ToLower());
        }

        public Pizza GetPizza(int id)
        {
            return Pizzas.FirstOrDefault(x => x.Id == id);
        }
    }
}

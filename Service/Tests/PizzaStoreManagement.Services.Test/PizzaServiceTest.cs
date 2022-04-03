using System.Reflection.Metadata.Ecma335;
using System.Xml.Xsl;
using System;
using Xunit;
using NSubstitute;
using PizzaStoreManagement.Repository.Interface;
using PizzaStoreManagement.Services;
using System.Collections.Generic;

using PizzaStoreManagement.Common.Entities;
using System.Linq;
using PizzaStoreManagement.Services.Test.Helper;

namespace PizzaStoreManagement.Services.Test
{
    public class PizzaServiceTest
    {
        private readonly IPizzaRepository pizzaRepository;
        private readonly PizzaService pizzaService;

        public PizzaServiceTest()
        {
            pizzaRepository = Substitute.For<IPizzaRepository>();
            pizzaService = new PizzaService(pizzaRepository);
        }

        [Fact]
        public void WhenUserSearchForBasePizzaWithAddOnsType_ThenItShouldReturnBasePizzasWithAddOns()
        {
            //Arrange
            List<Pizza> pizzas = GetPizzas();
            this.pizzaRepository.GetAllPizzas().Returns(pizzas);
            
            //Act
            var basePizza = "Thin crust";
            var type = "Cheese burst";
            var actualResult=pizzaService.GetPizzas(basePizza, type);
            
            //Assert
            var expectedResult=new List<Pizza> { new Pizza {
                        Id = 1,
                        Name = "Neapolitan Pizza",
                        Init = "v",
                        Image = "assets/1.png",
                        Price = 200,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    }, new Pizza {
                        Id = 5,
                        Name = "Greek Pizza",
                        Init = "v",
                        Image = "assets/5.png",
                        Price = 200,
                        Base = "Thin crust",
                        Type = "Cheese burst"
                    }};

            Assert.True(CollectionMatcher<Pizza>.Match(actualResult, expectedResult));
        }

        [Fact]
        public void WhenUserSearchForBasePizzaOnly_ThenItShouldReturnBasePizzas()
        {
            //Arrange
            List<Pizza> pizzas = GetPizzas();
            this.pizzaRepository.GetAllPizzas().Returns(pizzas);

            //Act
            var basePizza = "Regular base";
            var type = string.Empty;
            var actualResult = pizzaService.GetPizzas(basePizza, type);

            //Assert
            var expectedResult = new List<Pizza> {  new Pizza {
                        Id = 3,
                        Name = "New York-Style Pizza",
                        Init = "n",
                        Image = "assets/3.png",
                        Price = 200,
                        Base = "Regular base",
                        Type = "Cheese burst"
                    }};

            Assert.True(CollectionMatcher<Pizza>.Match(actualResult, expectedResult));
        }

        private List<Pizza> GetPizzas()
        {
            return new List<Pizza>
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
                    }
                };
        }

    }
}

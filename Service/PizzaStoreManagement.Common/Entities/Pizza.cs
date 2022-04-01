using System;
using System.Collections.Generic;
using System.Text;
using PizzaStoreManagement.Common.Entities.Enum;
using System.Linq;
namespace PizzaStoreManagement.Common.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Init { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public string Base { get; set; }

        public int SelectedPizzaCount { get; set; }


        public PizzaSize Size { get; set; }

        public List<Topping> Toppings { get; set; }

        public decimal GetTotalPrice()
        {
            return this.Price + Toppings.Sum(x => x.Price);
        }
    }
}

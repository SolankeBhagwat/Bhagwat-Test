using PizzaStoreManagement.Common.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStoreManagement.Common.Entities
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Pizza PizzaBase { get; set; }
        public int SelectedPizzaCount{get;set;}
        public PizzaSize Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public decimal GetBasePrice()
        {
            return PizzaBase.Price;
        }

        public decimal GetTotalPrice()
        {
            return GetBasePrice() + Toppings.Sum(x=> x.Price);
        }
    }
}

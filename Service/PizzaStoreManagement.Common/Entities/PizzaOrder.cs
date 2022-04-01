using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStoreManagement.Common.Entities.Enum;

namespace PizzaStoreManagement.Common.Entities
{
    public class PizzaOrder
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public Address DeliveryAddress { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}

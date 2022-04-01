// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace PizzaStoreManagement.Common.Entities
// {
//     public class Order
//     {
//         public int OrderId { get; set; }

//         public string UserId { get; set; }

//         public DateTime CreatedTime { get; set; }

//         public Address DeliveryAddress { get; set; }

//         public List<PizzaOrder> Pizzas { get; set; }

//         public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
//     }
// }

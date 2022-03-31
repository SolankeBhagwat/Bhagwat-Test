using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreManagement.Common.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Init{get;set;}
        public string Type {get;set;}
        public string Image{get;set;}
        public string Base {get;set;}
    }
}

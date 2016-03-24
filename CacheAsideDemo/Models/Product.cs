using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheAsideDemo.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
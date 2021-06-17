using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string ShopCartId { get; set; }
    }
}

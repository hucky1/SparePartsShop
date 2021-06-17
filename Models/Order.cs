using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class Order
    {
        //[BindNever]
        public int Id { get; set; }
        public Client Client { get; set; }

        public DateTime OrderTime { get; set; }

        public virtual List<OrderItem> Products { get; set; }

    }
}

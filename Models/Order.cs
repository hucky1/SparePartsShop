﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class Order
    {
        //[BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public Client Client { get; set; }

        public DateTime OrderTime { get; set; }

        public virtual List<OrderItem> Products { get; set; }

        public Order()
        {
            Id = -1;
            OrderTime = DateTime.Now;
            Products = new List<OrderItem>();
        }
    }
}

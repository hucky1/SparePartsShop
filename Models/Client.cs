using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  SurName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumner { get; set; }
        public string Email { get; set; }
        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}

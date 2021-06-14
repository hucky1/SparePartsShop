using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SparePartsShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Model { get; set; }
        public string CarBody { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string ProductionYear { get; set; }
        public string Img { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int Cost { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
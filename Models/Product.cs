using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SparePartsShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Марка")]

        public Brand Brand { get; set; }
        [Display(Name = "Категория")]

        public Category Category { get; set; }
        [Display(Name = "Цена")]
        public int Cost { get; set; }
        [Display(Name = "Объём двигателя")]
        public double EngineCapacity { get; set; }
        [Display(Name = "Топливо")]
        public Fuel FuelType { get; set; }
        [Display(Name = "Путь к картинке")]
        public string Img { get; set; }
        [Display(Name = "Год производства")]
        public string ProductionYear { get; set; }
        [Display(Name = "Nип кузова")]
        public string CarBody { get; set; }








        //public virtual List<OrderDetails> OrderDetails { get; set; }

        //public Product(int id, string model, string carBody, string fuelType, string engineCapacity, string productionYear, string img, int brandId, int cost, int categoryId)
        //{
        //    Id = id;
        //    Model = model;
        //    CarBody = carBody;
        //    FuelType = fuelType;
        //    EngineCapacity = engineCapacity;
        //    ProductionYear = productionYear;
        //    Img = img;
        //    BrandId = brandId;
        //    Cost = cost;
        //    CategoryId = categoryId;
        //}
    }
}
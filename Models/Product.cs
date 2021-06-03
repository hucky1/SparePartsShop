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
        public Brand Brand { get; set; }
        public int Cost { get; set; }
        public Category Category { get; set; }
    }
}
namespace PosData.Api.Models
{
    public class Motorcycle : IProduct
    {
        public string Model { get; set; }
        public Brand Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string EngineType { get; set; }
        public string EnginePower { get; set; }
        public string FuelType { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}

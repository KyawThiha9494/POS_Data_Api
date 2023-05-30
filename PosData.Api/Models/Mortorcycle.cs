namespace PosData.Api.Models
{
    public class Mortorcycle : Product
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string EngineType { get; set; }
        public string EnginePower { get; set; }
        public string FuelType { get; set; }
        
    }
}

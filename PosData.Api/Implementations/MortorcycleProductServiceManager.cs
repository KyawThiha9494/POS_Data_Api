using PosData.Api.Interfaces;
using PosData.Api.Models;

namespace PosData.Api.Implementations
{
    public class MortorcycleProductServiceManager : IProductService<Mortorcycle>
    {
        public List<Mortorcycle> GetAllProducts()
        {
            List<Mortorcycle> mortorcycleList = new List<Mortorcycle>() {
                new Mortorcycle{
                    Name = "125",
                    Price= 4000000,
                    Brand= "Honda",
                    Year = 2023
                },
                new Mortorcycle
                {
                    Name = "Click",
                    Price = 5000000,
                    Brand = "Honda",
                    Year = 2023
                }

            };
            return mortorcycleList;
        }

        public Mortorcycle GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Mortorcycle GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Mortorcycle> SearchProducts()
        {
            throw new NotImplementedException();
        }
    }
}

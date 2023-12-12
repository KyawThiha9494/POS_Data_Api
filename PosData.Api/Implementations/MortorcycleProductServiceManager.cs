using PosData.Api.Interfaces;
using PosData.Api.Models;

namespace PosData.Api.Implementations
{
    public class MortorcycleProductServiceManager : IProductService<IProduct>
    {
        List<Brand> brandList = new List<Brand>() { 
            new Brand(){ 
                Name = "Honda",
                Description = "Thai Brand"
            },
            new Brand()
            {
                Name = "Yamaha",
                Description = "Japan"
            },
            new Brand()
            {
                Name = "Moto Guzzi",
                Description = "Italian"
            },
            new Brand()
            {
                Name = "BMW R 18",
                Description = "BMW"
            }
        };

        public List<Brand> GetAllBrands()
        {
            return brandList;
        }

        public List<IProduct> GetAllProducts()
        {
            List<IProduct> mortorcycleList = new List<IProduct>() {
                new Motorcycle{
                    Name = "125",
                    Price= 4000000,
                    Brand= brandList[1],
                    Year = 2023,
                    Color="Black"
                },
                new Motorcycle
                {
                    Name = "Click",
                    Price = 5000000,
                    Brand = brandList[2],
                    Year = 2023
                }

            };
            return mortorcycleList;
        }

        public IProduct GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IProduct GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<IProduct> SearchProducts()
        {
            throw new NotImplementedException();
        }
    }
}

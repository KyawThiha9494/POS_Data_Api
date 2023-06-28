using PosData.Api.Models;

namespace PosData.Api.Interfaces
{
    public interface IProductService<T>
    {
        List<T> GetAllProducts();
        T GetProductById(int id);
        T GetProductByName(string name);
        List<T> SearchProducts();
        List<Brand> GetAllBrands();
    }
}

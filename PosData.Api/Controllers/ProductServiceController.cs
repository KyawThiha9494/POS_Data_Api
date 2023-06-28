using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PosData.Api.Enums;
using PosData.Api.Implementations;
using PosData.Api.Interfaces;
using PosData.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService<IProduct> _productServiceManager;

        public ProductServiceController(IConfiguration configuration, IProductService<IProduct> productServiceManager)
        {
            _configuration = configuration;
            _productServiceManager = productServiceManager;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            List<IProduct> products = new List<IProduct>();
            string productTypeName = _configuration["AppSettings:ModelType"];
            if (productTypeName.ToUpper() == ProductTypes.MOTORCYCLE.ToString())
            {
                Motorcycle motorcycle = new Motorcycle()
                {
                    Name = "125",
                    Brand = new Brand() { 
                        Name = "Honda",
                        Description = "Thai"
                    },
                    Year = 2023,
                    Color = "Black",
                    Price = 2000000
                };
                products.Add(motorcycle);
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IProduct>> GetProducts()
        {
            List<IProduct> products = _productServiceManager.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<ActionResult<Brand>> GetAllBrands()
        {
            List<Brand> brands = _productServiceManager.GetAllBrands();
            return Ok(brands);
        }
    }
}

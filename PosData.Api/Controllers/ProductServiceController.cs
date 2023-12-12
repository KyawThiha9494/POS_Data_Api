using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
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
            List<Motorcycle> products = new List<Motorcycle>();
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

        [HttpPost]
        [Route("CheckOutItems")]
        public IActionResult CheckOutItems([FromBody] OrderItem[] orderItems)
        {
            if (orderItems == null || !orderItems.Any())
            {
                return BadRequest("No items found for checkout.");
            }
            bool orderProcessedSuccessfully = true;

            if (orderProcessedSuccessfully)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, "Error occurred while processing the order.");
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PosData.Api.Enums;
using PosData.Api.Interfaces;
using PosData.Api.Models;

namespace PosData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            
            string productTypeName = _configuration["AppSettings:ModelType"];
            if (productTypeName.ToUpper() == ProductTypes.MOTORCYCLE.ToString())
            {
                List<Mortorcycle> mortorcycles = new List<Mortorcycle>();
                Mortorcycle mortorcycle = new Mortorcycle()
                {
                    Name = "125",
                    Brand = "Honda",
                    Year = 2023,
                    Color = "Black"
                };
                mortorcycles.Add(mortorcycle);
                return Ok(mortorcycles);
            }
            else {
                return null;
            }
            
        }
    }
}

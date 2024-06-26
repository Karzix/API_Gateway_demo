using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Product.Controllers
{
    [Route("product-api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetFirst()
        {
            Random random = new Random();
            int minValue = 100;
            int maxValue = 1000;
            int randomNumber = random.Next(minValue, maxValue);
            await Task.Delay(randomNumber);
            return Ok("product service - first");
        }
    }
}

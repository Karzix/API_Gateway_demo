using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Product.Model;
using WebAPI.Product.Service;

namespace WebAPI.Product.Controllers
{
    [Route("product-api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> _logger;
        private IProductService productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
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
        [HttpPost]
        public IActionResult Post(ProductModel request)
        {
            productService.Add(request);
            return Ok();
        }
    }
}

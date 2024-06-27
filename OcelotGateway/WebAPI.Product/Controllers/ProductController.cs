using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
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
        private readonly IConnectionMultiplexer _redis;
        public ProductController(ILogger<ProductController> logger, IProductService productService, IConnectionMultiplexer redis)
        {
            _logger = logger;
            this.productService = productService;
            _redis = redis;
        }
        [HttpGet]
        public async Task<IActionResult> GetFirst()
        {
            Random random = new Random();
            int minValue = 100;
            int maxValue = 1000;
            int randomNumber = random.Next(minValue, maxValue);
            await Task.Delay(randomNumber);
            var db = _redis.GetDatabase();
            var value = await db.StringGetAsync("products");

            if (value.IsNullOrEmpty)
            {
                var lstProduct = productService.GetAll();
                await db.StringSetAsync("products", JsonSerializer.Serialize(lstProduct));
                value = await db.StringGetAsync("products");
            }

            return Ok(value.ToString());
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductModel request)
        {
           
            var pd = productService.Add(request);

            var db = _redis.GetDatabase();
            await db.StringSetAsync("products", JsonSerializer.Serialize(pd));

            return Ok();
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Cart.Controllers
{
    [Route("/cart-api/[controller]")]
    [ApiController]
    public class cartController : ControllerBase
    {
        private ILogger<cartController> logger;
        public cartController(ILogger<cartController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetFirst()
        {
            Random random = new Random();
            int minValue = 100;
            int maxValue = 1000;
            int randomNumber = random.Next(minValue, maxValue);
            await Task.Delay(randomNumber);
            return Ok("cart service - first");
        }
    }
}

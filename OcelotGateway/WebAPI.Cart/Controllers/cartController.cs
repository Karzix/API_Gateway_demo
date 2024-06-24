using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Cart.Controllers
{
    [Route("~/cart-api/[controller]")]
    [ApiController]
    public class cartController : ControllerBase
    {
        private ILogger<cartController> logger;
        public cartController(ILogger<cartController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult GetFirst()
        {
            return Ok("cart service - first");
        }
    }
}

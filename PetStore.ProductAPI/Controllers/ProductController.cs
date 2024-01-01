using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetStore.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "client")]
        public IActionResult Index([FromBody] string code)
        {
            return Ok(code);
        }
    }
}

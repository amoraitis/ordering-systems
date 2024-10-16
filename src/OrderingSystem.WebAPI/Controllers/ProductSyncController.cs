using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/products/sync")]
    public class ProductSyncController : ControllerBase
    {
        [HttpPost(@"")]
        public IActionResult Sync()
        {
            throw new NotImplementedException();
        }
    }
}

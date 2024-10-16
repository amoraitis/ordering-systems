using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        [HttpPost(@"generate/{orderId}")]
        public IActionResult Generate(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
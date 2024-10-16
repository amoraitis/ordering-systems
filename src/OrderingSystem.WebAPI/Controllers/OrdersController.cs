using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpGet(@"{orderId")]
        public IActionResult GetBy(int orderId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost(@"{orderId}/cancel")]
        public IActionResult Cancel(int orderId)
        {
            throw new NotImplementedException();
        }

        [HttpPost(@"{orderId}/pay")]
        public IActionResult Pay(int orderId)
        {
            throw new NotImplementedException();
        }

        [HttpPut(@"{orderId}")]
        public IActionResult Update(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}

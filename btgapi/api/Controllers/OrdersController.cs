// BTG.Api/Controllers/OrdersController.cs
using Microsoft.AspNetCore.Mvc;
using BTG.Application.Interfaces;

namespace BTG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(long id)
        {
            var order = await _orderService.GetOrderAsync(id);
            return order != null ? Ok(order) : NotFound();
        }
    }
}

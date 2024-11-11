// BTG.Api/Controllers/CustomersController.cs
using Microsoft.AspNetCore.Mvc;
using BTG.Application.Interfaces;

namespace BTG.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int id)
        {
            var result = await _customerService.GetCustomerOrdersAsync(id);
            return Ok(result);
        }
    }
}

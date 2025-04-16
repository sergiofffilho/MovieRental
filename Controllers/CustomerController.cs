using Microsoft.AspNetCore.Mvc;
using MovieRental.Customer;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFeatures _features;

        public CustomerController(ICustomerFeatures features)
        {
            _features = features;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer.Customer customer)
        {
            var created = await _features.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _features.GetById(id);
            return customer == null ? NotFound() : Ok(customer);
        }
    }
}
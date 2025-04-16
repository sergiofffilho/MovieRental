using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rental.Rental rental)
        {
            var result = await _features.Save(rental);
	        return Ok(result);
        }

        [HttpGet("by-customerName")]
        public async Task<IActionResult> GetByCustomerName([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return BadRequest("Customer name is required.");

            var rentals = await _features.GetRentalsByCustomerName(customerName);

            if (!rentals.Any())
                return NotFound("No rentals found for this customer.");

            return Ok(rentals);
        }
	}
}

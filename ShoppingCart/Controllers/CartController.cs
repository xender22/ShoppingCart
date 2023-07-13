using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        
        [HttpPost]
        public IActionResult Post(string items)
        {
            try
            {
                var result = _cartService.CalculateItemsPrice(items);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                // Catch specific exception for invalid item ID
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // Catch any other general exception
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}

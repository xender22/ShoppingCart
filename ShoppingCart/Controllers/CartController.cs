using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Repositories;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public CartController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        [HttpPost]
        public IActionResult Post(string items)
        {
            try
            {
                var result = _itemRepository.CalculateItemsPrice(items);
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

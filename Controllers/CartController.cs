using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using QuitQ.API.Models;
using QuitQ.API.Services;
using QuitQ_Ecomm.DTOS;

namespace QuitQ.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IEnumerable<CartItem>> GetUserCart()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return await _cartService.GetUserCart(userId);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDto cartItemDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _cartService.AddToCart(userId, cartItemDto);
            return Ok(new { message = "Item added to cart" });
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await _cartService.RemoveFromCart(id);
            return Ok(new { message = "Item removed from cart" });
        }
    }
}

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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetUserOrders()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return await _orderService.GetUserOrders(userId);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _orderService.PlaceOrder(userId, orderDto);
            return Ok(new { message = "Order placed successfully" });
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            await _orderService.UpdateOrderStatus(orderId, status);
            return Ok(new { message = "Order status updated successfully" });
        }
    }
}

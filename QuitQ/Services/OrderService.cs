using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;
using QuitQ.API.Repositories;
using QuitQ_Ecomm.DTOS;

namespace QuitQ.API.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetUserOrders(int userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task PlaceOrder(int userId, OrderDto orderDto)
        {
            var order = new Order
            {
                UserId = userId,
                ProductIds = orderDto.ProductIds,
                TotalPrice = orderDto.TotalPrice,
                Status = "Pending"
            };

            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, status);
        }
    }
}

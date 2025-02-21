using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;

namespace QuitQ.API.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}

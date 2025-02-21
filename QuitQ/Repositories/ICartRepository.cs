using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;

namespace QuitQ.API.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetUserCartAsync(int userId);
        Task AddToCartAsync(CartItem cartItem);
        Task UpdateCartAsync(CartItem cartItem);
        Task RemoveFromCartAsync(int cartItemId);
        Task ClearCartAsync(int userId);
    }
}

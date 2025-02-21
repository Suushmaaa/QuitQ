using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuitQ.API.Models;

namespace QuitQ.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly QuitQDbContext _context;

        public CartRepository(QuitQDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetUserCartAsync(int userId)
        {
            return await _context.CartItems.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(int userId)
        {
            var cartItems = _context.CartItems.Where(c => c.UserId == userId);
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}

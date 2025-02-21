using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;
using QuitQ.API.Repositories;
using QuitQ_Ecomm.DTOS;

namespace QuitQ.API.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<CartItem>> GetUserCart(int userId)
        {
            return await _cartRepository.GetUserCartAsync(userId);
        }

        public async Task AddToCart(int userId, CartItemDto cartItemDto)
        {
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity
            };

            await _cartRepository.AddToCartAsync(cartItem);
        }

        public async Task UpdateCart(int userId, CartItemDto cartItemDto)
        {
            var existingCartItem = await _cartRepository.GetUserCartAsync(userId);
            var itemToUpdate = existingCartItem.FirstOrDefault(i => i.ProductId == cartItemDto.ProductId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = cartItemDto.Quantity;
                await _cartRepository.UpdateCartAsync(itemToUpdate);
            }
        }

        public async Task RemoveFromCart(int cartItemId)
        {
            await _cartRepository.RemoveFromCartAsync(cartItemId);
        }

        public async Task ClearCart(int userId)
        {
            await _cartRepository.ClearCartAsync(userId);
        }
    }
}

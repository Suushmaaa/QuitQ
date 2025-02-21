using Microsoft.EntityFrameworkCore;
namespace QuitQ_Ecomm.DTOS
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

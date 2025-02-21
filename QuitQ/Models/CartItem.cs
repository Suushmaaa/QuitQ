﻿using System.ComponentModel.DataAnnotations;

namespace QuitQ.API.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

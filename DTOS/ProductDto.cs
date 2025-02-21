﻿using Microsoft.EntityFrameworkCore;
namespace QuitQ_Ecomm.DTOS
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public required string Category { get; set; }
        public required string ImageUrl { get; set; }
    }
}

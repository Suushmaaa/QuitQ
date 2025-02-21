using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;
using QuitQ.API.Services;
using System.Security.Claims;
using QuitQ_Ecomm.DTOS;

namespace QuitQ.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return product;
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            var sellerId = int.Parse(s: User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _productService.AddProduct(productDto, sellerId);
            return Ok(new { message = "Product added successfully" });
        }

        [Authorize(Roles = "Seller")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            await _productService.UpdateProduct(id, productDto);
            return Ok(new { message = "Product updated successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}

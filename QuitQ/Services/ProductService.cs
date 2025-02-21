using System.Collections.Generic;
using System.Threading.Tasks;
using QuitQ.API.Models;
using QuitQ.API.Repositories;
using QuitQ_Ecomm.DTOS;

namespace QuitQ.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProduct(ProductDto productDto, int sellerId)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Category = productDto.Category,
                ImageUrl = productDto.ImageUrl,
                SellerId = sellerId
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct != null)
            {
                existingProduct.Name = productDto.Name;
                existingProduct.Description = productDto.Description;
                existingProduct.Price = productDto.Price;
                existingProduct.Stock = productDto.Stock;
                existingProduct.Category = productDto.Category;
                existingProduct.ImageUrl = productDto.ImageUrl;

                await _productRepository.UpdateAsync(existingProduct);
            }
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}

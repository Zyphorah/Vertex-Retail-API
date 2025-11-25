
using _521.tpfinal.api.models.Dtos.Product;
using _521.tpfinal.api.Repository.Product.Interfaces;

namespace _521.tpfinal.api.Services.Product
{
    public class ProductService(IProductsRepository productRepository) : Interfaces.IProductService
    {
        private readonly IProductsRepository _productRepository = productRepository;

        public Task Add(ProductDto product)
        {
            return this._productRepository.Add(new models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock,
                CartItems = []
            });
        }

        public Task<bool> Delete(ProductDto product)
        {
            return this._productRepository.Delete(new models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock,
                CartItems = []
            });
        }

        public Task<List<ProductDto>> GetAll()
        {
            return Task.FromResult(this._productRepository.GetAll().Result.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock
            }).ToList());
        }

        public Task<ProductDto?> GetById(Guid id)
        {
            return Task.FromResult(this._productRepository.GetById(id).Result is models.Product product ? new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock
            } : null);
        }

        public Task Update(ProductDto product)
        {
            return this._productRepository.Update(new models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock,
                CartItems = []
            });
        }
    }
}
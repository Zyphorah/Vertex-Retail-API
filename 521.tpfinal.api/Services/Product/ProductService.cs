
using _521.tpfinal.api.models.Dtos.Product;
using _521.tpfinal.api.Repository.Product.Interfaces;
using _521.tpfinal.api.models;

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
                CartItems = new List<models.CartItem>()
            });
        }

        public Task<bool> Delete(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
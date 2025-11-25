using _521.tpfinal.api.models.Dtos.Product;

namespace _521.tpfinal.api.Services.Product.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll();
        public Task<ProductDto?> GetById(Guid id);
        public Task Add(ProductDto product);
        public Task Update(ProductDto product);
        public Task<bool> Delete(ProductDto product);
    }
}
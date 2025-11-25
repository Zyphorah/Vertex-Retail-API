using ProductModel = _521.tpfinal.api.models.Product;

namespace _521.tpfinal.api.Repository.Product.Interfaces
{
    public interface IProductsRepository
    {
        public Task<List<ProductModel>> GetAll();
        public Task<ProductModel?> GetById(Guid id);
        public Task Add(ProductModel product);
        public Task Update(ProductModel product);
        public Task<bool> Delete(ProductModel product);
    }
}
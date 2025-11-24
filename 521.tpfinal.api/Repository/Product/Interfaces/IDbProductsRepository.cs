using _521.tpfinal.api.models;

namespace _521.tpfinal.api.Repository.Product.Interfaces
{
    public interface IDbProductsRepository
    {
        public Task<List<models.Product>> GetAll();
        public Task<models.Product?> GetById(Guid id);
        public Task Add(models.Product product);
        public Task Update(models.Product product);
        public Task<bool> Delete(models.Product product);
    }
}
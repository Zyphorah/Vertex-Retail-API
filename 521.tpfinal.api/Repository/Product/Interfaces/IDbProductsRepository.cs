public interface IDbProductsRepository
{
    public Task<List<Product>> GetAll();
    public Task<Product?> GetById(Guid id);
    public Task<List<Product>> GetByCategory(string category);
    public Task Add(Product product);
    public Task Update(Product product);
    public Task<bool> Delete(Product product);
}
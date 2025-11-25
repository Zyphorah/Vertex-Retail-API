namespace _521.tpfinal.web.Services.Product.Interfaces
{
    public interface IProductsService
    {
        Task<List<Models.Product>> GetAllAsync();
        Task<Models.Product> GetByIdAsync(Guid id);
        Task<(bool success, string message)> AddAsync(Models.Product product, string token);
        Task<(bool success, string message)> UpdateAsync(Guid id, Models.Product product, string token);
        Task<(bool success, string message)> DeleteAsync(Guid id, string token);
    }
}

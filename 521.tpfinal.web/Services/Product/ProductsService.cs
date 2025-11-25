
namespace _521.tpfinal.web.Services.Product
{
    public class ProductsService : Interfaces.IProductsService
    {
        public Task<(bool success, string message)> AddAsync(Models.Product product, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> DeleteAsync(Guid id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> UpdateAsync(Guid id, Models.Product product, string token)
        {
            throw new NotImplementedException();
        }
    }
}

using _521.tpfinal.api.models.Dtos.Product;

namespace _521.tpfinal.api.Services.Product
{
    public class ProductService : Interfaces.IProductService
    {
        public Task Add(ProductDto product)
        {
            throw new NotImplementedException();
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
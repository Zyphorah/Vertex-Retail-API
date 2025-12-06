using _521.tpfinal.api.models;
using _521.tpfinal.api.Repository.Product.Interfaces;
using ProductModel = _521.tpfinal.api.models.Product;

namespace _521.tpfinal.api.Repository.Product
{
    public class DbProductsRepository(AppDbContext context) : IProductsRepository
    {
        private readonly AppDbContext _context = context;

        public Task Add(ProductModel product)
        {   
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                throw new Exception($"Produit avec l'ID {product.Id} existe déjà");
            }
            this._context.Products.Add(product);
            return this._context.SaveChangesAsync();
        }

        public Task<bool> Delete(ProductModel product)
        {
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id) ?? throw new Exception($"Produit avec l'ID {product.Id} non trouvé");
            this._context.Products.Remove(existingProduct);
            return Task.FromResult(this._context.SaveChanges() > 0);
        }

        public Task<List<ProductModel>> GetAll()
        {
            if (this._context.Products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }

            return Task.FromResult(this._context.Products.ToList());
        }

        public Task<ProductModel?> GetById(Guid id)
        {
            if (this._context.Products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }

            return Task.FromResult(this._context.Products.FirstOrDefault(p => p.Id == id));
        }

        public Task Update(ProductModel product)
        {
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id) ?? throw new Exception($"Produit avec l'ID {product.Id} non trouvé");
            
            // Mettre à jour les propriétés de l'entité existante au lieu d'attacher une nouvelle
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Stock = product.Stock;
            
            return this._context.SaveChangesAsync();
        }
    }
}
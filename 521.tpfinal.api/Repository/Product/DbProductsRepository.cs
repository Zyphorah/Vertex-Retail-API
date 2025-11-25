namespace _521.tpfinal.api.Repository.Product
{
    public class DbProductsRepository(models.AppDbContext context) : Interfaces.IDbProductsRepository
    {
        private readonly models.AppDbContext _context = context;

        public Task Add(models.Product product)
        {   
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                throw new Exception($"Produit avec l'ID {product.Id} existe déjà");
            }
            this._context.Products.Add(product);
            return this._context.SaveChangesAsync();
        }

        public Task<bool> Delete(models.Product product)
        {
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id) ?? throw new Exception($"Produit avec l'ID {product.Id} non trouvé");
            this._context.Products.Remove(product);
            return Task.FromResult(this._context.SaveChanges() > 0);
        }

        public Task<List<models.Product>> GetAll()
        {
            if (this._context.Products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }

            return Task.FromResult(this._context.Products.ToList());
        }

        public Task<models.Product?> GetById(Guid id)
        {
            if (this._context.Products == null)
            {
                throw new Exception("Aucun produit trouvé");
            }

            return Task.FromResult(this._context.Products.FirstOrDefault(p => p.Id == id));
        }

        public Task Update(models.Product product)
        {
            var existingProduct = this._context.Products.FirstOrDefault(p => p.Id == product.Id) ?? throw new Exception($"Produit avec l'ID {product.Id} non trouvé");
            this._context.Products.Update(product);
            return this._context.SaveChangesAsync();
        }
    }
}
using _521.tpfinal.api.models;
using _521.tpfinal.api.Repository.ShoppingCart.Interfaces;

namespace _521.tpfinal.api.Repository.ShoppingCart
{
    public class DbShoppingCartRepository(AppDbContext context) : IDbShoppingCartRepository
    {
        private readonly AppDbContext _context = context;

        public Task Add(models.ShoppingCart cart)
        {
            var existingCart = this._context.ShoppingCarts.FirstOrDefault(c => c.Id == cart.Id);
            if (existingCart != null)
            {
                throw new Exception($"Panier avec l'ID {cart.Id} existe déjà");
            }
            this._context.ShoppingCarts.Add(cart);
            return this._context.SaveChangesAsync();
        }

        public Task AddItemToCart(models.CartItem item)
    {
        var existingItem = this._context.CartItems.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            throw new Exception($"Item de panier avec l'ID {item.Id} existe déjà");
        }
        this._context.CartItems.Add(item);
        return this._context.SaveChangesAsync();
    }

    public Task<bool> CheckStockAvailable(Guid productId, int quantity)
    {
        var product = this._context.Products.FirstOrDefault(p => p.Id == productId) ?? throw new Exception($"Produit avec l'ID {productId} non trouvé");
        return Task.FromResult(product.Stock >= quantity);
    }

    public Task ClearCart(Guid cartId)
    {
        var itemsToRemove = this._context.CartItems.Where(i => i.ShoppingCartId == cartId).ToList();
        this._context.CartItems.RemoveRange(itemsToRemove);
        return Task.FromResult(this._context.SaveChanges() > 0);
    }

    public Task<bool> Delete(models.ShoppingCart cart)
    {
        var existingCart = this._context.ShoppingCarts.FirstOrDefault(c => c.Id == cart.Id) ?? throw new Exception($"Panier avec l'ID {cart.Id} non trouvé");
        this._context.ShoppingCarts.Remove(existingCart);
        return Task.FromResult(this._context.SaveChanges() > 0);
    }

    public Task<models.ShoppingCart?> GetCartByUserId(Guid userId)
    {
        var existingCart = this._context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId) ?? throw new Exception($"Panier pour l'utilisateur avec l'ID {userId} non trouvé");
        return Task.FromResult<models.ShoppingCart?>(existingCart);
    }

    public Task<List<models.CartItem>> GetCartItems(Guid cartId)
    {
        var existingCart = this._context.ShoppingCarts.FirstOrDefault(c => c.Id == cartId) ?? throw new Exception($"Panier avec l'ID {cartId} non trouvé");
        return Task.FromResult(this._context.CartItems.Where(i => i.ShoppingCartId == cartId).ToList());    
    }

    public Task<bool> RemoveItemFromCart(Guid cartItemId)
    {
        var existingItem = this._context.CartItems.FirstOrDefault(i => i.Id == cartItemId) ?? throw new Exception($"Item de panier avec l'ID {cartItemId} non trouvé");
        this._context.CartItems.Remove(existingItem);
        return Task.FromResult(this._context.SaveChanges() > 0);
    }

    public Task<bool> UpdateItemQuantity(Guid cartItemId, int newQuantity)
    {
        var existingItem = this._context.CartItems.FirstOrDefault(i => i.Id == cartItemId) ?? throw new Exception($"Item de panier avec l'ID {cartItemId} non trouvé");
        existingItem.Quantity = newQuantity;
        this._context.CartItems.Update(existingItem);
        return Task.FromResult(this._context.SaveChanges() > 0);
    }
    }
}
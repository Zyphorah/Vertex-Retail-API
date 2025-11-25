namespace _521.tpfinal.api.Repository.ShoppingCart.Interfaces
{
    public interface IDbShoppingCartRepository
    {
        // Panier
        public Task<models.ShoppingCart?> GetCartByUserId(Guid userId);
        public Task Add(models.ShoppingCart cart);
        public Task<bool> Delete(models.ShoppingCart cart);
        
        // Items du panier
        public Task AddItemToCart(models.CartItem item);
        public Task<bool> RemoveItemFromCart(Guid cartItemId);
        public Task<bool> UpdateItemQuantity(Guid cartItemId, int newQuantity);
        public Task<List<models.CartItem>> GetCartItems(Guid cartId);
        public Task ClearCart(Guid cartId);
        
        // Validation stock
        public Task<bool> CheckStockAvailable(Guid productId, int quantity);
    }
}
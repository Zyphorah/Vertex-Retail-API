public interface IDbShoppingCartRepository
{
    // Panier
    public Task<ShoppingCart?> GetCartByUserId(Guid userId);
    public Task Add(ShoppingCart cart);
    public Task<bool> Delete(ShoppingCart cart);
    
    // Items du panier
    public Task AddItemToCart(CartItem item);
    public Task<bool> RemoveItemFromCart(int cartItemId);
    public Task<bool> UpdateItemQuantity(int cartItemId, int newQuantity);
    public Task<List<CartItem>> GetCartItems(Guid cartId);
    public Task ClearCart(Guid cartId);
    
    // Validation stock
    public Task<bool> CheckStockAvailable(int productId, int quantity);
    public Task UpdateProductStock(int productId, int quantityToRemove);
}



public class DbShoppingCartRepository : IDbShoppingCartRepository
{
    public Task Add(ShoppingCart cart)
    {
        throw new NotImplementedException();
    }

    public Task AddItemToCart(CartItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckStockAvailable(int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task ClearCart(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(ShoppingCart cart)
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingCart?> GetCartByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CartItem>> GetCartItems(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveItemFromCart(int cartItemId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateItemQuantity(int cartItemId, int newQuantity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductStock(int productId, int quantityToRemove)
    {
        throw new NotImplementedException();
    }
}
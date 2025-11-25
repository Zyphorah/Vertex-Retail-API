using _521.tpfinal.api.models.Dtos.ShopingCart;
using _521.tpfinal.api.models.Dtos.CartItem;

namespace _521.tpfinal.api.Services.ShoppingCart.Interfaces
{
    public interface IShoppingCartService
    {
        // Panier
        public Task<ShoppingCartDto?> GetCartByUserId(Guid userId);
        public Task Add(ShoppingCartDto cart);
        public Task<bool> Delete(ShoppingCartDto cart);
        
        // Items du panier
        public Task AddItemToCart(AddCartItemDto item);
        public Task<bool> RemoveItemFromCart(Guid cartItemId);
        public Task<bool> UpdateItemQuantity(Guid cartItemId, int newQuantity);
        public Task<List<CartItemDto>> GetCartItems(Guid cartId);
        public Task ClearCart(Guid cartId);
        
        // Validation stock
        public Task<bool> CheckStockAvailable(Guid productId, int quantity);
    }
}
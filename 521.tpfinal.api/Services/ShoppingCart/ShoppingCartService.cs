using _521.tpfinal.api.models.Dtos.CartItem;
using _521.tpfinal.api.models.Dtos.ShopingCart;
using _521.tpfinal.api.Repository.ShoppingCart.Interfaces;

namespace _521.tpfinal.api.Services.ShoppingCart
{
    public class ShoppingCartService(IDbShoppingCartRepository shoppingCartRepository) : Interfaces.IShoppingCartService
    {
        private readonly IDbShoppingCartRepository _shoppingCartRepository = shoppingCartRepository;

        public Task Add(ShoppingCartDto cart)
        {
            throw new NotImplementedException();
        }

        public Task AddItemToCart(AddCartItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckStockAvailable(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task ClearCart(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ShoppingCartDto cart)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartDto?> GetCartByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItemDto>> GetCartItems(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemFromCart(Guid cartItemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemQuantity(Guid cartItemId, int newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services.Cart
{
    public class CartService : Interfaces.ICartService
    {
        public Task<(bool success, string message)> AddItemToCartAsync(Guid productId, int quantity, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, Receipt receipt)> CheckoutAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetCartAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> RemoveItemFromCartAsync(Guid cartItemId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> UpdateItemQuantityAsync(Guid cartItemId, int quantity, string token)
        {
            throw new NotImplementedException();
        }
    }
}

namespace _521.tpfinal.web.Services.Cart.Interfaces
{
    public interface ICartService
    {
        Task<Models.CartResponse?> GetCartAsync(string token);

        Task<(bool success, string message)> AddItemToCartAsync(Guid productId, int quantity, string token);
        Task<(bool success, string message)> UpdateItemQuantityAsync(Guid cartItemId, int quantity, string token);

        Task<(bool success, string message)> RemoveItemFromCartAsync(Guid cartItemId, string token);
        Task<(bool success, Models.Receipt? receipt)> CheckoutAsync(string token);
    }
}

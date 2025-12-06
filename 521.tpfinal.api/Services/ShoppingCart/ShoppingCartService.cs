using _521.tpfinal.api.models.Dtos.CartItem;
using _521.tpfinal.api.models.Dtos.ShopingCart;
using _521.tpfinal.api.Repository.ShoppingCart.Interfaces;
using _521.tpfinal.api.Repository.Product.Interfaces;

namespace _521.tpfinal.api.Services.ShoppingCart
{
    public class ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductsRepository productsRepository) : Interfaces.IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository = shoppingCartRepository;
        private readonly IProductsRepository _productsRepository = productsRepository;

        public async Task Add(ShoppingCartDto cart)
        {
            await this._shoppingCartRepository.Add(new models.ShoppingCart
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,
                User = null!,
                CartItems = []
            });
        }

        public async Task AddItemToCart(AddCartItemDto item)
        {
            // Récupérer le prix du produit
            var product = await _productsRepository.GetById(item.ProductId) 
                ?? throw new Exception($"Produit avec l'ID {item.ProductId} non trouvé");
            
            await this._shoppingCartRepository.AddItemToCart(new models.CartItem
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = item.ShoppingCartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price,
                Product = null!,
                ShoppingCart = null!
            });
        }

        public async Task<bool> CheckStockAvailable(Guid productId, int quantity)
        {
            return await this._shoppingCartRepository.CheckStockAvailable(productId, quantity);
        }

        public async Task ClearCart(Guid cartId)
        {
            await this._shoppingCartRepository.ClearCart(cartId);
        }

        public async Task<bool> Delete(ShoppingCartDto cart)
        {
            return await this._shoppingCartRepository.Delete(new models.ShoppingCart
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,
                User = null!,
                CartItems = []
            });
        }

        public async Task<ShoppingCartDto?> GetCartByUserId(Guid userId)
        {
            var cart = await this._shoppingCartRepository.GetCartByUserId(userId);
            if (cart == null) return null;

            var cartItems = cart.CartItems.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                ShoppingCartId = ci.ShoppingCartId,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name ?? "Produit inconnu",
                ProductPrice = ci.UnitPrice,
                Quantity = ci.Quantity,
                SubTotal = ci.Quantity * ci.UnitPrice
            }).ToList();

            return new ShoppingCartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cartItems.Sum(item => item.SubTotal),
                Items = cartItems
            };
        }

        public async Task<List<CartItemDto>> GetCartItems(Guid cartId)
        {
            var items = await this._shoppingCartRepository.GetCartItems(cartId);
            return [.. items.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                ShoppingCartId = ci.ShoppingCartId,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name ?? "Produit inconnu",
                ProductPrice = ci.UnitPrice,
                Quantity = ci.Quantity,
                SubTotal = ci.Quantity * ci.UnitPrice
            })];
        }

        public async Task<bool> RemoveItemFromCart(Guid cartItemId)
        {
            return await this._shoppingCartRepository.RemoveItemFromCart(cartItemId);
        }

        public async Task<bool> UpdateItemQuantity(Guid cartItemId, int newQuantity)
        {
            return await this._shoppingCartRepository.UpdateItemQuantity(cartItemId, newQuantity);
        }
    }
}
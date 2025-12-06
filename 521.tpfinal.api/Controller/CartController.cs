using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _521.tpfinal.api.Models.Constance;
using System.Security.Claims;
using _521.tpfinal.api.models.Dtos.CartItem;

namespace _521.tpfinal.api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Client)]
    public class CartController(Services.ShoppingCart.Interfaces.IShoppingCartService shoppingCartService, Services.Product.Interfaces.IProductService productService) : ControllerBase
    {
        private readonly Services.ShoppingCart.Interfaces.IShoppingCartService _shoppingCartService = shoppingCartService;
        private readonly Services.Product.Interfaces.IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                    ?? throw new Exception("Utilisateur non identifié"));

                var cart = await _shoppingCartService.GetCartByUserId(userId);
                if (cart == null)
                {
                    return NotFound(new { message = "Panier non trouvé" });
                }
                
                return Ok(new 
                { 
                    cart = cart,
                    itemCount = cart.Items.Count,
                    totalPrice = cart.TotalPrice
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddItemToCart([FromBody] AddToCartRequestDto requestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (requestDto.Quantity <= 0)
                {
                    return BadRequest(new { error = "La quantité doit être au moins 1" });
                }

                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                    ?? throw new Exception("Utilisateur non identifié"));

                // Récupère le panier de l'utilisateur ou en crée un nouveau
                var cart = await _shoppingCartService.GetCartByUserId(userId);
                if (cart == null)
                {
                    // Créer un nouveau panier pour l'utilisateur
                    var newCart = new models.Dtos.ShopingCart.ShoppingCartDto
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        TotalPrice = 0,
                        Items = []
                    };
                    await _shoppingCartService.Add(newCart);
                    cart = newCart;
                }

                // Vérifie la disponibilité en stock
                var stockAvailable = await _shoppingCartService.CheckStockAvailable(requestDto.ProductId, requestDto.Quantity);
                if (!stockAvailable)
                {
                    return BadRequest(new { error = "Quantité insuffisante en stock" });
                }

                // Ajoute le produit au panier avec le bon ShoppingCartId
                var addItemDto = new AddCartItemDto
                {
                    ShoppingCartId = cart.Id,
                    ProductId = requestDto.ProductId,
                    Quantity = requestDto.Quantity
                };

                await _shoppingCartService.AddItemToCart(addItemDto);

                return StatusCode(201, new { message = "Produit ajouté au panier avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPut("items/{cartItemId}")]
        public async Task<IActionResult> UpdateItemQuantity(Guid cartItemId, [FromBody] models.Dtos.CartItem.CartItemUpdateDto updateDto)
        {
            try
            {
                if (updateDto.Quantity <= 0)
                {
                    return BadRequest(new { error = "La quantité doit être positive" });
                }

                var success = await _shoppingCartService.UpdateItemQuantity(cartItemId, updateDto.Quantity);
                if (!success)
                {
                    return NotFound(new { error = "Article du panier non trouvé" });
                }

                return Ok(new { message = "Quantité mise à jour avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(Guid cartItemId)
        {
            try
            {
                var success = await _shoppingCartService.RemoveItemFromCart(cartItemId);
                if (!success)
                {
                    return NotFound(new { error = "Article du panier non trouvé" });
                }

                return Ok(new { message = "Produit retiré du panier avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                    ?? throw new Exception("Utilisateur non identifié"));

                // Récupère le panier
                var cart = await _shoppingCartService.GetCartByUserId(userId);
                if (cart == null)
                {
                    return NotFound(new { error = "Panier non trouvé" });
                }

                if (cart.Items.Count == 0)
                {
                    return BadRequest(new { error = "Le panier est vide" });
                }

                // Valide les quantités en stock pour chaque produit
                foreach (var item in cart.Items)
                {
                    var stockAvailable = await _shoppingCartService.CheckStockAvailable(item.ProductId, item.Quantity);
                    if (!stockAvailable)
                    {
                        return BadRequest(new 
                        { 
                            error = $"Stock insuffisant pour le produit '{item.ProductName}'. Quantité disponible insuffisante." 
                        });
                    }
                }

                // Réduire le stock pour chaque produit acheté
                foreach (var item in cart.Items)
                {
                    var product = await _productService.GetById(item.ProductId);
                    if (product != null)
                    {
                        product.Stock -= item.Quantity;
                        await _productService.Update(product);
                    }
                }

                // Préparer le reçu avant de vider le panier
                var receipt = new
                {
                    orderId = Guid.NewGuid(),
                    orderDate = DateTime.UtcNow,
                    userId = userId,
                    items = cart.Items.Select(item => new
                    {
                        productId = item.ProductId,
                        productName = item.ProductName,
                        quantity = item.Quantity,
                        unitPrice = item.ProductPrice,
                        subtotal = item.SubTotal
                    }).ToList(),
                    totalAmount = cart.TotalPrice,
                    status = "Commande finalisée",
                    message = "Merci pour votre achat!"
                };

                // Vide le panier
                await _shoppingCartService.ClearCart(cart.Id);

                return Ok(receipt);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

}
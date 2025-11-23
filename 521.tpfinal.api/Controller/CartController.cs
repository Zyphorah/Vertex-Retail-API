using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IDbShoppingCartRepository _shoppingCartRepository;

    public CartController(IDbShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

}
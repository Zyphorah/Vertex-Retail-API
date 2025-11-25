using Microsoft.AspNetCore.Mvc;

namespace _521.tpfinal.api.Controller
{
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
}
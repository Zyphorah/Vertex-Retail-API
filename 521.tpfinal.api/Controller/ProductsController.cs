using Microsoft.AspNetCore.Mvc;

namespace _521.tpfinal.api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IDbProductsRepository _productsRepository;

        public ProductsController(IDbProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        
    }
}
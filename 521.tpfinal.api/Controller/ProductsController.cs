using Microsoft.AspNetCore.Mvc;

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
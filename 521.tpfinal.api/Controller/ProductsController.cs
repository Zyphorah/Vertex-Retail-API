using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IDbProducts _productsRepository;

    public ProductsController(IDbProducts productsRepository)
    {
        _productsRepository = productsRepository;
    }

    
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public AuthController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

   
}
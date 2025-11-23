using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public Auth(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

   
}
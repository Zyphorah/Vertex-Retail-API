using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

}
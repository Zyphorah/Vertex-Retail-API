using Microsoft.AspNetCore.Mvc;
using _521.tpfinal.api.Services.Auth.Interfaces;

namespace _521.tpfinal.api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(models.Dtos.LoginModel.RegisterDto registerDto)
        {
            try
            {
                await this._authService.Register(registerDto);
                return Ok(new { message = "Utilisateur enregistré avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(models.Dtos.LoginModel.LoginModelDto loginDto)
        {
            try
            {
                var response = await this._authService.Login(loginDto);
                return Ok(new 
                { 
                    token = response.Token,
                    expiration = response.Expiration,
                    message = "Authentification réussie"
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}

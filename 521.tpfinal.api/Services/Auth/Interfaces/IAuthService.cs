using _521.tpfinal.api.models.Dtos.LoginModel;

namespace _521.tpfinal.api.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginModelDto loginDto);
        Task<RegisterResponseDto> Register(RegisterDto registerDto);
    }
}
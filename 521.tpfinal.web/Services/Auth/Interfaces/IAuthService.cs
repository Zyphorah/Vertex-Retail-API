namespace _521.tpfinal.web.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<(bool success, string message)> RegisterAsync(Models.User user);
        Task<(bool success, string token)> LoginAsync(Models.Login loginModel);
    }
}

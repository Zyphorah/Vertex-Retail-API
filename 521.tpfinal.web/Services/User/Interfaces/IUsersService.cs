namespace _521.tpfinal.web.Services.User.Interfaces
{
    public interface IUsersService
    {
        Task<(bool success, string message)> CreateAdminAsync(Models.User user, string token);
        Task<(bool success, string message)> UpdateAsync(Guid userId, Models.User user, string token);
        Task<(bool success, string message)> DeleteAsync(Guid userId, string token);
    }
}

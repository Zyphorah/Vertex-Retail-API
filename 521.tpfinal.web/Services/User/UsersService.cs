
namespace _521.tpfinal.web.Services.User
{
    public class UsersService : Interfaces.IUsersService
    {
        public Task<(bool success, string message)> CreateAdminAsync(Models.User user, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> DeleteAsync(Guid userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> UpdateAsync(Guid userId, Models.User user, string token)
        {
            throw new NotImplementedException();
        }
    }
}
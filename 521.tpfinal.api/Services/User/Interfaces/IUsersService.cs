using _521.tpfinal.api.models.Dtos.User;

namespace _521.tpfinal.api.Services.User.Interfaces
{
    public interface IUsersService
    {
        public Task Add(CreateUserDto user);
        public Task<bool> Delete(UserDto user);
        public Task<bool> Update(Guid id, UpdateUserDto user);
        public List<UserDto> GetAll();
        public UserDto? GetById(Guid id);
    }
}
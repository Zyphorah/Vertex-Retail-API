public interface IUsersRepository
{
    public Task Add(User user);
    public Task<bool> Delete(User user);
    public Task<bool> Update(User user);
    public List<User> GetAll();
    public User? GetById(Guid id);
}
namespace _521.tpfinal.api.Repository.User.Interfaces
{
    public interface IUsersRepository
    {
        public Task Add(models.User user);
        public Task<bool> Delete(models.User user);
        public Task<bool> Update(models.User user);
        public List<models.User> GetAll();
        public models.User? GetById(Guid id);
    }
}
using _521.tpfinal.api.models;
using _521.tpfinal.api.Repository.User.Interfaces;

namespace _521.tpfinal.api.Repository.User
{
    public class DbUsersRepository(AppDbContext context) : IUsersRepository
    {
        private readonly AppDbContext _context = context;

        public Task Add(models.User user)
        {
            // Vérifier que l'ID n'existe pas déjà en BD
            if (this._context.Users.Any(u => u.Id == user.Id))
            {
                throw new Exception($"Un utilisateur avec l'ID {user.Id} existe déjà");
            }

            // Vérifier que l'email n'existe pas déjà en BD
            if (this._context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception($"L'email '{user.Email}' est déjà utilisé");
            }

            this._context.Users.Add(user);
            return this._context.SaveChangesAsync();
        }

        public Task<bool> Delete(models.User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var existingUser = this._context.Users.FirstOrDefault(u => u.Id == user.Id) ?? throw new Exception($"Utilisateur avec l'ID {user.Id} non trouvé");
            this._context.Users.Remove(existingUser);
            return Task.FromResult(this._context.SaveChanges() > 0);
        }

        public List<models.User> GetAll()
        {
            return this._context.Users.ToList();
        }

        public models.User? GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("L'ID ne peut pas être vide");
            }

            var existingUser = this._context.Users.FirstOrDefault(u => u.Id == id) ?? throw new Exception($"Utilisateur avec l'ID {id} non trouvé");
                return existingUser;
        }

        public Task<bool> Update(models.User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (user.Id == Guid.Empty)
            {
                throw new ArgumentException("L'ID de l'utilisateur ne peut pas être vide");
            }

            // Vérifier que l'utilisateur existe en BD
            var existingUser = this._context.Users.FirstOrDefault(u => u.Id == user.Id) ?? throw new Exception($"Utilisateur avec l'ID {user.Id} non trouvé");

                // Vérifier que l'email n'existe pas pour un autre utilisateur
                var existingEmail = this._context.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Id != user.Id);
            
            if (existingEmail != null)
            {
                throw new Exception($"L'email '{user.Email}' est déjà utilisé par un autre utilisateur");
            }

            this._context.Users.Update(user);
            return Task.FromResult(this._context.SaveChanges() > 0);
        }
    }
}
using _521.tpfinal.api.models;
using _521.tpfinal.api.Models.Constance;

namespace _521.tpfinal.api.Utils
{
    public static class AdminInitializer
    {
        public static void Initialize(AppDbContext context, PasswordHasher passwordHasher)
        {
            // Vérifier si un admin existe déjà
            if (context.Users.Any(u => u.Role == Roles.Admin))
            {
                return; // L'admin existe déjà
            }

            // Créer l'administrateur par défaut
            var adminEmail = "zyphorah.admin@gmail.com";
            var adminPassword = "Uj@l&l**^1M@*1KG";

            var admin = new User
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                Email = adminEmail,
                PasswordHash = passwordHasher.Hash(adminPassword, adminEmail),
                Role = Roles.Admin,
                ShoppingCarts = []
            };

            context.Users.Add(admin);
            context.SaveChanges();

            Console.WriteLine("Administrator created successfully!");
        }
    }
}

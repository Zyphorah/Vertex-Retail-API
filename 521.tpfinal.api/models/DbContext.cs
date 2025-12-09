using Microsoft.EntityFrameworkCore;
namespace _521.tpfinal.api.models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        // On définit les tables de la BD que l'on désire accéder comme suit:
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        // Méthode où l'on peut ajouter des validations de type Flutent API
        // Voir plus bas pour plus d'information.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            
            // Configuration Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            
            // Configuration des types décimaux pour SQL Server
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            
            // Configuration ShoppingCart
            modelBuilder.Entity<ShoppingCart>()
                .HasKey(s => s.Id);
            
            modelBuilder.Entity<ShoppingCart>()
                .Property(s => s.TotalPrice)
                .HasPrecision(18, 2);
            
            // Relation: User -> ShoppingCart (1 utilisateur peut avoir plusieurs paniers)
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(s => s.User)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Configuration CartItem
            modelBuilder.Entity<CartItem>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<CartItem>()
                .Property(c => c.UnitPrice)
                .HasPrecision(18, 2);
            
            // Relation: Product -> CartItem (1 produit peut être dans plusieurs paniers)
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Relation: ShoppingCart -> CartItem (1 panier peut avoir plusieurs articles)
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.ShoppingCart)
                .WithMany(s => s.CartItems)
                .HasForeignKey(c => c.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
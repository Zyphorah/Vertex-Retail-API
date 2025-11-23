using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public string DbPath { get; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var folder = AppDomain.CurrentDomain.BaseDirectory;
        DbPath = System.IO.Path.Join(folder, "app.db");
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
        
        // Configuration ShoppingCart
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(s => s.Id);
        
        // Relation: User -> ShoppingCart (1 utilisateur peut avoir plusieurs paniers)
        modelBuilder.Entity<ShoppingCart>()
            .HasOne(s => s.User)
            .WithMany(u => u.ShoppingCarts)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configuration CartItem
        modelBuilder.Entity<CartItem>()
            .HasKey(c => c.Id);
        
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

    // Chargement de la BD à utiliser. La ligne va varier selon le type de BD.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}"); // Chargement de la BD
    }
}
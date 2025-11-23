using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public string DbPath { get; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var folder = AppDomain.CurrentDomain.BaseDirectory;
        DbPath = System.IO.Path.Join(folder, "app.db");
    }
    
    public DbSet<Post> Posts{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(wf => wf.Id);
                
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}"); 
    }
}
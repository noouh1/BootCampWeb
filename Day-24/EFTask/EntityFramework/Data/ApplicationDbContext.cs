using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlServer(@"Server=DESKTOP-PNLMVN8;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Product>()
            .Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductWithCategory>()
            .HasNoKey()
            .ToView("vw_ProductWithCategory", schema: "dbo");

    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductWithCategory> ProductWithCategories { get; set; } = null!;
    

}
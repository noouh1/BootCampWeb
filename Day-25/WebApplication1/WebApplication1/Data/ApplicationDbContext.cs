using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options){
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Models.Employee>()
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Models.Employee>()
            .HasOne(e => e.Login)
            .WithOne(l => l.Employee)
            .HasForeignKey<Models.Login>(l => l.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Models.Login>()
            .HasIndex(l => l.Username)
            .IsUnique(); 

    }

    public DbSet<Models.Employee> Employees { get; set; }
    public DbSet<Models.Department> Departments { get; set; }
    public DbSet<Models.Role> Roles { get; set; }
    public DbSet<Models.Login> Logins { get; set; }
    
}
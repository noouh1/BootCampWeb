using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Emails;

namespace WebApplication1.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ApprovedProduct> ApprovedProducts { get; set; }
    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
    public DbSet<PasswordResetSession> PasswordResetSessions { get; set; }

}
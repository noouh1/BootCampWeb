using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }


   
    
}
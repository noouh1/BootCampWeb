using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class LearnEntityConfigurations : IEntityTypeConfiguration<LearnEntity>
{
    public void Configure(EntityTypeBuilder<LearnEntity> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder.HasOne(sc => sc.Student)
            .WithMany(s => s.Courses)
            .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(sc => sc.CourseId);
    }
    
}
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Configurations;

public class WorksOnConfigurations : IEntityTypeConfiguration<WorksOn>
{
    public void Configure(EntityTypeBuilder<WorksOn> builder)
    {
        builder.HasKey(wo => new { wo.EmployeeId, wo.ProjectId });
        builder.HasOne(wo => wo.Employee)
            .WithMany(e => e.WorksOnProjects)
            .HasForeignKey(wo => wo.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(wo => wo.Project)
            .WithMany(p => p.Employees)
            .HasForeignKey(wo => wo.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}
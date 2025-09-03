using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.D_No);
        builder.HasOne(d=>d.Manager)
            .WithOne(e=>e.DeptManager)
            .HasForeignKey<Department>(d=>d.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

            
            
    
    }
    
}
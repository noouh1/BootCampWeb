using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models.Cart;

namespace Project.Infrastructure.Configurations;

public class CartConfigurations : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder
            .Property(x => x.UserId)
            .IsRequired();
                        
        builder
            .Property(x=>x.CreatedAt)
            .HasDefaultValueSql("getdate()");
            
        builder
            .Property(x=>x.UpdatedAt)
            .HasDefaultValueSql("getdate()");


        builder.HasMany(c => c.Items)
            .WithOne(i => i.Cart)
            .HasForeignKey(i => i.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}
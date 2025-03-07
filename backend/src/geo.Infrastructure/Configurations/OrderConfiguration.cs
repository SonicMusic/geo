using geo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace geo.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Title).IsRequired(false);
        builder.Property(o => o.Description).IsRequired(false);
        builder.Property(o => o.Client).IsRequired(false);
        builder.Property(o => o.Confirmed).HasDefaultValue(DateTimeOffset.MinValue);
        builder.Property(o => o.Completed).HasDefaultValue(DateTimeOffset.MaxValue);

        builder.ComplexProperty(o => o.Specialist, builder =>
        {
            builder.Property(s => s.Value)
                .HasColumnName("specialist")
                .IsRequired(true);
        });
        
        builder.ComplexProperty(o => o.Status, builder =>
        {
            builder.Property(s => s.Value)
                .HasColumnName("status")
                .IsRequired(true)
                .HasDefaultValue(nameof(Status.Open));
        });

    }
}
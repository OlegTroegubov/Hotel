using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

internal  class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
{
    public void Configure(EntityTypeBuilder<Visitor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(300);
        
        builder.Property(x => x.MiddleName)
            .HasMaxLength(300);
        
        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.HasMany(x => x.Reservations)
            .WithOne(x => x.Visitor)
            .HasForeignKey(x => x.VisitorId)
            .IsRequired();
    }
}
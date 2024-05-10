using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.Area)
            .IsRequired();

        builder.Property(x => x.PricePerDay)
            .IsRequired();
        
        builder.Property(x => x.Type)
            .IsRequired();
        
        builder.HasMany(x => x.Amenities)
            .WithMany(x => x.Rooms)
            .UsingEntity<RoomAmenity>();
        
        builder.HasMany(x => x.Reservations)
            .WithOne(x => x.Room)
            .HasForeignKey(x => x.RoomId)
            .IsRequired();
    }
}
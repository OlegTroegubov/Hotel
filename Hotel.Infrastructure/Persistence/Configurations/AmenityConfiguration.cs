using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Amenities;
using Hotel.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

internal class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(x => x.Rooms)
            .WithMany(x => x.Amenities)
            .UsingEntity<RoomAmenity>();
    }
}
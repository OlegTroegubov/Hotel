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

        builder.HasData([
            new Amenity
            {
                Id = 1,
                Title = "AirConditioning"
            },
            new Amenity
            {
                Id = 2,
                Title = "Patio"
            },
            new Amenity
            {
                Id = 3,
                Title = "PrivateBathroom"
            },
            new Amenity
            {
                Id = 4,
                Title = "FlatScreenTv"
            },
            new Amenity
            {
                Id = 5,
                Title = "Soundproofing"
            },
            new Amenity
            {
                Id = 6,
                Title = "CoffeeMachine"
            },
            new Amenity
            {
                Id = 7,
                Title = "Minibar"
            },
            new Amenity
            {
                Id = 8,
                Title = "FreeWiFi"
            }
        ]);
    }
}
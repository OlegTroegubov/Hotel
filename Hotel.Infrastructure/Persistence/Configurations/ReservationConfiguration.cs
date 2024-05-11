using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

internal  class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.CheckIn)
            .IsRequired();
        
        builder.Property(x => x.CheckOut)
            .IsRequired();

        builder.HasOne(x => x.Visitor)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.VisitorId)
            .IsRequired();
        
        builder.HasOne(x => x.Room)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.RoomId)
            .IsRequired();
    }
}
using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Amenities;
using Hotel.Domain.Entities.Reservations;
using Hotel.Domain.Entities.Rooms;
using Hotel.Domain.Entities.Visitor;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Room> Rooms { get; }
    DbSet<Visitor> Visitors { get; }
    DbSet<Amenity> Amenities { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<RoomAmenity> RoomAmenities { get; }
}
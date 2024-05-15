using System.Reflection;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using Hotel.Domain.Entities.Reservations;
using Hotel.Domain.Entities.Rooms;
using Hotel.Domain.Entities.Visitor;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext, IUnitOfWork
{
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<RoomAmenity> RoomAmenities => Set<RoomAmenity>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Visitor> Visitors => Set<Visitor>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
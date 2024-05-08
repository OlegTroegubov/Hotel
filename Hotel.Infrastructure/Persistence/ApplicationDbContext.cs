using System.Reflection;
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Visitor> Visitors => Set<Visitor>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
using Hotel.Domain.Entities.Reservations;

namespace Hotel.Domain.Entities.Visitor;

public sealed class Visitor : Entity
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; } 
    public required string Phone { get; init; }
    public string? Email { get; init; }
    public ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
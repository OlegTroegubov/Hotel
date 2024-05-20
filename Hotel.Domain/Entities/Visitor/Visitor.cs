using Hotel.Domain.Entities.Reservations;

namespace Hotel.Domain.Entities.Visitor;

public sealed class Visitor : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
    public ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
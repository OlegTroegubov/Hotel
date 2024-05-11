using Hotel.Domain.Entities.Rooms;

namespace Hotel.Domain.Entities.Reservations;

public sealed class Reservation : Entity
{
    public Guid RoomId { get; init; }
    public Guid VisitorId { get; init; }
    public DateTime CheckIn { get; init; }   
    public DateTime CheckOut { get; init; }
    public required Room Room { get; init; }
    public required Visitor.Visitor Visitor { get; init; }
}


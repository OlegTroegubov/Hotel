namespace Hotel.Domain.Entities;

public class Reservation : Entity
{
    public Guid RoomId { get; init; }
    public Guid VisitorId { get; init; }
    public DateTime CheckIn { get; init; }   
    public DateTime CheckOut { get; init; }
}


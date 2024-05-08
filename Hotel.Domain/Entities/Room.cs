using Hotel.Domain.Enums;

namespace Hotel.Domain.Entities;

public class Room : Entity
{
    public double Area { get; init; }
    public RoomType Type { get; init; }
    public decimal PricePerDay { get; init; }
    public RoomFeature Feature { get; init; }
}
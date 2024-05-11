using Hotel.Domain.Entities.Rooms;

namespace Hotel.Domain.Entities.Amenities;

public sealed class Amenity
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public ICollection<Room> Rooms { get; } = new List<Room>();
}
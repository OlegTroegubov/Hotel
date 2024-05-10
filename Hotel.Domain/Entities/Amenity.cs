namespace Hotel.Domain.Entities;

public class Amenity
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public ICollection<Room> Rooms { get; } = new List<Room>();
}
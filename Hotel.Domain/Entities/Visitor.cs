namespace Hotel.Domain.Entities;

public class Visitor : Entity
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; } 
    public required string Phone { get; init; }
    public required string Email { get; init; }
}
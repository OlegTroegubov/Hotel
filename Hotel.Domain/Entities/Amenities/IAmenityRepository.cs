namespace Hotel.Domain.Entities.Amenities;

public interface IAmenityRepository
{
    Task CreateAsync(Amenity amenity, CancellationToken cancellationToken);
    void Delete(Amenity amenity);
    Task<Amenity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsTitleUniqueAsync(string title, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Amenity>> GetAllAsync(CancellationToken cancellationToken);
}
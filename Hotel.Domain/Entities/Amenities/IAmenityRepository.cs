﻿namespace Hotel.Domain.Entities.Amenities;

public interface IAmenityRepository
{
    Task CreateAsync(Amenity amenity, CancellationToken cancellationToken);
    void Delete(Amenity amenity);
    Task<Amenity?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Amenity?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Amenity>> GetAsync(CancellationToken cancellationToken);
}
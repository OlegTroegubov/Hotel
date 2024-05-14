using System.Linq.Expressions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Repositories;

internal sealed class AmenityRepository(IApplicationDbContext context) : IAmenityRepository
{
    public async Task CreateAsync(Amenity amenity, CancellationToken cancellationToken)
    { 
        await context.Amenities.AddAsync(amenity, cancellationToken);
    }

    public void Delete(Amenity amenity)
    {
        context.Amenities.Remove(amenity);
    }
    
    public async Task<Amenity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Amenities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<bool> IsTitleUniqueAsync(string title, CancellationToken cancellationToken)
    {
        return await context.Amenities.AnyAsync(x => x.Title == title, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Amenity>> GetAsync(CancellationToken cancellationToken)
    {
        return await context.Amenities.ToListAsync(cancellationToken);
    }
}
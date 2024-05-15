using AutoMapper;
using Hotel.Application.Common.Exceptions;
using Hotel.Application.Features.Queries.AmenityQueries.GetById;
using Hotel.Domain.Entities.Amenities;
using Moq;

namespace Hotel.Application.UnitTests.Amenity.Queries;

public class GetAmenityByIdQueryHandlerTests
{
    private readonly Mock<IAmenityRepository> _amenityRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task Handle_ThrowsNotFoundException_WhenAmenityNotExist()
    {
        //Arrange
        var command = new GetAmenityByIdQuery
        {
            Id = 1
        };

        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.Amenities.Amenity?)null);

        var handler = new GetAmenityByIdQueryHandler(_amenityRepositoryMock.Object, _mapperMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(
            () => handler.Handle(command, default));
    }

    [Fact]
    public async Task Handle_ShouldGetAmenity_WhenAmenityExist()
    {
        var query = new GetAmenityByIdQuery
        {
            Id = 1
        };

        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Domain.Entities.Amenities.Amenity
            {
                Id = query.Id,
                Title = "test"
            });

        var handler = new GetAmenityByIdQueryHandler(_amenityRepositoryMock.Object, _mapperMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(async () => { await handler.Handle(query, default); });

        // Assert
        Assert.Null(exception);
    }
}
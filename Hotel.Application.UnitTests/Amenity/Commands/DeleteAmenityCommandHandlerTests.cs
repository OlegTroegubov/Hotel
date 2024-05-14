using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Application.Features.Commands.AmenityCommands.DeleteAmenity;
using Hotel.Domain.Entities.Amenities;
using Moq;

namespace Hotel.Application.UnitTests.Amenity.Commands;

public class DeleteAmenityCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new ();
    private readonly Mock<IAmenityRepository> _amenityRepositoryMock = new ();

    [Fact]
    public async Task Handle_ShouldDelete_WhenAmenityExists()
    {
        //Arrange
        var command = new DeleteAmenityCommand()
        {
            Id = 1
        };
        
        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Domain.Entities.Amenities.Amenity
            {
                Id = command.Id,
                Title = "test"
            });
        
        var handler = new DeleteAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(async () =>
        {
            await handler.Handle(command, default);
        });

        // Assert
        Assert.Null(exception);
    }
    
    [Fact]
    public async Task Handle_ThrowNotFoundException_WhenAmenityNotExists()
    {
        //Arrange
        var command = new DeleteAmenityCommand()
        {
            Id = 1
        };
        
        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.Amenities.Amenity?)null);
        
        var handler = new DeleteAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(
            () => handler.Handle(command, default));
    }
}
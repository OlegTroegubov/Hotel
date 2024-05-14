using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Application.Features.Commands.AmenityCommands.UpdateAmenity;
using Hotel.Domain.Entities.Amenities;
using Moq;

namespace Hotel.Application.UnitTests.Amenity.Commands;

public class UpdateAmenityCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new ();
    private readonly Mock<IAmenityRepository> _amenityRepositoryMock = new ();

    [Fact]
    public async Task Handle_ShouldUpdateAmenity_WhenAmenityExistsAndTitleIsUnique()
    {
        //Arrange
        var command = new UpdateAmenityCommand
        {
            Id = 1,
            Title = "updateTest"
        };
        
        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Domain.Entities.Amenities.Amenity
            {
                Id = 1,
                Title = "test"
            });
        
        _amenityRepositoryMock.Setup(
                x => x.IsTitleUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        
        var handler = new UpdateAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(async () =>
        {
            await handler.Handle(command, default);
        });

        // Assert
        Assert.Null(exception);
    }
    
    [Fact]
    public async Task Handle_ShouldThrowAlreadyExistsException_WhenTitleIsNotUnique()
    {
        //Arrange
        var command = new UpdateAmenityCommand()
        {
            Id = 1,
            Title = "test"
        };

        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Domain.Entities.Amenities.Amenity
            {
                Id = 1,
                Title = "test"
            });
        
        _amenityRepositoryMock.Setup(
                x => x.IsTitleUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        
        var handler = new UpdateAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);
        
        // Act & Assert
        await Assert.ThrowsAsync<AlreadyExistsException>(
            () => handler.Handle(command, default));
    }

    [Fact]
    public async Task Handle_ThrowNotFoundException_WhenAmenityNotExists()
    {
        //Arrange
        var command = new UpdateAmenityCommand()
        {
            Id = 1,
            Title = "test"
        };
        
        _amenityRepositoryMock.Setup(
                x => x.GetByIdAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.Amenities.Amenity?)null);
        
        var handler = new UpdateAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(
            () => handler.Handle(command, default));
    }
}
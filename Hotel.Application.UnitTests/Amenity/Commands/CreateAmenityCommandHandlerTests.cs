using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;
using Hotel.Domain.Entities.Amenities;
using Moq;

namespace Hotel.Application.UnitTests.Amenity.Commands;

public class CreateAmenityCommandHandlerTests
{
    private readonly Mock<IAmenityRepository> _amenityRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

    [Fact]
    public async Task Handle_ShouldCreateAmenity_WhenTitleIsUnique()
    {
        //Arrange
        var command = new CreateAmenityCommand
        {
            Title = "test"
        };

        _amenityRepositoryMock.Setup(
                x => x.IsTitleUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new CreateAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        _amenityRepositoryMock.Verify(
            x => x.CreateAsync(
                It.Is<Domain.Entities.Amenities.Amenity>(a => a.Id == result),
                It.IsAny<CancellationToken>())
            , Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowAlreadyExistsException_WhenTitleIsNotUnique()
    {
        //Arrange
        var command = new CreateAmenityCommand
        {
            Title = "test"
        };

        _amenityRepositoryMock.Setup(
                x => x.IsTitleUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new CreateAmenityCommandHandler(_amenityRepositoryMock.Object, _unitOfWorkMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<AlreadyExistsException>(
            () => handler.Handle(command, default));
    }
}
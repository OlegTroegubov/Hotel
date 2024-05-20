using Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;
using Hotel.Application.Features.Commands.AmenityCommands.DeleteAmenity;
using Hotel.Application.Features.Commands.AmenityCommands.UpdateAmenity;
using Hotel.Application.Features.Queries.AmenityQueries;
using Hotel.Application.Features.Queries.AmenityQueries.GetAll;
using Hotel.Application.Features.Queries.AmenityQueries.GetById;
using Hotel.Controllers.Amenity.InputModels.Create;
using Hotel.Controllers.Amenity.InputModels.Delete;
using Hotel.Controllers.Amenity.InputModels.Get;
using Hotel.Controllers.Amenity.InputModels.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers.Amenity;

[ApiController]
[Route("api/[controller]/[action]")]
public class AmenityController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAmenityInputModel model,
        CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateAmenityCommand
        {
            Title = model.Title!
        }, cancellationToken);
        return Created(string.Empty, new { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> Change([FromBody] UpdateAmenityInputModel model,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateAmenityCommand
        {
            Id = model.Id,
            Title = model.Title!
        }, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<AmenityDto>>> Get(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAmenitiesQuery(), cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<AmenityDto>>
        GetById([FromQuery] GetAmenityByIdInputModel model, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAmenityByIdQuery
        {
            Id = model.Id
        }, cancellationToken));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteAmenityInputModel model,
        CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteAmenityCommand
        {
            Id = model.Id
        }, cancellationToken);
        return Ok();
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Artists.Commands.CreateArtist;
using MovieStore.Application.Artists.Commands.DeleteArtist;
using MovieStore.Application.Artists.Commands.UpdateArtist;
using MovieStore.Application.Artists.Queries.GetArtists;
using MovieStore.Application.Common.Models;

namespace MovieStore.Api.Controllers;

public class ArtistController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateArtistCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromBody] UpdateArtistCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteArtistCommand { Id = id }));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetArtistsVm>>> Get([FromQuery] GetArtistsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
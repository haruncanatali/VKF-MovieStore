using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Genres.Commands.CreateGenre;
using MovieStore.Application.Genres.Queries.GetGenres;

namespace MovieStore.Api.Controllers;

public class GenreController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateGenreCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetGenresVm>>> List([FromQuery] GetGenresQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
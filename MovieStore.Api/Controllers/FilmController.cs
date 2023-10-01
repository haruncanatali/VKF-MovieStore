using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Films.Commands.CreateFilm;
using MovieStore.Application.Films.Commands.DeleteFilm;
using MovieStore.Application.Films.Commands.UpdateFilm;
using MovieStore.Application.Films.Queries.Dtos;
using MovieStore.Application.Films.Queries.GetFilm;
using MovieStore.Application.Films.Queries.GetFilms;

namespace MovieStore.Api.Controllers;

public class FilmController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateFilmCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromBody] UpdateFilmCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteFilmCommand { Id = id }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<FilmDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetFilmQuery{Id = id}));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetFilmsVm>>> List([FromQuery] GetFilmsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
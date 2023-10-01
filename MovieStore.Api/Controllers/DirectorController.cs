using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Directors.Commands.CreateDirector;
using MovieStore.Application.Directors.Commands.DeleteDirector;
using MovieStore.Application.Directors.Commands.UpdateDirector;
using MovieStore.Application.Directors.Queries.GetDirectors;

namespace MovieStore.Api.Controllers;

public class DirectorController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateDirectorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Update([FromBody] UpdateDirectorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteDirectorCommand { Id = id }));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetDirectorsVm>>> Get([FromQuery] GetDirectorsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
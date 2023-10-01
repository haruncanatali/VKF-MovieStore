using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Users.Commands.CreateUser;
using MovieStore.Application.Users.Commands.DeleteUser;
using MovieStore.Application.Users.Queries.Dtos;
using MovieStore.Application.Users.Queries.GetUser;

namespace MovieStore.Api.Controllers;

public class UserController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteUserCommand { Id = id }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseModel<UserDto>>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetUserQuery { Id = id }));
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Roles.Commands.AddRoleCommand;
using MovieStore.Application.Roles.Queries.GetRoleList;

namespace MovieStore.Api.Controllers;

public class RoleController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create(AddRoleCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetRoleListVm>>> List([FromQuery] GetRoleListQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Auth.Dtos;
using MovieStore.Application.Auth.Queries.Login;
using MovieStore.Application.Common.Models;

namespace MovieStore.Api.Controllers;

public class AuthController : BaseController
{
    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<BaseResponseModel<LoginDto>>> Login([FromBody] LoginQuery loginCommand)
    {
        return Ok(await Mediator.Send(loginCommand));
    }
}
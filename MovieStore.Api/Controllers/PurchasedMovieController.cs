using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Common.Models;
using MovieStore.Application.PurchasedMovies.Commands.CreatePurchasedMovie;
using MovieStore.Application.PurchasedMovies.Commands.DeletePurchasedMovie;

namespace MovieStore.Api.Controllers;

public class PurchasedMovieController : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreatePurchasedMovieCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeletePurchasedMovieCommand { Id = id }));
    }
}
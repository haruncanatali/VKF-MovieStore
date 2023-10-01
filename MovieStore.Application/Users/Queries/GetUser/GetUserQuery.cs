using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Users.Queries.Dtos;

namespace MovieStore.Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<BaseResponseModel<UserDto>>
{
    public long Id { get; set; }
}
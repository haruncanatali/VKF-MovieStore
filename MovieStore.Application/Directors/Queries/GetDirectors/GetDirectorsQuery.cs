using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Directors.Queries.Dtos;

namespace MovieStore.Application.Directors.Queries.GetDirectors;

public class GetDirectorsQuery : IRequest<BaseResponseModel<GetDirectorsVm>>
{
    public string? Name { get; set; }
}
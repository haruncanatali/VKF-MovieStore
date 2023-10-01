using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Films.Queries.GetFilms;

public class GetFilmsQuery : IRequest<BaseResponseModel<GetFilmsVm>>
{
    
}
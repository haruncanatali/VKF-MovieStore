using MediatR;
using MovieStore.Application.Common.Models;

namespace MovieStore.Application.Genres.Queries.GetGenres;

public class GetGenresQuery : IRequest<BaseResponseModel<GetGenresVm>>
{
    
}
using MediatR;
using MovieStore.Application.Common.Models;

namespace MovieStore.Application.Artists.Queries.GetArtists;

public class GetArtistsQuery : IRequest<BaseResponseModel<GetArtistsVm>>
{
    public string Name { get; set; }
}
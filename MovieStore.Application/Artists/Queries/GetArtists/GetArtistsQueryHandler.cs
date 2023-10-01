using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Artists.Queries.Dtos;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;

namespace MovieStore.Application.Artists.Queries.GetArtists;

public class GetArtistsQueryHandler : IRequestHandler<GetArtistsQuery,BaseResponseModel<GetArtistsVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetArtistsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetArtistsVm>> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
    {
        List<ArtistDto> artistList = await _context.Artists
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var result = new GetArtistsVm
        {
            Artists = artistList,
            Count = artistList.Count
        };

        return new BaseResponseModel<GetArtistsVm>().Success(result,"");
    }
}
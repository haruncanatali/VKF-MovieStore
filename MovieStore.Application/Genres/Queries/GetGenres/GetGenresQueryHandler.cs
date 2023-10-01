using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Genres.Queries.Dtos;

namespace MovieStore.Application.Genres.Queries.GetGenres;

public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery,BaseResponseModel<GetGenresVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetGenresQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetGenresVm>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
    {
        var genreList = await _context.Genres
            .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var result = new GetGenresVm
        {
            Genres = genreList,
            Count = genreList.Count
        };

        return new BaseResponseModel<GetGenresVm>().Success(result,"");
    }
}
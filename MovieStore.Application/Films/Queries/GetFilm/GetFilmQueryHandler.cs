using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Films.Queries.Dtos;

namespace MovieStore.Application.Films.Queries.GetFilm;

public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery,BaseResponseModel<FilmDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFilmQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<FilmDto>> Handle(GetFilmQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Films
            .Where(c => c.Id == request.Id)
            .Include(c => c.Artists)
            .Include(c => c.Director)
            .Include(c => c.Genre)
            .ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return new BaseResponseModel<FilmDto>().Success(result,"");
    }
}
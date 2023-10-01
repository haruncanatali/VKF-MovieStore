using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Artists.Queries.GetArtists;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Films.Queries.Dtos;

namespace MovieStore.Application.Films.Queries.GetFilms;

public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery,BaseResponseModel<GetFilmsVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetFilmsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetFilmsVm>> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
    {
        var filmList = await _context.Films
            .Include(c => c.Artists)
            .Include(c => c.Director)
            .Include(c => c.Genre)
            .ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var result = new GetFilmsVm
        {
            Films = filmList,
            Count = filmList.Count
        };

        return new BaseResponseModel<GetFilmsVm>().Success(result, "");
    }
}
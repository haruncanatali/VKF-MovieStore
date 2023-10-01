using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Directors.Queries.Dtos;

namespace MovieStore.Application.Directors.Queries.GetDirectors;

public class GetDirectorsQueryHandler : IRequestHandler<GetDirectorsQuery,BaseResponseModel<GetDirectorsVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetDirectorsQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetDirectorsVm>> Handle(GetDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directorList = await _context.Directors
            .Where(c => (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())))
            .ProjectTo<DirectorDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var result = new GetDirectorsVm
        {
            Directors = directorList,
            Count = directorList.Count
        };

        return new BaseResponseModel<GetDirectorsVm>().Success(result, "");
    }
}
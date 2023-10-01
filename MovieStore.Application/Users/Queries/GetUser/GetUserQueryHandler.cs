using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Users.Queries.Dtos;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery,BaseResponseModel<UserDto>>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _userManager.Users
            .Where(c => c.Id == request.Id)
            .Include(c => c.PurchasedMovies)
            .ThenInclude(c => c.Film)
            .Include(c => c.CustomerFavorites)
            .ThenInclude(c => c.Genre)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return new BaseResponseModel<UserDto>().Success(result, "");
    }
}
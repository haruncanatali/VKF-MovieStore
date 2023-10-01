using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Application.Roles.Queries.Dtos;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Roles.Queries.GetRoleList;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery,GetRoleListVm>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;
    private readonly ILogger<GetRoleListQueryHandler> _logger;
    
    public GetRoleListQueryHandler(IMapper mapper, RoleManager<Role> roleManager, ILogger<GetRoleListQueryHandler> logger)
    {
        _mapper = mapper;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<GetRoleListVm> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var query = _roleManager.Roles;

        if (request.RoleName.IsNullOrEmpty().Equals(false))
        {
            query = query.Where(c => c.Name == request.RoleName);
        }

        var result = await query.ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        _logger.LogInformation($"Role listesi çekildi. Count:{result.Count}");

        return new GetRoleListVm
        {
            Roles = result,
            Count = result?.Count
        };
    }
}
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Roles.Commands.AddRoleCommand;

public class AddRoleCommand : IRequest<BaseResponseModel<Unit>>
{
    public string? RoleName { get; set; }
    
    public class Handler : IRequestHandler<AddRoleCommand, BaseResponseModel<Unit>>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<AddRoleCommand> _logger;

        public Handler(RoleManager<Role> roleManager, ILogger<AddRoleCommand> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }
        
        public async Task<BaseResponseModel<Unit>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _roleManager.RoleExistsAsync(request.RoleName);
                
            if(!isExist && request.RoleName.IsNullOrEmpty().Equals(false))
            {
                await _roleManager.CreateAsync(new Role{
                    Name = request.RoleName
                });
                _logger.LogInformation("Rol ekleme girişimi başarılı oldu.");
            
                return new BaseResponseModel<Unit>().Success(Unit.Value,"Rol başarıyla eklendi.");
            }
            
            return new BaseResponseModel<Unit>().Failure(new List<string>{"Rol ekleme işlemi başarısız oldu."});
        }
    }
}
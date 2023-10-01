using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<BaseResponseModel<long>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, BaseResponseModel<long>>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IApplicationContext _context;
            private readonly ILogger<CreateUserCommand> _logger;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager,IApplicationContext context, ILogger<CreateUserCommand> logger)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _context = context;
                _logger = logger;
            }

            public async Task<BaseResponseModel<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    bool dublicateControl = _context.Users.Any(x => x.UserName == request.Email);
                    if (dublicateControl)
                    {
                        return new BaseResponseModel<long>().Failure(new List<string>{"Aynı kullanıcı adına sahip kullanıcı mevcut"});
                    }

                    User entity = new()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        UserName = request.Email,
                        Email = request.Email
                    };
                    
                    var password = request.Password;

                    await _userManager.CreateAsync(entity, password);
                    
                    _logger.LogInformation("Kullanıcı ekleme girişimi başarılı oldu.");


                    setRole:
                    Role? role = await _roleManager.FindByNameAsync("Customer");
                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(entity, role.Name!);
                    }
                    else
                    {
                        await _roleManager.CreateAsync(new Role
                        {
                            Name = "Customer"
                        });
                        goto setRole;
                    }
                    
                    _logger.LogInformation("Kullanıcıya rol ekleme girişimi başarılı oldu.");

                    return new BaseResponseModel<long>().Success(entity.Id,"Kullanıcı başarıyla oluşturuldu.");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
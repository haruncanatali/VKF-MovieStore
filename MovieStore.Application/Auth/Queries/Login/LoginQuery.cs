using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieStore.Application.Auth.Dtos;
using MovieStore.Application.Common.Managers;
using MovieStore.Application.Common.Mappings;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Auth.Queries.Login;

public class LoginQuery : IRequest<BaseResponseModel<LoginDto>>, IMapFrom<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<LoginQuery, BaseResponseModel<LoginDto>>
        {
            private readonly SignInManager<User> _signInManager;

            private readonly TokenManager _tokenManager;
            private readonly UserManager<User> _userManager;

            public Handler(SignInManager<User> signInManager, TokenManager tokenManager, UserManager<User> userManager)
            {
                _signInManager = signInManager;
                _tokenManager = tokenManager;
                _userManager = userManager;
            }

            public async Task<BaseResponseModel<LoginDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                LoginDto loginViewModel = new LoginDto();
                User? appUser = await _userManager.FindByNameAsync(request.UserName);
                if (appUser != null)
                {
                    var result =
                        await _signInManager.PasswordSignInAsync(appUser.UserName, request.Password, false, false);
                    if (result.Succeeded)
                    {
                        loginViewModel = await _tokenManager.GenerateToken(appUser);
                        return new BaseResponseModel<LoginDto>().Success(data: loginViewModel);
                    }
                }

                return new BaseResponseModel<LoginDto>().Failure(new List<string>() { "Başarısız." });
            }
        }
    }
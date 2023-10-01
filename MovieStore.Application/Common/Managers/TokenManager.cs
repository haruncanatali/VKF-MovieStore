using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Application.Auth.Dtos;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Common.Managers;

public class TokenManager
{
    private readonly TokenSettings _tokenSettings;
    private readonly UserManager<User> _userManager;

    public TokenManager(IOptions<TokenSettings> tokenSettings, UserManager<User> userManager)
    {
        _tokenSettings = tokenSettings.Value;
        _userManager = userManager;
    }

    public async Task<LoginDto> GenerateToken(User appUser)
    {
        var claims = new List<Claim>();
        
        string? responseRole = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
        if (!string.IsNullOrEmpty(responseRole))
        {
            claims.Add(new Claim(ClaimTypes.Role, responseRole));
            claims.Add(new Claim(ClaimTypes.Name,appUser.UserName));
        }
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Key));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime tokenExpire = DateTime.Now.AddHours(_tokenSettings.TokenValidityTime);

        JwtSecurityToken token = new JwtSecurityToken(
            _tokenSettings.Issuer,
            _tokenSettings.Audience,
            claims,
            expires: tokenExpire,
            signingCredentials: credentials
        );

        LoginDto summary = new LoginDto()
        {
            Email = appUser.Email,
            FirstName = appUser.FirstName,
            LastName = appUser.LastName,
            Role = responseRole,
        };
        
        summary.Token = new JwtSecurityTokenHandler().WriteToken(token);
        summary.TokenExpireTime = tokenExpire;
        
        await _userManager.UpdateAsync(appUser);
        return summary;
    }
}
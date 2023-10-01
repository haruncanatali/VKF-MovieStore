namespace MovieStore.Application.Common.Models;

public class TokenSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TokenValidityTime { get; set; }
    public int RefreshTokenValidityTime { get; set; }
    public int PasswordTokenTime { get; set; }
}
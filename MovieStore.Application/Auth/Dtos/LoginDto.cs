namespace MovieStore.Application.Auth.Dtos;

public class LoginDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Role { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpireTime { get; set; }
}
using System.Text;
using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Users.Commands.CreateUser;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class UserTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateUser()
    {
        var name = "Haruncan";
        var surname = "";
        var command = new CreateUserCommand() { FirstName = name,LastName = surname};

        var response = _client.PostAsync(
            "/api/users",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotDeleteUser()
    {
        var id = 0;

        var response = _client.DeleteAsync(
            $"/api/users/{id}").Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
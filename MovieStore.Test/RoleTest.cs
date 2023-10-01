using System.Text;
using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Roles.Commands.AddRoleCommand;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class RoleTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateRole()
    {
        var name = "";
        var command = new AddRoleCommand() { RoleName = name };

        var response = _client.PostAsync(
            "/api/roles",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
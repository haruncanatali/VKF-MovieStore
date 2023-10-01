using System.Text;
using MediatR;
using MovieStore.Application.Artists.Commands.UpdateArtist;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Directors.Commands.CreateDirector;
using MovieStore.Application.Directors.Commands.UpdateDirector;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class DirectorTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateDirector()
    {
        var name = "Emily Clarke";
        var command = new CreateDirectorCommand { Name = name };

        var response = _client.PostAsync(
            "/api/directors",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotUpdateDirector()
    {
        var name = "Emily Clarke";
        var command = new UpdateDirectorCommand { Id = 0,Name = name };

        var response = _client.PutAsync(
            "/api/directors",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotDeleteDirector()
    {
        var id = 0;

        var response = _client.DeleteAsync(
            $"/api/directors/{id}").Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
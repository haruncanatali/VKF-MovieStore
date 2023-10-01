using System.Text;
using MediatR;
using MovieStore.Application.Artists.Commands.CreateArtist;
using MovieStore.Application.Artists.Commands.UpdateArtist;
using MovieStore.Application.Common.Models;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class ArtistTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateArtist()
    {
        var name = "John Wick";
        var command = new CreateArtistCommand { Name = name };

        var response = _client.PostAsync(
            "/api/artists",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotUpdateArtist()
    {
        var name = "John Wick";
        var command = new UpdateArtistCommand { Id = 0,Name = name };

        var response = _client.PutAsync(
            "/api/artists",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotDeleteArtist()
    {
        var id = 0;

        var response = _client.DeleteAsync(
            $"/api/artists/{id}").Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
}
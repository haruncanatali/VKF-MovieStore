using System.Text;
using MediatR;
using MovieStore.Application.Artists.Commands.UpdateArtist;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Films.Commands.CreateFilm;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class FilmTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateFilm()
    {
        var name = "Hubble";
        var command = new CreateFilmCommand { Name = name };

        var response = _client.PostAsync(
            "/api/films",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotUpdateFilm()
    {
        var name = "Hubble";
        var command = new UpdateArtistCommand { Id = 0,Name = name };

        var response = _client.PutAsync(
            "/api/films",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotDeleteFilm()
    {
        var id = 0;

        var response = _client.DeleteAsync(
            $"/api/films/{id}").Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
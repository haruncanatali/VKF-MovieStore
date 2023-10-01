using System.Text;
using MediatR;
using MovieStore.Application.Artists.Commands.UpdateArtist;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Genres.Commands.CreateGenre;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class GenreTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreateGenre()
    {
        var name = "Horror";
        var command = new CreateGenreCommand() { Name = name };

        var response = _client.PostAsync(
            "/api/genres",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
using System.Text;
using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.PurchasedMovies.Commands.CreatePurchasedMovie;
using Newtonsoft.Json;

namespace MovieStore.Test;

public class PurchasedMovieTest
{
    private readonly HttpClient _client = new HttpClient();

    [Test]
    public void ShouldNotCreatePurchasedMovie()
    {
        int userId = 0, filmId = 1, amount = 15;
        var command = new CreatePurchasedMovieCommand { UserId = userId,FilmId = filmId,Amount = amount};

        var response = _client.PostAsync(
            "/api/purchasedMovies",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8)
        ).Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
    
    [Test]
    public void ShouldNotDeletePurchasedMovie()
    {
        var id = 0;

        var response = _client.DeleteAsync(
            $"/api/purchasedMovies/{id}").Result;

        Assert.IsNotInstanceOf<BaseResponseModel<Unit>>(response.Content);

        var result = JsonConvert.DeserializeObject<BaseResponseModel<Unit>>(response.Content.ReadAsStringAsync().Result);
        Assert.AreNotEqual(result?.Errors.Length ,0);
    }
}
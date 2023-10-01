using MovieStore.Application.Common.Mappings;
using MovieStore.Application.CustomerFovorites.Queries.Dtos;
using MovieStore.Application.PurchasedMovies.Queries.Dtos;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Users.Queries.Dtos;

public class UserDto : IMapFrom<User>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PurchasedMovieDto> PurchasedMovies { get; set; }
    public List<CustomerFavoriteDto> CustomerFavorites { get; set; }
}
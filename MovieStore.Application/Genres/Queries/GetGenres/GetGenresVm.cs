using MovieStore.Application.Genres.Queries.Dtos;

namespace MovieStore.Application.Genres.Queries.GetGenres;

public class GetGenresVm
{
    public List<GenreDto> Genres { get; set; }
    public int Count { get; set; }
}
using MovieStore.Application.Films.Queries.Dtos;

namespace MovieStore.Application.Films.Queries.GetFilms;

public class GetFilmsVm
{
    public List<FilmDto> Films { get; set; }
    public int Count { get; set; }
}
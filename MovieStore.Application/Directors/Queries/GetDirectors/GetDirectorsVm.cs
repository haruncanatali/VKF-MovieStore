using MovieStore.Application.Directors.Queries.Dtos;

namespace MovieStore.Application.Directors.Queries.GetDirectors;

public class GetDirectorsVm
{
    public List<DirectorDto> Directors { get; set; }
    public int Count { get; set; }
}
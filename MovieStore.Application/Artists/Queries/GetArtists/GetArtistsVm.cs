using MovieStore.Application.Artists.Queries.Dtos;

namespace MovieStore.Application.Artists.Queries.GetArtists;

public class GetArtistsVm
{
    public List<ArtistDto> Artists { get; set; }
    public int Count { get; set; }
}
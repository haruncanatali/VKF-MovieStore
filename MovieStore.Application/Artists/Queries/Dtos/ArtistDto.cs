using AutoMapper;
using MovieStore.Application.Common.Mappings;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Artists.Queries.Dtos;

public class ArtistDto : IMapFrom<Artist>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Artist, ArtistDto>();
    }
}
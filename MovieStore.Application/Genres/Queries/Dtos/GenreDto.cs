using AutoMapper;
using MovieStore.Application.Common.Mappings;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Genres.Queries.Dtos;

public class GenreDto : IMapFrom<Genre>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Genre, GenreDto>();
    }
}
using AutoMapper;
using MovieStore.Application.Artists.Queries.Dtos;
using MovieStore.Application.Common.Mappings;
using MovieStore.Application.Directors.Queries.Dtos;
using MovieStore.Application.Genres.Queries.Dtos;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Films.Queries.Dtos;

public class FilmDto : IMapFrom<Film>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public long DirectorId { get; set; }
    public long GenreId { get; set; }

    public List<ArtistDto> Artists { get; set; }
    public DirectorDto Director { get; set; }
    public GenreDto Genre { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Film, FilmDto>()
            .ForMember(dest => dest.Artists, opt =>
                opt.MapFrom(c => c.Artists))
            .ForMember(dest => dest.Director, opt =>
                opt.MapFrom(c => c.Director))
            .ForMember(dest => dest.Genre, opt =>
                opt.MapFrom(c => c.Genre));
    }
}
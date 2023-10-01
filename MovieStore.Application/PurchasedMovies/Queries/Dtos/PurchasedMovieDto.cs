using AutoMapper;
using MovieStore.Application.Common.Mappings;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.PurchasedMovies.Queries.Dtos;

public class PurchasedMovieDto : IMapFrom<PurchasedMovie>
{
    public string FilmName { get; set; }
    public long Id { get; set; }
    public long UserId { get; set; }
    public long FilmId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PurchasedMovie, PurchasedMovieDto>()
            .ForMember(dest => FilmName, opt =>
                opt.MapFrom(c => c.Film.Name));
    }
}
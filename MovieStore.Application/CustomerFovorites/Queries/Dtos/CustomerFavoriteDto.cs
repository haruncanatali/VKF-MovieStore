using AutoMapper;
using MovieStore.Application.Common.Mappings;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.CustomerFovorites.Queries.Dtos;

public class CustomerFavoriteDto : IMapFrom<CustomerFavorite>
{
    public string Genre { get; set; }
    public long Id { get; set; }
    public long GenreId { get; set; }
    public long UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CustomerFavorite, CustomerFavoriteDto>()
            .ForMember(dest => dest.Genre, opt =>
                opt.MapFrom(c => c.Genre.Name));
    }
}
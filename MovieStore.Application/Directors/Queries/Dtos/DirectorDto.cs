using AutoMapper;
using MovieStore.Application.Common.Mappings;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Directors.Queries.Dtos;

public class DirectorDto : IMapFrom<Director>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Director, DirectorDto>();
    }
}
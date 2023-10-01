using MediatR;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Films.Queries.Dtos;

namespace MovieStore.Application.Films.Queries.GetFilm;

public class GetFilmQuery : IRequest<BaseResponseModel<FilmDto>>
{
    public long Id { get; set; }
}
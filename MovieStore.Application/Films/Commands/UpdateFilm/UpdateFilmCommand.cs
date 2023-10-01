using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Films.Commands.UpdateFilm;

public class UpdateFilmCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public long DirectorId { get; set; }
    public long GenreId { get; set; }
    
    public class Handler : IRequestHandler<UpdateFilmCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            Film? film = await _context.Films
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (film != null)
            {
                film.Name = request.Name;
                film.Year = request.Year;
                film.Price = request.Price;
                film.DirectorId = request.DirectorId;
                film.GenreId = request.GenreId;

                _context.Films.Update(film);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Güncellenecek film bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
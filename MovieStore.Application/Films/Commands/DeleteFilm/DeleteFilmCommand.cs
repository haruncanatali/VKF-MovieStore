using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Films.Commands.DeleteFilm;

public class DeleteFilmCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteFilmCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            Film? film = await _context.Films
                .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (film != null)
            {
                film.Status = EntityStatus.Passive;
                _context.Films.Update(film);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Silinecek film bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
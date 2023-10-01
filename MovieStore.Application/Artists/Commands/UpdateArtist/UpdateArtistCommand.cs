using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public class Handler : IRequestHandler<UpdateArtistCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            Artist? artist = await _context.Artists
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (artist != null)
            {
                artist.Name = request.Name;
                artist.Surname = request.Surname;

                _context.Artists.Update(artist);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Güncellenecek oyuncu bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
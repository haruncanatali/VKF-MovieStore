using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Artists.Commands.DeleteArtist;

public class DeleteArtistCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteArtistCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            Artist? artist = await _context.Artists
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (artist != null)
            {
                artist.Status = EntityStatus.Passive;
                _context.Artists.Update(artist);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Silinecek oyuncu bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
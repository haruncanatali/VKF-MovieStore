using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.PurchasedMovies.Commands.DeletePurchasedMovie;

public class DeletePurchasedMovieCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeletePurchasedMovieCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeletePurchasedMovieCommand request, CancellationToken cancellationToken)
        {
            PurchasedMovie? purchasedMovie = await _context.PurchasedMovies
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (purchasedMovie != null)
            {
                purchasedMovie.Status = EntityStatus.Passive;
                _context.PurchasedMovies.Update(purchasedMovie);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Sİlinecek sipariş bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
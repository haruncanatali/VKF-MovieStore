using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.PurchasedMovies.Commands.CreatePurchasedMovie;

public class CreatePurchasedMovieCommand : IRequest<BaseResponseModel<Unit>>
{
    public long FilmId { get; set; }
    public long UserId { get; set; }
    public int Amount { get; set; }

    public class Handler : IRequestHandler<CreatePurchasedMovieCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreatePurchasedMovieCommand request,
            CancellationToken cancellationToken)
        {
            await _context.PurchasedMovies
                .AddAsync(new PurchasedMovie
                {
                    FilmId = request.FilmId,
                    UserId = request.UserId,
                    Amount = request.Amount,
                    Status = EntityStatus.Active
                }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            var purchasedMovie =
                await _context.Films.FirstOrDefaultAsync(c => c.Id == request.FilmId, cancellationToken);
            var genreId = purchasedMovie!.GenreId;

            var customerFavorite = await _context.CustomerFavorites
                .FirstOrDefaultAsync(c =>
                    c.UserId == request.UserId &&
                    c.GenreId == genreId, cancellationToken);

            if (customerFavorite != null)
            {
                customerFavorite.Amount += request.Amount;
                _context.CustomerFavorites.Update(customerFavorite);
            }
            else
            {
                await _context.CustomerFavorites
                    .AddAsync(new CustomerFavorite
                    {
                        Status = EntityStatus.Active,
                        GenreId = genreId,
                        UserId = request.UserId,
                        Amount = request.Amount
                    }, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
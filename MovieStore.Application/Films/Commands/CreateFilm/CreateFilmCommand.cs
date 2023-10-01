using MediatR;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Films.Commands.CreateFilm;

public class CreateFilmCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public long DirectorId { get; set; }
    public long GenreId { get; set; }
    
    public class Handler : IRequestHandler<CreateFilmCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            await _context.Films
                .AddAsync(new Film
                {
                    Name = request.Name,
                    Year = request.Year,
                    Price = request.Price,
                    DirectorId = request.DirectorId,
                    GenreId = request.GenreId,
                    Status = EntityStatus.Active
                });

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
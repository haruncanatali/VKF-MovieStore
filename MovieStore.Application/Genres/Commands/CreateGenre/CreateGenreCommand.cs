using MediatR;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    
    public class Handler : IRequestHandler<CreateGenreCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            await _context.Genres.AddAsync(new Genre
            {
                Name = request.Name
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
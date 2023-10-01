using MediatR;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Artists.Commands.CreateArtist;

public class CreateArtistCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public class Handler : IRequestHandler<CreateArtistCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Artists
                .AddAsync(new Artist
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Status = EntityStatus.Active
                }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
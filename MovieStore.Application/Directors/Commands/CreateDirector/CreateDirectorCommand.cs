using MediatR;
using Microsoft.AspNetCore.Server.HttpSys;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Directors.Commands.CreateDirector;

public class CreateDirectorCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public class Handler : IRequestHandler<CreateDirectorCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            await _context.Directors
                .AddAsync(new Director
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
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Directors.Commands.DeleteDirector;

public class DeleteDirectorCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteDirectorCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            Director? director = await _context.Directors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (director != null)
            {
                director.Status = EntityStatus.Passive;
                _context.Directors.Update(director);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Silinecek yönetmen bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value,"");
        }
    }
}
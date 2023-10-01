using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Common.Exceptions;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Directors.Commands.UpdateDirector;

public class UpdateDirectorCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public class Handler : IRequestHandler<UpdateDirectorCommand,BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            Director? director = await _context.Directors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (director != null)
            {
                director.Name = request.Name;
                director.Surname = request.Surname;

                _context.Directors.Update(director);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException("Güncellenecek yönetmen bulunamadı.");
            }

            return new BaseResponseModel<Unit>().Success(Unit.Value, "");
        }
    }
}
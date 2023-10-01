using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieStore.Application.Common.Interfaces;
using MovieStore.Application.Common.Models;
using MovieStore.Application.Users.Commands.CreateUser;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }

    public class Handler : IRequestHandler<DeleteUserCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;
        private readonly ILogger<CreateUserCommand> _logger;

        public Handler(IApplicationContext context, ILogger<CreateUserCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
                    
                if (user == null)
                {
                    _logger.LogInformation("Silinecek kullanıcı bulunamadı.");
                    return new BaseResponseModel<Unit>().Failure(new List<string>{"Silinecek kullanıcı bulunamadı."});
                }

                user.Status = EntityStatus.Passive;

                var db_result = await _context.SaveChangesAsync(cancellationToken);

                if (db_result == 0)
                {
                    _logger.LogInformation($"Kullanıcı silinemedi. {user.FullName}");
                    return new BaseResponseModel<Unit>().Failure(new List<string>{"Kullanıcı silinemedi."});
                }
                    
                return new BaseResponseModel<Unit>().Success(Unit.Value,"Kullanıcı başarıyla silindi.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
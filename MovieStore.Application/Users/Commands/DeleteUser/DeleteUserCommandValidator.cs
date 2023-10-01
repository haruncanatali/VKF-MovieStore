using FluentValidation;

namespace MovieStore.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Silinecek müşteri için parametre (ID) giriniz.");
    }
}
using FluentValidation;

namespace MovieStore.Application.Roles.Commands.AddRoleCommand;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        RuleFor(c => c.RoleName)
            .NotEmpty().WithMessage("Rol adı boş olamaz.");
    }
}
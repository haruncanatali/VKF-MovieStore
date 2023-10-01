using FluentValidation;

namespace MovieStore.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("Müşteri adı boş olamaz.")
            .Length(2, 50).WithMessage("Müşteri adı 2-50 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Müşteri soyadı boş olamaz.")
            .Length(2, 50).WithMessage("Müşteri soyadı 2-50 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Müşteri E-Posta boş olamaz.");
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Müşteri şifresi boş olamaz.");
    }
}
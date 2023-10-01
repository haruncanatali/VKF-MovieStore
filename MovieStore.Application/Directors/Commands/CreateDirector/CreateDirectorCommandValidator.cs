using FluentValidation;

namespace MovieStore.Application.Directors.Commands.CreateDirector;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Yönetmen adı boş olamaz.")
            .Length(2, 50).WithMessage("Yönetmen adı 2-50 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.Surname)
            .NotEmpty().WithMessage("Yönetmen soyadı boş olamaz.")
            .Length(2, 50).WithMessage("Yönetmen soyadı 2-50 karakter aralığından oluşmak zorundadır.");
    }
}
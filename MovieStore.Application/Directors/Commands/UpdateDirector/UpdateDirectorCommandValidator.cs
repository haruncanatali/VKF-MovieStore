using FluentValidation;

namespace MovieStore.Application.Directors.Commands.UpdateDirector;

public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Güncellenecek yönetmenin ID parametresi eksik.");
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Yönetmen adı boş olamaz.")
            .Length(2, 50).WithMessage("Yönetmen adı 2-50 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.Surname)
            .NotEmpty().WithMessage("Yönetmen soyadı boş olamaz.")
            .Length(2, 50).WithMessage("Yönetmen soyadı 2-50 karakter aralığından oluşmak zorundadır.");
    }
}
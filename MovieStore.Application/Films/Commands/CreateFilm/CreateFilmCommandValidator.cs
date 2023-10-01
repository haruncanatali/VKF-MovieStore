using FluentValidation;

namespace MovieStore.Application.Films.Commands.CreateFilm;

public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
{
    public CreateFilmCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Film adı boş olamaz.")
            .Length(1, 250).WithMessage("Film adı 1-250 karakter aralığından olumak zorundadır.");
        RuleFor(c => c.Year)
            .NotNull().WithMessage("Film yılı boş olamaz.");
        RuleFor(c => c.Price)
            .NotNull().WithMessage("Film fiyatı boş olamaz.");
        RuleFor(c => c.DirectorId)
            .NotNull().WithMessage("Filmin yönetmeni olmalıdır.");
        RuleFor(c => c.GenreId)
            .NotNull().WithMessage("Filmin türü olmalıdır.");
    }
}
using FluentValidation;

namespace MovieStore.Application.Artists.Commands.CreateArtist;

public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    public CreateArtistCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Oyuncu adı boş olamaz.")
            .Length(2, 50).WithMessage("Oyuncu adı 2-50 karakter aralığında olmalıdır.");
        RuleFor(c => c.Surname)
            .NotEmpty().WithMessage("Oyuncu soyadı boş olamaz.")
            .Length(2, 50).WithMessage("Oyuncu soyadı 2-50 karakter aralığında olmalıdır.");
    }
}
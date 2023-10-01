using FluentValidation;

namespace MovieStore.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Oyuncu adı boş olamaz.")
            .Length(2, 50).WithMessage("Oyuncu adı 2-50 karakter aralığında olmalıdır.");
        RuleFor(c => c.Surname)
            .NotEmpty().WithMessage("Oyuncu soyadı boş olamaz.")
            .Length(2, 50).WithMessage("Oyuncu soyadı 2-50 karakter aralığında olmalıdır.");
        RuleFor(c => c.Id)
            .NotNull()
            .WithMessage("Silinecek oyuncu parametresi (ID) girilmelidir.");
    }
}
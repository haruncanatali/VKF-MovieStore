using FluentValidation;

namespace MovieStore.Application.Artists.Commands.DeleteArtist;

public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
{
    public DeleteArtistCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .WithMessage("Silinecek oyuncu parametresi (ID) girilmelidir.");
    }
}